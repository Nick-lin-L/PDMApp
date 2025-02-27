using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dtos.PGTSPEC;  // 根據實際 DTO 命名空間調整
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;  // 根據實際參數類別命名空間調整
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Utils.PGTSPEC;
using System.Data.Common;

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
                // 創建 MultiPageResultDTO
                var resultData = new MultiPageResultDTO();

                // BasicData 查詢
                var basicQuery = Utils.PGTSPEC.PGTSPECQueryHelper.GetSpecBasicResponse(_pcms_Pdm_TestContext)
                    .Where(ph => string.IsNullOrWhiteSpace(value.SpecMId) || ph.SpecMId.Equals(value.SpecMId));
                resultData.BasicData = await basicQuery.Distinct().ToListAsync();

                // Head 查詢
                var headQuery = Utils.PGTSPEC.PGTSPECQueryHelper.GetSpecHeadResponse(_pcms_Pdm_TestContext)
                    .Where(h => string.IsNullOrWhiteSpace(value.SpecMId) || h.SpecMId.Equals(value.SpecMId));
                resultData.HeadData = await headQuery.Distinct().ToListAsync();

                // Upper, Sole, Other 查詢
                var upperQuery = Utils.PGTSPEC.PGTSPECQueryHelper.GetSpecUpperResponse(_pcms_Pdm_TestContext)
                    .Where(si => string.IsNullOrWhiteSpace(value.SpecMId) || si.SpecMId.Equals(value.SpecMId));

                // 先轉成 List 再做排序（避免運算式樹的限制）
                var allUpperData = await upperQuery.ToListAsync();

                // 排序邏輯：先按 material_group，再按 act_part_no 數值排序，最後按 parts_no 判斷 null 先後
                var sortedUpperData = allUpperData
                    .OrderBy(si => si.MatGroup)
                    .ThenBy(si => int.TryParse(si.ActPartNo, out int num) ? num : 0)
                    .ThenBy(si => string.IsNullOrEmpty(si.No) ? 1 : 0)  // parts_no 有值的排前
                    .ThenBy(si => si.No) // 按 parts_no 排序
                    .ThenBy(si => si.Sort) // 加入 material_sort 排序
                    .ToList();

                // 根據 MatGroup 分組
                resultData.UpperData = sortedUpperData.Where(si => si.MatGroup == "A").ToList();
                resultData.SoleData = sortedUpperData.Where(si => si.MatGroup == "B").ToList();
                resultData.OtherData = sortedUpperData.Where(si => si.MatGroup == "C").ToList();

                // 手動轉換為字典
                var dynamicData = new Dictionary<string, object>
                {
                    { "BasicData", resultData.BasicData },
                    { "HeadData", resultData.HeadData },
                    { "UpperData", resultData.UpperData },
                    { "SoleData", resultData.SoleData },
                    { "OtherData", resultData.OtherData },
                    { "ErrorCode", "OK" }, 
                    { "Message", "查詢成功" }, // 可加上訊息
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
        [HttpPost("UpdateSpec")]
        public async Task<ActionResult> Post([FromBody] PGTSpec5SheetsUpdateParameter value)
        {
            try
            {
                var headData = value.HeadData.FirstOrDefault();
                if (headData == null || string.IsNullOrWhiteSpace(headData.SpecMId))
                {
                    return BadRequest(new { Message = "請提供有效的 SpecMId" });
                } 

                // 嘗試更新 SpecHead 和 SpecItem
                var (success, message) = await PGTSPECUpdateHelper.UpdateSpecAsync(_pcms_Pdm_TestContext, value);

                if (!success)
                {
                    return StatusCode(500, new { ErrorCode = "UPDATE_FAILED", Message = message });
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
        public async Task<ActionResult<Utils.APIStatusResponse<IEnumerable<Dtos.ExportFileResponseDto>>>> ExportToExcel([FromBody] PGTSpec5SheetsSearchParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // ItemSheet 查詢
                var itemSheetData = Utils.PGTSPEC.PGTSPECQueryHelper.GetItemSheetResponse(_pcms_Pdm_TestContext)
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

                var response = new Dtos.ExportFileResponseDto
                {
                    FileName = fileName,
                    FileContent = base64File
                };

                return Utils.APIResponseHelper.HandleApiResponse(new[] { response }, "OK", "");
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
    }
}
