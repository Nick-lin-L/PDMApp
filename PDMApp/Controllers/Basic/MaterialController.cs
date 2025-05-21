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
        public async Task<ActionResult<APIStatusResponse<object>>> SubmitToSerp([FromBody] List<MaterialSubmitParameter> requestList)
        {
            try
            {
                var (isSuccess, message) = await Service.Basic.MaterialSubmitHelper.SubmitMultipleToSerpAsync(_pcms_Pdm_TestContext, requestList);

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
                    Message = message
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

        // POST api/v1/Basic/Material/export
        [HttpPost("export")]
        public async Task<ActionResult<APIStatusResponse<IEnumerable<Dtos.ExportFileResponseDto>>>> ExportToExcel([FromBody] MaterialSearchParameter value)
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
                    "PDM MATL NO",      // MatNo
                    "SERP MATL No",     // SerpMatNo
                    "MATL Full Info",   // MatFullNm
                    "Color No",         // ColorNo
                    "Color Info",       // ColorNm
                    "STANDARD",         // Standard
                    "MATL Note",        // Memo
                    "MDA MATL No.",     // Matnr
                    "Primary Cat",      // ScmBclassNo
                    "Secondary Cat",    // ScmMclassNo
                    "Minor Cat."        // ScmSclassNo
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

                // 準備回傳的 ResponseDto
                var response = new Dtos.ExportFileResponseDto
                {
                    FileName = $"MaterialList_{DateTime.Now:yyyyMMddHHmmss}.xlsx",
                    FileContent = base64String
                };

                // 回傳 API 狀態
                return APIResponseHelper.HandleApiResponse(new[] { response }, "OK", "");
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

                    return StatusCode(200, new
                    {
                        ErrorCode = "IMPORT_FAILED",
                        Message = "匯入失敗，請檢查系統導出的 Excel",
                        File = new Dtos.ExportFileResponseDto
                        {
                            FileName = $"MaterialCreateFailed_{DateTime.Now:yyyyMMddHHmmss}.xlsx",
                            FileContent = base64
                        }
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


        // POST api/v1/Basic/Material/import/update
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("import/update")]
        public async Task<ActionResult<APIStatusResponse<object>>> ImportUpdateMaterials([FromBody] List<MaterialUpdateParameter> importList)
        {
            try
            {
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString();

                var (isSuccess, errorList) = await Service.Basic.MaterialImportUpdateHelper.TryImportUpdateAsync(_pcms_Pdm_TestContext, importList, pccuid);

                if (!isSuccess)
                {
                    var stream = Service.Basic.MaterialImportUpdateHelper.ExportUpdateErrorExcel(errorList);
                    var base64 = Convert.ToBase64String(stream.ToArray());

                    //return StatusCode(200, new
                    //{
                    //    ErrorCode = "IMPORT_FAILED",
                    //    Message = "匯入失敗，請檢查系統導出的 Excel",
                    //    File = new Dtos.ExportFileResponseDto
                    //    {
                    //        FileName = $"MaterialUpdateFailed_{DateTime.Now:yyyyMMddHHmmss}.xlsx",
                    //        FileContent = base64
                    //    }
                    //});

                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "1122.xlsx");
                }

                return StatusCode(200, new
                {
                    ErrorCode = "OK",
                    Message = "匯入成功"
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


    }
}
