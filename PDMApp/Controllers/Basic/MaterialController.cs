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


    }
}
