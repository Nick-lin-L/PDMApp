using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Attributes;
using PDMApp.Dtos.SPEC;
using PDMApp.Models;
using PDMApp.Parameters.SPEC;
using PDMApp.Service.Basic;
using PDMApp.Service.SPEC;
using PDMApp.Utils;
using PDMApp.Utils.BasicProgram;
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


        // 0. Pageload 下拉查詢列表
        /// <summary>
        /// 頁面初始化傳入的參數，與下拉資料
        /// </summary>
        /// <param name="value">傳入的參數物件，用於判斷是否需要加載特定的初始資料。</param>
        /// <returns>回傳一個包含初始數據的 <see cref="APIStatusResponse{IDictionary}"/> 格式。</returns>
        [ProducesResponseType(typeof(APIStatusResponse<IDictionary<string, object>>), 200)]
        [ProducesResponseType(typeof(object), 500)]
        [HttpPost("initial")]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> GetInitial([FromBody] CustomerInitialParameter value)
        {
            try
            {
                /*{
                    var queryInit = await QueryHelper.QueryCustomerInit(_pcms_Pdm_TestContext, value);
                    return APIResponseHelper.HandleDynamicMultiPageResponse(queryInit);
                }*/
                // 創建字典來儲存查詢結果
                var resultData = new Dictionary<string, object>();

                // 依序執行查詢，確保每次只有一個查詢在執行
                resultData["BrandCombo"] = await QueryHelper.QueryBrand(_pcms_Pdm_TestContext, value).ToListAsync();
                resultData["StageCombo"] = await QueryHelper.QueryStage(_pcms_Pdm_TestContext, value).ToListAsync();
                resultData["DevelopmentNoCombo"] = await QueryHelper.QueryDevelopmentNo(_pcms_Pdm_TestContext);
                resultData["DevelopmentColorNoCombo"] = await QueryHelper.QueryDevelopmentColorNo(_pcms_Pdm_TestContext);

                // 封裝結果並回傳
                return APIResponseHelper.HandleDynamicMultiPageResponse(resultData);
            }
            catch (Exception ex)
            {
                return new ObjectResult(APIResponseHelper.HandleApiError<object>(
                    errorCode: "10001",
                    message: $"查詢過程中發生錯誤: {ex.Message}",
                    data: null
                ));
            }
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

        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("import-details")]
        public async Task<ActionResult<APIStatusResponse<List<plm_spec_item>>>> ImportDetails([FromBody] CustomerImportParameter request)
        {
            try
            {
                // 取得當前登入者資訊
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString();
                var name = currentUser.Name?.ToString();

                // 呼叫 Service 層的匯入方法
                var (success, message) = await CustomerQueryService.CustomerImportDetailAsync(
                    _pcms_Pdm_TestContext,
                    request.UIParameter,
                    request.ExcelParameter,
                    pccuid,
                    name
                );

                if (!success)
                {
                    return APIResponseHelper.HandleApiError<List<plm_spec_item>>(
                        errorCode: "50002",
                        message: message,
                        data: null
                    );
                }

                return APIResponseHelper.GenerateApiResponse<List<plm_spec_item>>(
                    "OK",
                    "Data has been saved successfully.",
                    null
                );
            }
            catch (Exception ex)
            {
                var fullError = ex.InnerException?.Message ?? ex.Message;
                return APIResponseHelper.HandleApiError<List<plm_spec_item>>(
                    errorCode: "50002",
                    message: $"Data import failed: {ex.Message}",
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
