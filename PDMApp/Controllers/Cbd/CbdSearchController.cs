using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PDMApp.Parameters.PGTSPEC;
using PDMApp.Utils;
using MiniExcelLibs;
using System.IO;
using MiniExcelLibs.OpenXml;
using MoreLinq;
using PDMApp.Extensions;
namespace PDMApp.Controllers.Cbd
{
    [ApiController]
    [Route("api/v1/cbd/[controller]/[action]")]
    public class CbdSearchController : ControllerBase
    {
        private readonly ILogger<CbdSearchController> _logger;
        private readonly Service.IComboService _icomboService;
        private readonly Service.Cbd.ICbdQueryService _icbdqueryService;
        public CbdSearchController(
                                  ILogger<CbdSearchController> logger,
                                  Service.IComboService icomboService,
                                  Service.Cbd.ICbdQueryService icbdqueryService)
        {
            _logger = logger;
            _icomboService = icomboService;
            _icbdqueryService = icbdqueryService;
        }
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> Initial(Parameters.Cbd.CbdSearchParameter.InitialParameter value)
        {
            var response = new APIStatusResponse<object>();
            try
            {

                var resultData = new Dictionary<string, object>();

                resultData["BrandCombo"] = await _icomboService.BrandNo(value.DevFactoryNo);
                resultData["ProductLineTypeCombo"] = await _icomboService.ProductLineType(value.DevFactoryNo);
                resultData["MaterialCombo"] = await _icomboService.Material();
                resultData["ColorsCombo"] = await _icomboService.Colors();
                resultData["SupplierCombo"] = await _icomboService.Supplier();
                resultData["StageCombo"] = await _icomboService.Stage();
                resultData["SeasonCombo"] = await _icomboService.Season(value.DevFactoryNo);
                resultData["DevelopmentNoCombo"] = await _icomboService.DevelopmentNo();
                // 封裝結果並回傳
                return APIResponseHelper.HandleDynamicMultiPageResponse(resultData);
            }
            catch (Exception e)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = e.Message,
                    Data = ""
                });
            }
        }
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<Utils.PagedResult<Dtos.Cbd.CbdSearchDto.QueryDto>>>> Query(Parameters.Cbd.CbdSearchParameter.QueryParameter parameter)
        {
            try
            {
                //至少需輸入3個條件
                if (!parameter.ValidationParameter(3))
                {
                    throw new Exception("查詢條件不可以都為空");
                }
                var query = _icbdqueryService.CbdSearch(parameter);
                var data = await query.ToPagedResultAsync(parameter.Pagination.PageNumber, parameter.Pagination.PageSize);
                return APIResponseHelper.HandlePagedApiResponse(data);
            }
            catch (Exception e)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = e.Message,
                    Details = ""
                });

            }
        }

        [HttpPost]
        public ActionResult<Utils.APIStatusResponse<IEnumerable<Dtos.ExportFileResponseDto>>> Export(Parameters.Cbd.CbdSearchParameter.QueryParameter parameter)
        {

            try
            {
                //至少需輸入3個條件
                if (!parameter.ValidationParameter(3))
                {
                    throw new Exception("查詢條件不可以都為空");
                }
                var data = _icbdqueryService.ExcelExport(parameter);
                var count = data.Count();
                if (count >= 5000)
                {
                    throw new Exception("資料超過五千筆，請增加查詢條件");
                }
                OpenXmlConfiguration configuration = new OpenXmlConfiguration()
                {
                    EnableWriteNullValueCell = false, // Default value.
                    IgnoreTemplateParameterMissing = false,
                    EnableSharedStringCache = true,
                    BufferSize = 8192 * 4
                };

                MemoryStream memoryStream = new MemoryStream();
                var value = new Dictionary<string, object>()
                {
                    ["ExcelData"] = data
                };
                // var mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                var fileName = "cbddata.xlsx";
                fileName = Uri.EscapeDataString(fileName);
                Response.Headers.Add("Content-Disposition", $"attachment; filename*=UTF-8''{fileName}");

                memoryStream.SaveAsByTemplate(@"ExportedFiles\CbdExcelTemplate.xlsx", value, configuration: configuration);
                memoryStream.Seek(0, SeekOrigin.Begin);
                string base64File = Convert.ToBase64String(memoryStream.ToArray());
                var response = new Dtos.ExportFileResponseDto
                {
                    FileName = fileName,
                    FileContent = base64File
                };

                return Utils.APIResponseHelper.HandleApiResponse(new[] { response }, "OK", "");
                // return File(memoryStream, mimeType, fileName);
            }
            catch (Exception e)
            {
                var response = new APIStatusResponse<object>();

                response.Message = e.Message;
                response.ErrorCode = "21001";
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<object>>> CbdData([FromBody] Parameters.Cbd.CbdQueryParameter.QueryData parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                response.Data = await _icbdqueryService.GetCbdDataByID(parameter.DataMId);
                response.ErrorCode = "OK";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.ErrorCode = "21001";
            }
            return response;
        }
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<Utils.PagedResult<Dtos.Cbd.CbdSearchDto.DetailsDto>>>> CbdDetails([FromBody] Parameters.Cbd.CbdSearchParameter.QueryDetailParameter parameter)
        {
            try
            {
                var query = _icbdqueryService.CbdSearchDetail(parameter);
                var data = await query.ToPagedResultAsync(parameter.Pagination.PageNumber, parameter.Pagination.PageSize);
                return APIResponseHelper.HandlePagedApiResponse(data);
            }
            catch (Exception e)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "21001",
                    Message = e.Message,
                    Details = ""
                });
            }
        }

    }
}