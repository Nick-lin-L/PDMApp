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

        /*
        [HttpPost("import-detail")]
        public async Task<ActionResult<APIStatusResponse<List<plm_product_item>>>> ImportHeads([FromBody] List<CustomerImportParameter> parameters)
        {
            try
            {
                // 1. 驗證所有資料
                var validationResults = new List<(int Index, string Error)>();

                for (int i = 0; i < parameters.Count; i++)
                {
                    var param = parameters[i];

                    // 檢查 DevelopmentNo
                    if (string.IsNullOrEmpty(param.Development_No))
                    {
                        validationResults.Add((i + 1, "DevelopmentNo 不能為空"));
                        continue;
                    }

                    // 檢查 Stage
                    var stageExists = await _pcms_Pdm_TestContext.pdm_namevalue_new
                        .AnyAsync(x => x.group_key == "stage" && x.text == param.Stage);

                    if (!stageExists)
                    {
                        validationResults.Add((i + 1, $"Stage '{param.Stage}' 不存在於系統中"));
                    }
                }

                // 如果有任何驗證錯誤，返回所有錯誤
                if (validationResults.Any())
                {
                    var errorMessage = string.Join("\n", validationResults.Select(x => $"第 {x.Index} 行: {x.Error}"));
                    return APIResponseHelper.HandleApiError<List<plm_product_item>>(
                        errorCode: "50003",
                        message: $"資料驗證失敗:\n{errorMessage}",
                        data: null
                    );
                }

                // 2. 處理所有資料
                var results = new List<plm_product_item>();
                foreach (var param in parameters)
                {
                    // 從 DevelopmentNo 解析 Season
                    string season = param.Development_No.Split('-')[0];

                    // 檢查是否已存在相同 DevelopmentNo 的記錄
                    var existingProduct = await _pcms_Pdm_TestContext.plm_product_head
                        .FirstOrDefaultAsync(x => x.development_no == param.Development_No);

                    var product = existingProduct ?? new plm_product_head();

                    // 如果是新增記錄，生成新的 UUID
                    if (existingProduct == null)
                    {
                        product.product_m_id = GenerateUUID();
                    }


                    // 更新或設置產品資料
                    product.active = param.Active ? "true" : "false";  // 將 bool 轉換為 "true"/"false"
                    product.assigned_agents = param.Assigned_Agents;
                    product.working_name = param.Working_Name;
                    product.series = param.Series;
                    product.series_with_generation = param.Series_With_Generation;
                    product.development_no = param.Development_No;
                    product.season = season;
                    product.item_initial_season = param.Item_Initial_Season;
                    product.item_mode = param.Item_Mode;
                    product.item_mode_sub_type = param.Item_Mode_Sub_Type;
                    product.article_description = param.Article_Description;
                    product.gender = param.Gender;
                    product.kids_type = param.Kids_Type;
                    product.width = param.Width;
                    product.pack = param.Pack;
                    product.lp01_season_forecast = int.TryParse(param.LP01_Factory_Season_Forecast, out int lp01Season) ? lp01Season : null;
                    product.lp02_season_forecast = param.LP02_Factory_Season_Forecast;
                    product.lp03_season_forecast = param.LP03_Factory_Season_Forecast;
                    product.lp01_yearly_forecast = int.TryParse(param.LP01_Factory_Yearly_Forecast, out int lp01Yearly) ? lp01Yearly : null;
                    product.lp02_yearly_forecast = param.LP02_Factory_Yearly_Forecast;
                    product.lp03_yearly_forecast = param.LP03_Factory_Yearly_Forecast;
                    product.account_code = param.Account_Code;
                    product.account_name = param.Account_Name;
                    product.account_exclusivity = param.Account_Exclusivity;
                    product.region_exclusivity = param.Region_Exclusivity;
                    product.regional_approval = param.Regional_SMU_Team_Approval;
                    product.stage = param.Stage;
                    product.latest_bom = param.Latest_BOM;
                    product.mold_set = param.Mold_Set;
                    product.last1 = param.Last1;
                    product.last2 = param.Last2;
                    product.last3 = param.Last3;
                    product.sizemap = param.SizeMap;
                    product.lasting = param.Lasting;
                    product.heel_height = param.Heel_Height;
                    product.size_range = param.Size_Range;
                    product.size_run = param.Size_Run;
                    product.default_size = param.Default_Size;
                    product.pm_name = param.PM_Name;
                    product.developer = param.Developer;
                    product.designer = param.Designer;
                    product.developer_remarks = param.Developer_Remarks;
                    product.global_rid = ConvertToYYYYMMDD(param.Global_RID);
                    product.earliest_rid = ConvertToYYYYMMDD(param.Earliest_RID);
                    product.production_start_month = ConvertToYYYYMMDD(param.Production_Start_Month);
                    product.tdm_date = ConvertToYYYYMMDD(param.TDM_Date);
                    product.sfm_date = ConvertToYYYYMMDD(param.SFM_Date);
                    product.production_lead_time = param.Production_Lead_Time;
                    product.production_approval = param.Production_Approval;
                    product.production_approval_date = param.Production_Approval_Date;
                    product.moq_per_item = param.MOQ_Per_Item;
                    product.sampling_factory = param.Sampling_Factory;
                    product.main_factory = param.Main_Factory;
                    product.sub_factory = param.Sub_Factory;
                    product.sub_factory2 = param.Sub_Factory2;
                    product.original_factory = param.Original_Factory;
                    product.previous_factory = param.Previous_Factory;
                    product.transfer_to = param.Transfer_To;
                    product.sourcing_remarks = param.Sourcing_Remarks;
                    product.upper_material = param.Upper_Material;
                    product.upper_material1 = param.Upper_Material1;
                    product.upper_material2 = param.Upper_Material2;
                    product.upper_material3 = param.Upper_Material3;
                    product.upper_material4 = param.Upper_Material4;
                    product.upper_material5 = param.Upper_Material5;
                    product.sole_material1 = param.Sole_Material1;
                    product.sole_material2 = param.Sole_Material2;
                    product.sole_material3 = param.Sole_Material3;
                    product.cleats_type = param.Cleats_Type;
                    product.cleats_material = param.Cleats_Material;
                    product.cleats_replaceable_fixed = param.Cleats_Replaceable_Fixed;
                    product.domain = param.Domain;
                    product.brand = param.Brand;
                    product.category1 = param.Category1;
                    product.category2 = param.Category2;
                    product.category3 = param.Category3;
                    product.category4 = param.Category4;
                    product.silo1 = param.Silo1;
                    product.silo2 = param.Silo2;
                    product.ls_category = param.LS_Category;
                    product.product_line_type = param.Product_Line_Type;
                    product.distribution_tier = param.Distribution_Tier;
                    product.price_tier = param.Price_Tier;
                    product.global_srp = decimal.TryParse(param.Global_SRP, out decimal globalSrp) ? globalSrp : null;
                    product.key_item = param.Key_Item;
                    product.target_of_colors = param.Target_Of_Colors;
                    product.jump_to_merch_plan = param.Jump_To_Merch_Plan;
                    product.ref_item = param.Ref_Item;
                    product.ref_item_mold_set = param.Ref_Item_Mold_Set;
                    product.md_remarks = param.MD_Remarks;
                    product.modified = param.Modified ?? DateTime.Now;
                    product.modified_by = param.Modified_By;
                    product.pushed_development_time = ConvertToYYYYMMDD(param.Pushed_Development_Time);
                    product.item_trading_code = param.Item_Trading_Code;
                    product.global_id = param.Global_ID;
                    product.sort_order = param.Sort_Order;
                    product.factory = param.Login_Factory; // 使用當前登入廠別

                    if (existingProduct == null)
                    {
                        product.add_date = DateTime.Now;
                        product.update_date = DateTime.Now;
                        await _pcms_Pdm_TestContext.plm_product_head.AddAsync(product);
                    }
                    else
                    {
                        product.update_date = DateTime.Now;
                    }

                    //results.Add(product);
                }

                await _pcms_Pdm_TestContext.SaveChangesAsync();

                return APIResponseHelper.GenerateApiResponse<List<plm_product_head>>(
                    "OK",
                    "Data has been saved successfully.",
                    results
                );
            }
            catch (Exception ex)
            {
                var fullError = ex.InnerException?.Message ?? ex.Message;
                return APIResponseHelper.HandleApiError<List<plm_product_item>>(
                    errorCode: "50002",
                    message: $"Data import failed: {ex.Message}",
                    data: null
                );
            }
        }
        */


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
