using Microsoft.AspNetCore.Mvc;
using PDMApp.Dtos.Basic;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Controllers.Basic
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShoeShapeController
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public ShoeShapeController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }

        [HttpPost("heads")]
        public async Task<ActionResult<APIStatusResponse<PagedResult<ShoeShapeDto>>>> Post([FromBody] ShoeShapeParameter value)
        {
            try
            {
                // Step 1：查詢 + 分頁（EF 查 DB）
                var pagedResult = await QueryHelper.QueryShoeShapeHead(_pcms_Pdm_TestContext, value)
                                                   .Distinct()
                                                   .ToPagedResultAsync(value.Pagination.PageNumber, value.Pagination.PageSize);



                return APIResponseHelper.HandlePagedApiResponse(pagedResult);
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<PagedResult<ShoeShapeDto>>(
                    errorCode: "50001",
                    message: $"權限查詢過程中發生錯誤: {ex.Message}",
                    data: null
                );
            }
        }

        [HttpPost("details")]
        public async Task<ActionResult<APIStatusResponse<PagedResult<ShoeShapeDetailsDto>>>> ShoeShapeDetails([FromBody] ShoeShapeDetailParameter value)
        {
            try
            {
                // Step 1：查詢 + 分頁（EF 查 DB）
                var pagedResult = await QueryHelper.QueryShoeShapeDetails(_pcms_Pdm_TestContext, value)
                                                   .Distinct()
                                                   .ToPagedResultAsync(value.Pagination.PageNumber, value.Pagination.PageSize);
                return APIResponseHelper.HandlePagedApiResponse(pagedResult);
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<PagedResult<ShoeShapeDetailsDto>>(
                    errorCode: "50001",
                    message: $"權限查詢過程中發生錯誤: {ex.Message}",
                    data: null
                );
            }
        }
    }
}
