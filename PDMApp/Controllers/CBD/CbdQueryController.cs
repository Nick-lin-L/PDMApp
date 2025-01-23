using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PDMApp.Dtos.Cbd;
using PDMApp.Models;
using PDMApp.Parameters;
using PDMApp.Parameters.Cbd;
using PDMApp.Utils;

namespace PDMApp.Controllers.CBD
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CbdQueryController : ControllerBase
    {
        private readonly ILogger<CbdQueryController> _logger;
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;
        public CbdQueryController(pcms_pdm_testContext pcms_Pdm_testContext, ILogger<CbdQueryController> logger)
        {
            _logger = logger;
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
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
                response.Message = "OK";
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
        public async Task<ActionResult<APIStatusResponse<object>>> colors()
        {
            var response = new APIStatusResponse<object>();
            try
            {

                response.Data = await _pcms_Pdm_TestContext.plm_product_item.Where(x => !string.IsNullOrWhiteSpace(x.development_color_no)).
                                                                             Select(x => new { key = x.development_color_no, displayvalue = @$"{x.development_color_no}[{x.color_code}]" }).
                                                                             Distinct().
                                                                             ToArrayAsync();
                response.Message = "OK";
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
        public async Task<ActionResult<APIStatusResponse<object>>> colors(string Parameter)
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
        public async Task<ActionResult<APIStatusResponse<object>>> stage()
        {
            var response = new APIStatusResponse<object>();
            try
            {

                response.Data = await _pcms_Pdm_TestContext.pdm_namevalue.Where(x => x.group_key == "stage").
                                                                             Select(x => new { key = x.value_desc, displayvalue = @$"{x.value_desc}[{x.text}]" }).
                                                                             Distinct().
                                                                             ToArrayAsync();
                response.Message = "OK";
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
        public async Task<ActionResult<APIStatusResponse<object>>> stage(string Parameter)
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
        public async Task<ActionResult<APIStatusResponse<Utils.PagedResult<CbdQueryDto>>>> query(CbdQueryParameter parameter)
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
                            select new CbdQueryDto
                            {
                                Data_m_id = ch.data_m_id,
                                Product_m_id = ph.product_m_id,
                                Product_d_id = ch.product_d_id,
                                Itemtrading_code = ph.item_trading_code,
                                Development_no = ph.development_no,
                                Development_color_no = pi.development_color_no,
                                Stage = ch.stage,
                                Stage_display = (from nv in _pcms_Pdm_TestContext.pdm_namevalue
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
                                Cbd_update_date = ch.cbd_update_date == null ? "" : ch.update_date.ToString(),
                                Update_user = ch.update_user,
                                Update_date = ch.update_date == null ? "" : ch.update_date.ToString(),
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

    }
}