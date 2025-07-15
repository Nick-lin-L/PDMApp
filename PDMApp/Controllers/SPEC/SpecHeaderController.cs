using Dtos.SPEC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.SPEC;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Controllers.SPEC
{
    [Route("api/v1/SPEC/[controller]")]
    [ApiController]
    public class SpecHeaderController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public SpecHeaderController(pcms_pdm_testContext pcms_Pdm_TestContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_TestContext;
        }

        // POST api/v1/SPEC/<SpecHeaderController>
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<PagedResult<SPECHeaderDto>>>> Post([FromBody] SPECSearchParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // **將篩選條件直接傳遞到 QuerySpecHead**
                var (isSuccess, message, query) = await Service.SPEC.SPECQueryHelper.QuerySpecHead(_pcms_Pdm_TestContext, value);

                // 檢查是否成功
                if (!isSuccess)
                {
                    return StatusCode(200, new
                    {
                        ErrorCode = "BUSINESS_ERROR",
                        Message = message
                    });
                }

                // 排序
                query = query
                    .OrderBy(ph => ph.DevelopmentNo)
                    .ThenBy(ph => ph.DevelopmentColorNo)
                    .ThenBy(ph => ph.Stage);

                // 分頁
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


        // POST api/v1/SPEC/SpecHeader/initial
        [HttpPost("initial")]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> GetComboData([FromBody] DevelopmentFactoryParameter? value)
        {
            try
            {
                // 創建字典來儲存查詢結果
                var resultData = new Dictionary<string, object>();

                // 依序執行查詢，確保每次只有一個查詢在執行
                resultData["BrandCombo"] = await Service.SPEC.SPECQueryHelper.QueryBrand(_pcms_Pdm_TestContext, value).ToListAsync();
                resultData["StageCombo"] = await Service.SPEC.SPECQueryHelper.QueryStage(_pcms_Pdm_TestContext, value).ToListAsync();
                resultData["DevelopmentNoCombo"] = await Service.SPEC.SPECQueryHelper.QueryDevelopmentNo(_pcms_Pdm_TestContext);
                resultData["DevelopmentColorNoCombo"] = await Service.SPEC.SPECQueryHelper.QueryDevelopmentColorNo(_pcms_Pdm_TestContext);
                resultData["EntryModeCombo"] = await Service.SPEC.SPECQueryHelper.QueryEntryMode(_pcms_Pdm_TestContext, value).ToListAsync();
                resultData["SeasonCombo"] = await Service.SPEC.SPECQueryHelper.QuerySeason(_pcms_Pdm_TestContext, value).ToListAsync();

                // 封裝結果並回傳
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

    }
}
