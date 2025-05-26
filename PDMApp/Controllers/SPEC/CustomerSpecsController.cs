using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Attributes;
using PDMApp.Dtos.SPEC;
using PDMApp.Models;
using PDMApp.Parameters.SPEC;
using PDMApp.Service.Basic;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers.SPEC
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "PDMToken")]
    public class CustomerSpecsController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;
        private readonly ICurrentUserService _currentUserService;

        public CustomerSpecsController(
            pcms_pdm_testContext pcms_Pdm_testContext,
            ICurrentUserService currentUserService)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
            _currentUserService = currentUserService;
        }


        // GET: api/<CustomerSpecsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerSpecsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerSpecsController>
        // 以下方法為綜合應用「泛型、非同步處理、回傳值與參數不同」
        /// <summary>
        /// 查詢Customer
        /// </summary>
        /// <param name="value">CustomerSpecsSearchParameter</param>
        /// <returns>CustomerSearchDto</returns>
        [HttpPost]
        //[RequirePermission(2, "READ")]
        public async Task<ActionResult<APIStatusResponse<PagedResult<CustomerSearchDto>>>> Post([FromBody] CustomerSpecsSearchParameter value)
        {
            // 檢查是否至少有一個搜尋條件
            if (!CommonHelper.ValidateSearchParams(value))
            {
                return APIResponseHelper.HandleApiError<PagedResult<CustomerSearchDto>>(
                    errorCode: "40001",
                    message: "請至少輸入一個搜尋條件",
                    data: null
                );
            }

            try
            {
                var pagedResult = await QueryHelper.QueryCustomer(_pcms_Pdm_TestContext, value)
                                                   .Distinct()
                                                   .ToPagedResultAsync(value.Pagination.PageNumber, value.Pagination.PageSize);


                return APIResponseHelper.HandlePagedApiResponse(pagedResult);
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<PagedResult<CustomerSearchDto>>(
                    errorCode: "50001",
                    message: $"查詢過程中發生錯誤: {ex.Message}",
                    data: null
                );
            }
        }
        
        // PUT api/<CustomerSpecsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerSpecsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
