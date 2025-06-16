using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos.Basic;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using PDMApp.Utils;
using PDMApp.Utils.BasicProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using ClosedXML.Excel;

namespace PDMApp.Controllers.Basic
{
    [Route("api/v1/Basic/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public MaterialController(pcms_pdm_testContext pcms_Pdm_TestContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_TestContext;
        }

        // POST api/v1/Basic/Material
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<PagedResult<MaterialDto>>>> Post([FromBody] MaterialSearchParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var (isSuccess, message, query) = await Service.Basic.MaterialQueryHelper.QueryMaterial(_pcms_Pdm_TestContext, value);

                if (!isSuccess)
                {
                    return StatusCode(200, new
                    {
                        ErrorCode = "BUSINESS_ERROR",
                        Message = message
                    });
                }

                query = query.OrderBy(m => m.MatNo);

                var pagedResult = await query.ToPagedResultAsync(value.Pagination.PageNumber, value.Pagination.PageSize);

                return APIResponseHelper.HandlePagedApiResponse(pagedResult);
            }
            catch (Exception ex)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "SERVER_ERROR",
                    Message = "ServerError",
                    Details = ex.Message
                });
            }
        }

        // POST api/v1/Basic/Material/by-id
        [HttpPost("by-id")]
        public async Task<ActionResult<APIStatusResponse<MaterialDto>>> PostByMatId([FromBody] MatIdParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var (isSuccess, message, query) = await Service.Basic.MaterialQueryHelper.QueryMaterialByMatId(_pcms_Pdm_TestContext, value.MatId);

                if (!isSuccess)
                {
                    return StatusCode(200, new
                    {
                        ErrorCode = "BUSINESS_ERROR",
                        Message = message
                    });
                }

                var material = await query.FirstOrDefaultAsync();

                return Ok(new
                {
                    ErrorCode = "OK",
                    Message = "",
                    Data = material
                });
            }
            catch (Exception ex)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "SERVER_ERROR",
                    Message = "ServerError",
                    Details = ex.Message
                });
            }
        }



        // POST api/v1/Basic/Material/initial
        [HttpPost("initial")]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> GetComboData()
        {
            try
            {
                var resultData = new Dictionary<string, object>();

                resultData["AttypCombo"] = await Service.Basic.MaterialQueryHelper.QueryAttyp(_pcms_Pdm_TestContext).ToListAsync();
                resultData["UomCombo"] = await Service.Basic.MaterialQueryHelper.QueryUom(_pcms_Pdm_TestContext).ToListAsync();
                resultData["OrderStatusCombo"] = await Service.Basic.MaterialQueryHelper.QueryOrderStatus(_pcms_Pdm_TestContext).ToListAsync();
                resultData["BClassCombo"] = await Service.Basic.MaterialQueryHelper.QueryBClass(_pcms_Pdm_TestContext).ToListAsync();
                resultData["MClassCombo"] = await Service.Basic.MaterialQueryHelper.QueryMClass(_pcms_Pdm_TestContext);
                resultData["SClassCombo"] = await Service.Basic.MaterialQueryHelper.QuerySClass(_pcms_Pdm_TestContext);

                return APIResponseHelper.HandleDynamicMultiPageResponse(resultData);
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

        // POST api/v1/Basic/Material/create
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("create")]
        public async Task<ActionResult<APIStatusResponse<string>>> CreateMaterial([FromBody] MaterialCreateParameter value)
        {
            try
            {
                // 取得當前登入者資訊
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString();

                var (isSuccess, message) = await Service.Basic.MaterialInsertHelper.InsertMaterialAsync(_pcms_Pdm_TestContext, value, pccuid);

                if (!isSuccess)
                {
                    return StatusCode(200, new
                    {
                        ErrorCode = "BUSINESS_ERROR",
                        Message = message
                    });
                }

                return StatusCode(200, new
                {
                    ErrorCode = "OK",
                    Message = ""
                });
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

        // POST api/v1/Basic/Material/update
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("update")]
        public async Task<ActionResult<APIStatusResponse<string>>> UpdateMaterial([FromBody] MaterialUpdateParameter value)
        {
            try
            {
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString();

                var (isSuccess, message) = await Service.Basic.MaterialUpdateHelper.UpdateMaterialAsync(_pcms_Pdm_TestContext, value, pccuid);

                if (!isSuccess)
                {
                    return StatusCode(200, new
                    {
                        ErrorCode = "BUSINESS_ERROR",
                        Message = message
                    });
                }

                return StatusCode(200, new
                {
                    ErrorCode = "OK",
                    Message = ""
                });
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

        // POST api/v1/Basic/Material/submit
        [HttpPost("submit")]
        public async Task<ActionResult<APIStatusResponse<List<MaterialDto>>>> SubmitToSerp([FromBody] List<MaterialSubmitParameter> requestList)
        {
            try
            {
                var (isSuccess, message, updatedMaterialDtos) = await Service.Basic.MaterialSubmitHelper.SubmitMultipleToSerpAsync(_pcms_Pdm_TestContext, requestList);

                if (!isSuccess)
                {
                    return StatusCode(200, new APIStatusResponse<List<MaterialDto>>
                    {
                        ErrorCode = "BUSINESS_ERROR",
                        Message = message,
                        Data = null // 錯誤時 Data 為 null
                    });
                }

                // 成功時，回傳 MaterialDto 列表
                return StatusCode(200, new APIStatusResponse<List<MaterialDto>>
                {
                    ErrorCode = "OK",
                    Message = message,
                    Data = updatedMaterialDtos
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIStatusResponse<List<MaterialDto>>
                {
                    ErrorCode = "Server_ERROR",
                    Message = "ServerError",
                    Data = null 
                });
            }
        }

        // POST api/v1/Basic/Material/export
        [HttpPost("export")]
        public async Task<ActionResult<APIStatusResponse<object>>> ExportToExcel([FromBody] MaterialSearchParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var (isSuccess, message, query) = await Service.Basic.MaterialQueryHelper.QueryMaterial(_pcms_Pdm_TestContext, value);

                if (!isSuccess)
                {
                    return StatusCode(200, new
                    {
                        ErrorCode = "BUSINESS_ERROR",
                        Message = message
                    });
                }

                var dataList = await query.OrderBy(m => m.MatNo).ToListAsync();

                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("MaterialList");

                // 設定標題（僅保留指定欄位）
                string[] headers = new[]
                {
                    "PDM MATL NO",       // MatNo
                    "SERP MATL No",      // SerpMatNo
                    "MATL Full Info",    // MatFullNm
                    "Color No",          // ColorNo
                    "Color Info",        // ColorNm
                    "STANDARD",          // Standard
                    "MATL Note",         // Memo
                    "MDA MATL No.",      // Matnr
                    "Primary Cat",       // ScmBclassNo
                    "Secondary Cat",     // ScmMclassNo
                    "Minor Cat."         // ScmSclassNo
                };

                for (int col = 0; col < headers.Length; col++)
                {
                    worksheet.Cell(1, col + 1).Value = headers[col];
                    worksheet.Cell(1, col + 1).Style.Font.Bold = true;
                    worksheet.Cell(1, col + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                // 填入資料
                int row = 2;
                foreach (var item in dataList)
                {
                    worksheet.Cell(row, 1).Value = item.MatNo;
                    worksheet.Cell(row, 2).Value = item.SerpMatNo;
                    worksheet.Cell(row, 3).Value = item.MatFullNm;
                    worksheet.Cell(row, 4).Value = item.ColorNo;
                    worksheet.Cell(row, 5).Value = item.ColorNm;
                    worksheet.Cell(row, 6).Value = item.Standard;
                    worksheet.Cell(row, 7).Value = item.Memo;
                    worksheet.Cell(row, 8).Value = item.Matnr;
                    worksheet.Cell(row, 9).Value = item.ScmBclassNo;
                    worksheet.Cell(row, 10).Value = item.ScmMclassNo;
                    worksheet.Cell(row, 11).Value = item.ScmSclassNo;
                    row++;
                }

                // 自動調整欄位寬度
                worksheet.Columns().AdjustToContents();

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Position = 0;

                // 轉換為 Base64 字串
                var base64String = Convert.ToBase64String(stream.ToArray());

                // 準備回傳的 ExportFileResponseDto
                var responseFileDto = new Dtos.ExportFileResponseDto
                {
                    FileName = $"MaterialList_{DateTime.Now:yyyyMMddHHmmss}.xlsx",
                    FileContent = base64String
                };

                // 直接建構 APIStatusResponse<object> 物件並回傳，Data 為單一 ExportFileResponseDto
                return Ok(new APIStatusResponse<object>
                {
                    ErrorCode = "OK",
                    Message = "匯出成功", // 可以根據需求設定訊息
                    Data = responseFileDto // 直接賦值為單一物件
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "SERVER_ERROR",
                    Message = $"匯出過程中發生錯誤: {ex.Message}"
                });
            }
        }

        // POST api/v1/Basic/Material/import/create
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("import/create")]
        public async Task<ActionResult<APIStatusResponse<object>>> ImportCreateMaterials([FromBody] List<MaterialCreateParameter> importList)
        {
            try
            {
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString();

                var (isSuccess, successList, errorList) = await Service.Basic.MaterialImportCreateHelper.TryImportCreateAsync(_pcms_Pdm_TestContext, importList, pccuid);

                if (!isSuccess)
                {
                    var stream = Service.Basic.MaterialImportCreateHelper.ExportCreateErrorExcel(errorList);
                    var base64 = Convert.ToBase64String(stream.ToArray());

                    // 準備回傳的 ExportFileResponseDto
                    var responseFileDto = new Dtos.ExportFileResponseDto
                    {
                        FileName = $"MaterialCreateFailed_{DateTime.Now:yyyyMMddHHmmss}.xlsx",
                        FileContent = base64
                    };

                    // 直接建構 APIStatusResponse<object> 物件並回傳，Data 為單一 ExportFileResponseDto
                    return Ok(new APIStatusResponse<object>
                    {
                        ErrorCode = "IMPORT_FAILED",
                        Message = "匯入失敗，請檢查系統導出的 Excel",
                        Data = responseFileDto // 直接賦值為單一物件
                    });
                }

                // 成功匯入時不包含文件，保持原有的成功回傳格式
                return StatusCode(200, new
                {
                    ErrorCode = "OK",
                    Message = "匯入成功",
                    Data = successList
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "SERVER_ERROR",
                    Message = "ServerError",
                    Details = ex.Message
                });
            }
        }


        // POST api/v1/Basic/Material/import/update
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("import/update")]
        public async Task<ActionResult<APIStatusResponse<object>>> ImportUpdateMaterials([FromBody] List<MaterialUpdateParameter> importList)
        {
            try
            {
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString();

                var (isSuccess, successList, errorList) = await Service.Basic.MaterialImportUpdateHelper.TryImportUpdateAsync(_pcms_Pdm_TestContext, importList, pccuid);

                if (!isSuccess)
                {
                    var stream = Service.Basic.MaterialImportUpdateHelper.ExportUpdateErrorExcel(errorList);
                    var base64 = Convert.ToBase64String(stream.ToArray());

                    // 準備回傳的 ExportFileResponseDto
                    var responseFileDto = new Dtos.ExportFileResponseDto
                    {
                        FileName = $"MaterialUpdateFailed_{DateTime.Now:yyyyMMddHHmmss}.xlsx",
                        FileContent = base64
                    };

                    // 直接建構 APIStatusResponse<object> 物件並回傳，Data 為單一 ExportFileResponseDto
                    return Ok(new APIStatusResponse<object>
                    {
                        ErrorCode = "IMPORT_FAILED",
                        Message = "匯入失敗，請檢查系統導出的 Excel",
                        Data = responseFileDto // 直接賦值為單一物件
                    });
                }

                return StatusCode(200, new
                {
                    ErrorCode = "OK",
                    Message = "匯入成功",
                    Data = successList
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "SERVER_ERROR",
                    Message = "ServerError",
                    Details = ex.Message
                });
            }
        }

        // POST api/v1/Basic/Material/purchase
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("purchase")]
        public async Task<ActionResult<APIStatusResponse<object>>> PurchaseMaterialPreview([FromBody] List<MaterialPurchaseParameter> importList)
        {
            try
            {
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString();

                var (isSuccess, stream) = await Service.Basic.MaterialImportPurchaseHelper.GenerateMaterialPurchasePreviewExcelAsync(_pcms_Pdm_TestContext, importList);

                var base64 = Convert.ToBase64String(stream.ToArray());
                var fileName = $"MaterialPurchasePreview_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

                // 準備回傳的 ExportFileResponseDto
                var responseFileDto = new Dtos.ExportFileResponseDto
                {
                    FileName = fileName,
                    FileContent = base64
                };

                string errorCode = isSuccess ? "OK" : "VALIDATION_FAILED";
                string message = isSuccess ? "預覽產生成功" : "部分資料不合法，請參考 Excel";

                // 直接建構 APIStatusResponse<object> 物件並回傳，Data 為單一 ExportFileResponseDto
                return Ok(new APIStatusResponse<object>
                {
                    ErrorCode = errorCode,
                    Message = message,
                    Data = responseFileDto // 直接賦值為單一物件
                });

                //return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "1122.xlsx");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "SERVER_ERROR",
                    Message = "ServerError",
                    Details = ex.Message
                });
            }
        }
    }
}
