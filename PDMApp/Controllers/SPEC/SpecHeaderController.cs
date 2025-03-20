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
                var query = Utils.SPEC.SPECQueryHelper.QuerySpecHead(_pcms_Pdm_TestContext, value);

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
                return StatusCode(500, new
                {
                    ErrorCode = "Server_ERROR",
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
                resultData["BrandCombo"] = await Utils.SPEC.SPECQueryHelper.QueryBrand(_pcms_Pdm_TestContext, value).ToListAsync();
                resultData["StageCombo"] = await Utils.SPEC.SPECQueryHelper.QueryStage(_pcms_Pdm_TestContext, value).ToListAsync();
                resultData["DevelopmentNoCombo"] = await Utils.SPEC.SPECQueryHelper.QueryDevelopmentNo(_pcms_Pdm_TestContext);
                resultData["DevelopmentColorNoCombo"] = await Utils.SPEC.SPECQueryHelper.QueryDevelopmentColorNo(_pcms_Pdm_TestContext);
                resultData["EntryModeCombo"] = await Utils.SPEC.SPECQueryHelper.QueryEntryMode(_pcms_Pdm_TestContext, value).ToListAsync();
                resultData["SeasonCombo"] = await Utils.SPEC.SPECQueryHelper.QuerySeason(_pcms_Pdm_TestContext, value).ToListAsync();

                // 加入 ErrorCode 和 Message
                resultData["ErrorCode"] = "OK";
                resultData["Message"] = "查詢成功";

                // 封裝結果並回傳
                return StatusCode(200, resultData);
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
