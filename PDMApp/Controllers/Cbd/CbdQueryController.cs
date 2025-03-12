using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using PDMApp.Models;
using PDMApp.Parameters.Cbd;
using PDMApp.Utils;
using PDMApp.Dtos.Cbd;
using PDMApp.Parameters.PGTSPEC;
using System.Globalization;

namespace PDMApp.Controllers.Cbd
{
    [Route("api/v1/cbd/[controller]/[action]")]
    [ApiController]
    public class CbdQueryController : ControllerBase
    {
        private readonly ILogger<CbdQueryController> _logger;
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;
        private readonly Service.IComboService _icomboService;
        private readonly Service.Cbd.ICbdQueryService _icbdqueryService;
        public CbdQueryController(pcms_pdm_testContext pcms_Pdm_testContext,
                                  ILogger<CbdQueryController> logger,
                                  Service.IComboService icomboService,
                                  Service.Cbd.ICbdQueryService icbdqueryService)
        {
            _logger = logger;
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
            _icomboService = icomboService;
            _icbdqueryService = icbdqueryService;
        }
        [HttpGet]
        public async Task<ActionResult<APIStatusResponse<object>>> Development_nos()
        {
            var response = new APIStatusResponse<object>();
            try
            {

                response.Data = await _pcms_Pdm_TestContext.plm_product_head.Where(x => !string.IsNullOrWhiteSpace(x.development_no)).
                                                                             Select(x => x.development_no).
                                                                             Distinct().
                                                                             ToArrayAsync();
                response.ErrorCode = "OK";
                return response;
            }
            catch (Exception e)
            {
                var Data = new Dictionary<string, object>();
                response.ErrorCode = "20001";
                response.Message = e.Message;
                return response;
            }
        }
        [HttpGet("{Parameter}")]
        public async Task<ActionResult<APIStatusResponse<object>>> Development_nos(string Parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                response.Data = await _pcms_Pdm_TestContext.plm_product_head.Where(x => (x.development_no ?? "").StartsWith(Parameter)).
                                                                             Select(x => x.development_no).
                                                                             Distinct().
                                                                             ToArrayAsync();
                return response;
            }
            catch (Exception e)
            {
                var Data = new Dictionary<string, object>();
                response.ErrorCode = "20001";
                response.Message = e.Message;
                return response;
            }
        }

        [HttpGet]
        public async Task<ActionResult<APIStatusResponse<object>>> Colors()
        {
            var response = new APIStatusResponse<object>();
            try
            {

                response.Data = await _pcms_Pdm_TestContext.plm_product_item.Where(x => !string.IsNullOrWhiteSpace(x.development_color_no)).
                                                                             Select(x => new { key = x.development_color_no, displayvalue = @$"{x.development_color_no}[{x.color_code}]" }).
                                                                             Distinct().
                                                                             ToArrayAsync();
                response.Message = "";
                response.ErrorCode = "OK";
                return response;
            }
            catch (Exception e)
            {
                var Data = new Dictionary<string, object>();
                response.ErrorCode = "20001";
                response.Message = e.Message;
                return response;
            }
        }
        [HttpGet("{Parameter}")]
        public async Task<ActionResult<APIStatusResponse<object>>> Colors(string Parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                response.Data = await _pcms_Pdm_TestContext.plm_product_item.Where(x => (x.development_color_no ?? "").StartsWith(Parameter)).
                                                                             Select(x => new { key = x.development_color_no, displayvalue = @$"{x.development_color_no}[{x.color_code}]" }).
                                                                             Distinct().
                                                                             ToArrayAsync();
                return response;
            }
            catch (Exception e)
            {
                var Data = new Dictionary<string, object>();
                response.ErrorCode = "20001";
                response.Message = e.Message;
                return response;
            }
        }

        [HttpGet]
        public async Task<ActionResult<APIStatusResponse<object>>> Stage()
        {
            var response = new APIStatusResponse<object>();
            try
            {

                response.Data = await _pcms_Pdm_TestContext.pdm_namevalue.Where(x => x.group_key == "stage").
                                                                             Select(x => new { key = x.value_desc, displayvalue = @$"{x.value_desc}[{x.text}]" }).
                                                                             Distinct().
                                                                             ToArrayAsync();
                response.Message = "";
                response.ErrorCode = "OK";
                return response;
            }
            catch (Exception e)
            {
                var Data = new Dictionary<string, object>();
                response.ErrorCode = "20001";
                response.Message = e.Message;
                return response;
            }
        }
        [HttpGet("{Parameter}")]
        public async Task<ActionResult<APIStatusResponse<object>>> Stage(string Parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                var data = await _pcms_Pdm_TestContext.pdm_namevalue.Where(x => x.group_key == "stage" && (x.value_desc ?? "").StartsWith(Parameter)).
                                                                        Select(x => new { key = x.value_desc, displayvalue = @$"{x.value_desc}[{x.text}]" }).
                                                                        Distinct().
                                                                        ToArrayAsync();
                response.Data = data;
                if (data.Length == 0)
                {
                    response.Message = "No Data";
                }
                else
                {
                    response.Message = "OK";
                }
                return response;
            }
            catch (Exception e)
            {
                var Data = new Dictionary<string, object>();
                response.ErrorCode = "20001";
                response.Message = e.Message;
                return response;
            }
        }
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<Utils.PagedResult<Dtos.Cbd.CbdQueryDto.QueryDto>>>> Query(Parameters.Cbd.CbdQueryParameter.CbdQuery parameter)
        {
            var response = new APIStatusResponse<Utils.PagedResult<object>>();
            try
            {
                var query = from ph in _pcms_Pdm_TestContext.plm_product_head
                            join pi in _pcms_Pdm_TestContext.plm_product_item
                            on ph.product_m_id equals pi.product_m_id
                            join ch in _pcms_Pdm_TestContext.plm_cbd_head
                            on pi.product_d_id equals ch.product_d_id
                            orderby ph.development_no ascending, ch.ver ascending
                            select new CbdQueryDto.QueryDto
                            {
                                Data_m_id = ch.data_m_id,
                                Product_m_id = ph.product_m_id,
                                Product_d_id = ch.product_d_id,
                                Itemtrading_code = ph.item_trading_code,
                                Development_no = ph.development_no,
                                Development_color_no = pi.development_color_no,
                                // Stage = ch.stage,
                                Stage = (from nv in _pcms_Pdm_TestContext.pdm_namevalue
                                         where nv.group_key == "stage" && nv.value_desc == ch.stage
                                         orderby nv.value_desc
                                         select nv.text
                                         ).FirstOrDefault(),
                                Working_name = ph.working_name,
                                Color_code = pi.color_code,
                                Colorway = pi.colorway,
                                Bom = ch.bom,
                                Colors = ch.colors,
                                Vssver = ch.vssver,
                                Ver = ch.ver,
                                Cbd_update_user = ch.cbd_update_user,
                                Cbd_update_date = ch.cbd_update_date == null ? "" : ch.update_date.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                                Update_user = ch.update_user,
                                Update_date = ch.update_date == null ? "" : ch.update_date.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                            };
                if (!string.IsNullOrEmpty(parameter.color_code))
                {
                    query = query.Where(x => x.Color_code.Contains(parameter.color_code));
                }
                if (!string.IsNullOrEmpty(parameter.development_no))
                {
                    query = query.Where(x => x.Development_no.Contains(parameter.development_no));
                }
                if (!string.IsNullOrEmpty(parameter.stage))
                {
                    query = query.Where(x => x.Stage == parameter.stage);
                }
                if (!string.IsNullOrEmpty(parameter.working_name))
                {
                    query = query.Where(x => x.Working_name.Contains(parameter.working_name));
                }
                if (!string.IsNullOrEmpty(parameter.colorway))
                {
                    query = query.Where(x => x.Colorway.Contains(parameter.colorway));
                }
                if (!string.IsNullOrEmpty(parameter.colors))
                {
                    query = query.Where(x => x.Colors.Contains(parameter.colors));
                }
                if (!string.IsNullOrEmpty(parameter.itemtrading_code))
                {
                    query = query.Where(x => x.Itemtrading_code.Contains(parameter.itemtrading_code));
                }
                if (!string.IsNullOrEmpty(parameter.color_code))
                {
                    query = query.Where(x => x.Color_code.Contains(parameter.color_code));
                }
                var data = await query.ToPagedResultAsync(parameter.Pagination.PageNumber, parameter.Pagination.PageSize);
                return APIResponseHelper.HandlePagedApiResponse(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "20001",
                    Message = "ServerError",
                    Details = e.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<object>>> CbdData([FromBody] CbdQueryParameter.QueryData parameter)
        {
            var response = new APIStatusResponse<object>();
            try
            {

                response.Data = await _icbdqueryService.GetCbdDataByID(parameter.DataMId);
                response.ErrorCode = "OK";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.Message = e.Message;
                response.ErrorCode = "21001";
            }
            return response;
        }
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> Initial(DevelopmentFactoryParameter value)
        {
            var response = new APIStatusResponse<object>();
            try
            {

                var resultData = new Dictionary<string, object>();

                // 依序執行查詢，確保每次只有一個查詢在執行 { Text: "ASICS" Value:"ASICS" }

                resultData["BrandCombo"] = new List<object> { new { Text = "ASICS", Value = "ASICS" } };
                resultData["StageCombo"] = await _icomboService.Stage();
                resultData["DevelopmentNoCombo"] = await _icomboService.DevelopmentNo("ASICS");
                resultData["DevelopmentColorNoCombo"] = await _icomboService.ColorNo();

                // 封裝結果並回傳
                return APIResponseHelper.HandleDynamicMultiPageResponse(resultData);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "Server_ERROR",
                    Message = "ServerError",
                    Details = e.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<object>>> Import(CbdQueryParameter.CbdExcel value)
        {
            var response = new APIStatusResponse<object>();
            try
            {
                response.Data = await _icbdqueryService.ExcelImport(value);
                response.Message = "";
                response.ErrorCode = "OK";
                // response.Data = Data;

            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is PostgresException postgresEx)
                {
                    // Data.Add("SqlState", postgresEx.SqlState);
                    // Data.Add("MessageText", postgresEx.MessageText);
                    // Data.Add("Detail", postgresEx.Detail);
                    // Data.Add("TableName", postgresEx.TableName);
                    // Data.Add("Column", postgresEx.ColumnName);
                    response.ErrorCode = "20001";
                    response.Message = ex.Message;
                    // response.Data = Data;
                }
                else
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    response.ErrorCode = "20001";
                    response.Message = ex.Message;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"檢核失敗: {e.Message}");
                response.ErrorCode = "20002";
                response.Message = e.Message;
            }

            return Ok(response);
        }

    }
}