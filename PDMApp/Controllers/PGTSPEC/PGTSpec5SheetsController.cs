using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos.PGTSPEC;  // 根據實際 DTO 命名空間調整
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;  // 根據實際參數類別命名空間調整
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Service.PGTSPEC;
using System.Data.Common;
using Microsoft.AspNetCore.Authorization;
using PDMApp.Utils.BasicProgram;
using PDMApp.Utils;
using ClosedXML.Excel;
using System.IO;

namespace PDMApp.Controllers.SPEC
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PGTSpec5SheetsController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public PGTSpec5SheetsController(pcms_pdm_testContext pcms_Pdm_TestContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_TestContext;
        }
        // POST api/v1/PGTSpec5Sheets
        [HttpPost]
        public async Task<ActionResult<Utils.APIStatusResponse<IDictionary<string, object>>>> Post([FromBody] PGTSpec5SheetsSearchParameter value)
        {
            try
            {
                var resultData = new MultiPageResultDTO();
                string currentFactNo = value.DevFactoryNo ?? "";

                // BasicData 查詢
                var basicQuery = Service.PGTSPEC.PGTSPECQueryHelper.GetSpecBasicResponse(_pcms_Pdm_TestContext)
                    .Where(ph => string.IsNullOrWhiteSpace(value.SpecMId) || ph.SpecMId.Equals(value.SpecMId));
                resultData.BasicData = await basicQuery.Distinct().ToListAsync();

                // Head 查詢
                var headQuery = Service.PGTSPEC.PGTSPECQueryHelper.GetSpecHeadResponse(_pcms_Pdm_TestContext, currentFactNo)
                    .Where(h => string.IsNullOrWhiteSpace(value.SpecMId) || h.SpecMId.Equals(value.SpecMId));
                resultData.HeadData = await headQuery.Distinct().ToListAsync();

                // Upper, Sole, Other 查詢
                // **直接等待 GetSpecUpperResponse 返回 List<SpecUpperDTO>**
                var allUpperData = await Service.PGTSPEC.PGTSPECQueryHelper.GetSpecUpperResponse(_pcms_Pdm_TestContext);

                // 在記憶體中對 allUpperData 進行篩選和排序
                var filteredUpperData = allUpperData
                    .Where(si => string.IsNullOrWhiteSpace(value.SpecMId) || si.SpecMId.Equals(value.SpecMId))
                    .OrderBy(si => si.MatGroup)
                    .ThenBy(si => int.TryParse(si.ActPartNo, out int num) ? num : int.MaxValue)
                    .ThenBy(si => string.IsNullOrEmpty(si.No) ? 1 : 0)  // parts_no 有值的排前
                    .ThenBy(si => si.No) // 按 parts_no 排序
                    .ThenBy(si => si.Sort) // 加入 material_sort 排序
                    .ToList();

                // 根據 MatGroup 分組
                resultData.UpperData = filteredUpperData.Where(si => si.MatGroup == "A").ToList();
                resultData.SoleData = filteredUpperData.Where(si => si.MatGroup == "B").ToList();
                resultData.OtherData = filteredUpperData.Where(si => si.MatGroup == "C").ToList();

                // 手動轉換為字典
                var dynamicData = new Dictionary<string, object>
                {
                    { "BasicData", resultData.BasicData },
                    { "HeadData", resultData.HeadData },
                    { "UpperData", resultData.UpperData },
                    { "SoleData", resultData.SoleData },
                    { "OtherData", resultData.OtherData },
                    { "ErrorCode", "OK" },
                    { "Message", "查詢成功" },
                };

                return StatusCode(200, dynamicData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "Server_ERROR",
                    Message = "ServerError",
                    Details = ex.Message
                });
            }
        }

        // POST api/v1/PGTSpec5Sheets/UpdateSpec
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("UpdateSpec")]
        public async Task<ActionResult> Post([FromBody] PGTSpec5SheetsUpdateParameter value)
        {
            try
            {
                // 取得當前登入者資訊
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString();  // 從 currentUser 取得 pccuid
                var name = currentUser.Name?.ToString();  // 從 currentUser 取得 name

                var headData = value.HeadData.FirstOrDefault();
                if (headData == null || string.IsNullOrWhiteSpace(headData.SpecMId))
                {
                    return BadRequest(new { Message = "請提供有效的 SpecMId" });
                } 

                // 嘗試更新 SpecHead 和 SpecItem
                var (success, message) = await PGTSPECUpdateHelper.UpdateSpecAsync(_pcms_Pdm_TestContext, value, pccuid, name);

                if (!success)
                {
                    return StatusCode(200, new { ErrorCode = "UPDATE_FAILED", Message = message });
                }

                return StatusCode(200, new
                {
                    ErrorCode = "OK",
                    Message = "Spec 項目已成功更新"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "Server_ERROR",
                    Message = "伺服器錯誤，請聯絡系統管理員",
                    Details = ex.Message
                });
            }
        }

        // POST api/v1/PGTSpec5Sheets/Export
        [HttpPost("Export")]
        public async Task<ActionResult<Utils.APIStatusResponse<object>>> ExportToExcel([FromBody] PGTSpec5SheetsSearchParameter value) // 將返回型別改為 object
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // ItemSheet 查詢
                var itemSheetData = Service.PGTSPEC.PGTSPECQueryHelper.GetItemSheetResponse(_pcms_Pdm_TestContext)
                    .Where(ph => string.IsNullOrWhiteSpace(value.SpecMId) || ph.SpecMId.Equals(value.SpecMId))
                    .ToList(); // 執行查詢，轉為 List

                string devNo = itemSheetData.FirstOrDefault()?.DevNo;
                string itemNo = itemSheetData.FirstOrDefault()?.ItemNo;
                string colorNo = itemSheetData.FirstOrDefault()?.DevelopmentColorNo;

                // 生成檔案名稱
                string fileName = $"PCC.{devNo}({itemNo})_{colorNo}_量產中文.xlsx";

                // 使用 PGTSPECExportHelper 匯出資料
                var fileContent = PGTSPECExportHelper.ExportToExcel(itemSheetData);

                string base64File = Convert.ToBase64String(fileContent); // 轉 Base64

                // 準備回傳的 ExportFileResponseDto
                var responseFileDto = new Dtos.ExportFileResponseDto
                {
                    FileName = fileName,
                    FileContent = base64File
                };

                // 直接建構 APIStatusResponse<object> 物件並回傳，Data 為單一 ExportFileResponseDto
                return Ok(new Utils.APIStatusResponse<object>
                {
                    ErrorCode = "OK",
                    Message = "匯出成功", // 可以根據需求設定訊息
                    Data = responseFileDto // 直接賦值為單一物件
                });
            }
            catch (DbException ex)
            {
                return new ObjectResult(Utils.APIResponseHelper.HandleApiError<object>(
                    errorCode: "10001",
                    message: $"匯出過程中發生錯誤: {ex.Message}",
                    data: null
                ));
            }
        }

        // POST api/v1/PGTSpec5Sheets/MaterialExport
        [HttpPost("MaterialExport")]
        public async Task<ActionResult<APIStatusResponse<object>>> MaterialExport([FromBody] PGTSpecMaterialExportRequestParameter value) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(APIResponseHelper.HandleApiError<object>(
                    errorCode: "INVALID_INPUT",
                    message: "傳入參數不合法，請檢查請求內容。",
                    data: ModelState
                ));
            }

            // 檢查是否傳入了要匯出的數據
            if (value.MaterialData == null || !value.MaterialData.Any())
            {
                return Ok(new APIStatusResponse<object>
                {
                    ErrorCode = "NO_DATA",
                    Message = "沒有可供匯出的資料。請確保 MaterialData 列表不為空。",
                    Data = null
                });
            }

            // 根據您之前的需求，如果 MatFullName (現在對應 input.Material) 為空，則返回錯誤
            if (value.MaterialData.Any(item => string.IsNullOrEmpty(item.Material)))
            {
                return Ok(new APIStatusResponse<object>
                {
                    ErrorCode = "MATERIAL_DESCRIPTION_EMPTY",
                    Message = "不可包含物料說明為空的資料。",
                    Data = null
                });
            }

            try
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Material Export");

                // Excel 標頭：根據您之前的要求，不包含 "SPEC M ID"，且保留所有原先的欄位名稱
                string[] headers = {
                    "MAT TYPE", "MAT NO", "MAT FULL NAME", "COLOR NO", "COLOR NAME",
                    "STANDARD", "UOM", "MEMO", "PDM MATL NO",
                    "SCM CLASS L", "SCM CLASS M", "SCM CLASS S", "ERROR MESSAGE"
                };

                for (int col = 0; col < headers.Length; col++)
                {
                    worksheet.Cell(1, col + 1).Value = headers[col];
                    worksheet.Cell(1, col + 1).Style.Font.Bold = true;
                    worksheet.Cell(1, col + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                int row = 2;
                foreach (var item in value.MaterialData) // 直接遍歷前端傳來的數據
                {
                    worksheet.Cell(row, 1).Value = ""; 
                    worksheet.Cell(row, 2).Value = ""; 
                    worksheet.Cell(row, 3).Value = item.Material; 
                    worksheet.Cell(row, 4).Value = ""; 
                    worksheet.Cell(row, 5).Value = item.Colors; 
                    worksheet.Cell(row, 6).Value = item.Standard;
                    worksheet.Cell(row, 7).Value = ""; 
                    worksheet.Cell(row, 8).Value = item.MaterialComment;
                    worksheet.Cell(row, 9).Value = "";
                    worksheet.Cell(row, 10).Value = "";
                    worksheet.Cell(row, 11).Value = "";
                    worksheet.Cell(row, 12).Value = "";
                    worksheet.Cell(row, 13).Value = ""; 
                    row++;
                }

                worksheet.Columns().AdjustToContents();

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                byte[] fileBytes = stream.ToArray();

                string fileName = $"物料匯出_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

                string base64File = Convert.ToBase64String(fileBytes);

                var responseFileDto = new ExportFileResponseDto
                {
                    FileName = fileName,
                    FileContent = base64File
                };

                return Ok(new APIStatusResponse<object>
                {
                    ErrorCode = "OK",
                    Message = "物料資料匯出成功。",
                    Data = responseFileDto
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIStatusResponse<object>
                {
                    ErrorCode = "SERVER_ERROR",
                    Message = $"伺服器錯誤，物料匯出失敗。請聯絡系統管理員。錯誤訊息: {ex.Message}",
                    Data = null // 不再返回 ex.Message 到 Data，避免敏感資訊洩露
                });
            }
        }
    }
}
