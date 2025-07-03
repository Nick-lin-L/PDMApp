
using Dtos.PGTSPEC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;
using PDMApp.Utils;
using PDMApp.Utils.BasicProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Controllers.PGTSPEC
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PGTSpecHeadController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public PGTSpecHeadController(pcms_pdm_testContext pcms_Pdm_TestContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_TestContext;
        }

        // POST api/<PGTSpecHeadController>
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<PagedResult<PGTSPECHeaderDto>>>> Post([FromBody] PGTSPECSearchParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // 取得當前登入者資訊
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString();  // 從 currentUser 取得 pccuid
                var nameEn = currentUser.NameEn?.ToString();  // 從 currentUser 取得 name_en

                // 當 value.Ver 為空時，預設為 "Latest Ver"
                bool latestVerOnly = string.IsNullOrWhiteSpace(value.Ver) || value.Ver == "Latest Ver";

                // 將篩選條件直接傳遞到 QuerySpecHead
                var (isSuccess, message, query) = await Service.PGTSPEC.PGTSPECQueryHelper.QuerySpecHead(_pcms_Pdm_TestContext, latestVerOnly, value, pccuid, nameEn);

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
                return StatusCode(500, new
                {
                    ErrorCode = "SERVER_ERROR",
                    Message = "ServerError",
                    Details = ex.Message
                });
            }
        }

        // POST api/v1/PGTSpecHead/CheckSpecExist
        [HttpPost("CheckSpecExist")]
        public async Task<ActionResult<APIStatusResponse<string>>> CheckSpecExist([FromBody] CheckSpecExistParameter value)
        {
            try
            {
                // 驗證必要欄位
                if (string.IsNullOrWhiteSpace(value.DevelopmentNo) ||
                    string.IsNullOrWhiteSpace(value.DevelopmentColorNo) ||
                    string.IsNullOrWhiteSpace(value.Stage))
                {
                    return StatusCode(200, new
                    {
                        ErrorCode = "BUSINESS_ERROR",
                        Message = "缺少必要欄位 DevelopmentNo / DevelopmentColorNo / Stage"
                    });
                }

                // 執行查詢判斷是否存在符合條件的資料
                var exists = await (from ph in _pcms_Pdm_TestContext.plm_product_head
                                    join pi in _pcms_Pdm_TestContext.plm_product_item on ph.product_m_id equals pi.product_m_id
                                    join sh in _pcms_Pdm_TestContext.pcg_spec_head on pi.product_d_id equals sh.product_d_id
                                    join n_stage in _pcms_Pdm_TestContext.pdm_namevalue_new on sh.stage_code equals n_stage.value_desc
                                    where n_stage.group_key == "stage"
                                       && ph.development_no == value.DevelopmentNo
                                       && pi.development_color_no == value.DevelopmentColorNo
                                       && n_stage.text == value.Stage
                                    select sh.spec_m_id).AnyAsync();

                if (exists)
                {
                    return StatusCode(200, new
                    {
                        ErrorCode = "SPEC_EXISTS",
                        Message = "該型體&階段已存在資料，是否要直接進版"
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
                    ErrorCode = "SERVER_ERROR",
                    Message = "ServerError",
                    Details = ex.Message
                });
            }
        }




        // POST api/v1/PGTSpecHead/InsertSpec
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("InsertSpec")]
        public async Task<ActionResult<APIStatusResponse<string>>> InsertSpec([FromBody] InsertSpecParameter value)
        {
            try
            {
                // 取得當前登入者資訊
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString();  // 從 currentUser 取得 pccuid
                var name = currentUser.Name?.ToString();  // 從 currentUser 取得 name

                var (isSuccess, message) = await Service.PGTSPEC.PGTSPECInsertHelper.InsertSpecAsync(_pcms_Pdm_TestContext, value, pccuid, name);

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

        // POST api/v1/PGTSpecHead/CopyToSpec
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("CopyToSpec")]
        public async Task<ActionResult<APIStatusResponse<string>>> CopyToSpec([FromBody] CopyToSpecParameter value)
        {
            try
            {
                // 取得當前登入者資訊
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString();  // 從 currentUser 取得 pccuid
                var name = currentUser.Name?.ToString();  // 從 currentUser 取得 name

                var (isSuccess, message) = await Service.PGTSPEC.PGTSPECCopyToHelper.CopyToSpecAsync(_pcms_Pdm_TestContext, value, pccuid, name);

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
                    ErrorCode = "SERVER_ERROR",
                    Message = "ServerError",
                    Details = ex.Message
                });
            }
        }



        // POST api/v1/PGTSpecHead/CheckoutSpec
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("CheckoutSpec")]
        public async Task<ActionResult<APIStatusResponse<PGTSPECHeaderDto>>> CheckoutSpec([FromBody] CheckoutSpecParameter value) // 修改回傳型別
        {
            try
            {
                // 取得當前登入者資訊
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString(); // 從 currentUser 取得 pccuid
                var name = currentUser.Name?.ToString();     // 從 currentUser 取得 name
                var nameEn = currentUser.NameEn?.ToString(); // 從 currentUser 取得 name_en

                var (isSuccess, message, specHeaderDto) = await Service.PGTSPEC.PGTSPECCheckoutHelper.CheckoutSpecAsync(_pcms_Pdm_TestContext, value, pccuid, name, nameEn);

                if (!isSuccess)
                {
                    return StatusCode(200, new APIStatusResponse<PGTSPECHeaderDto> // 使用泛型 APIStatusResponse
                    {
                        ErrorCode = "BUSINESS_ERROR",
                        Message = message,
                        Data = null // 失敗時 Data 為 null
                    });
                }

                return StatusCode(200, new APIStatusResponse<PGTSPECHeaderDto> // 成功時回傳 Data
                {
                    ErrorCode = "OK",
                    Message = "CHECKOUT 成功。",
                    Data = specHeaderDto // 回傳 Checkout 成功的 SPEC 資料
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIStatusResponse<PGTSPECHeaderDto> // 使用泛型 APIStatusResponse
                {
                    ErrorCode = "SERVER_ERROR",
                    Message = "ServerError",
                    Data = null // 錯誤時 Data 為 null
                });
            }
        }

        // POST api/v1/PGTSpecHead/CheckinSpec
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("CheckinSpec")]
        public async Task<ActionResult<APIStatusResponse<string>>> CheckinSpec([FromBody] CheckinSpecParameter value)
        {
            try
            {
                // 取得當前登入者資訊
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString();  // 從 currentUser 取得 pccuid
                var name = currentUser.Name?.ToString();  // 從 currentUser 取得 name
                var nameEn = currentUser.NameEn?.ToString();  // 從 currentUser 取得 name_en

                var (isSuccess, message) = await Service.PGTSPEC.PGTSPECCheckinHelper.CheckinSpecAsync(_pcms_Pdm_TestContext, value, pccuid, name, nameEn);

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

        // POST api/v1/PGTSpecHead/LockSpec
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("LockSpec")]
        public async Task<ActionResult<APIStatusResponse<string>>> LockSpec([FromBody] SpecLockParameter value)
        {
            try
            {
                // 取得當前登入者資訊
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString();  // 從 currentUser 取得 pccuid
                var name = currentUser.Name?.ToString();  // 從 currentUser 取得 name

                var (isSuccess, message) = await Service.PGTSPEC.PGTSPECLockHelper.LockSpecAsync(_pcms_Pdm_TestContext, value, isLock: true, pccuid, name);

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

        // POST api/v1/PGTSpecHead/UnlockSpec
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("UnlockSpec")]
        public async Task<ActionResult<APIStatusResponse<string>>> UnlockSpec([FromBody] SpecLockParameter value)
        {
            try
            {
                // 取得當前登入者資訊
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var pccuid = currentUser.Pccuid?.ToString();  // 從 currentUser 取得 pccuid
                var name = currentUser.Name?.ToString();  // 從 currentUser 取得 name

                var (isSuccess, message) = await Service.PGTSPEC.PGTSPECLockHelper.LockSpecAsync(_pcms_Pdm_TestContext, value, isLock: false, pccuid, name);

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

        // POST api/v1/PGTSpecHead/ComboData
        [HttpPost("ComboData")]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> GetComboData([FromBody] DevelopmentFactoryParameter? value)
        {
            try
            {
                // 創建字典來儲存查詢結果
                var resultData = new Dictionary<string, object>();

                // 依序執行查詢，確保每次只有一個查詢在執行
                resultData["BrandCombo"] = await Service.PGTSPEC.PGTSPECQueryHelper.QueryBrand(_pcms_Pdm_TestContext, value).ToListAsync();
                resultData["SpecSourceCombo"] = await Service.PGTSPEC.PGTSPECQueryHelper.QuerySpecSource(_pcms_Pdm_TestContext, value).ToListAsync();
                resultData["StageCombo"] = await Service.PGTSPEC.PGTSPECQueryHelper.QueryStage(_pcms_Pdm_TestContext, value).ToListAsync();
                resultData["DevelopmentNoCombo"] = await Service.PGTSPEC.PGTSPECQueryHelper.QueryDevelopmentNo(_pcms_Pdm_TestContext);
                resultData["DevelopmentColorNoCombo"] = await Service.PGTSPEC.PGTSPECQueryHelper.QueryDevelopmentColorNo(_pcms_Pdm_TestContext);
                resultData["MailToCombo"] = await Service.PGTSPEC.PGTSPECQueryHelper.QueryMailToCombo(_pcms_Pdm_TestContext, value);
                resultData["MailCcCombo"] = await Service.PGTSPEC.PGTSPECQueryHelper.QueryMailCcCombo(_pcms_Pdm_TestContext, value);

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


        // POST api/v1/PGTSpecHead/QueryMatm
        [HttpPost("QueryMatm")]
        public async Task<ActionResult<APIStatusResponse<List<MatmResultDto>>>> QueryMatm([FromBody] MatmSearchParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // 從 Service 層獲取 IQueryable<MatmResultDto>
                var (isSuccess, message, query) = await Service.PGTSPEC.PGTSPECQueryHelper.QueryMatmAsync(_pcms_Pdm_TestContext, value);

                if (!isSuccess)
                {
                    return StatusCode(200, new APIStatusResponse<List<MatmResultDto>>
                    {
                        ErrorCode = "BUSINESS_ERROR",
                        Message = message,
                        Data = null
                    });
                }

                // 將所有符合條件的原始數據從資料庫載入到記憶體
                var allMatchingMatmResults = await query.ToListAsync();

                // 在記憶體中進行分組和聚合
                var finalAggregatedResults = allMatchingMatmResults
                    .GroupBy(m => m.MatFullNm) // 以 MatFullNm 作為分組鍵
                    .Select(g => {
                        // 從組內獲取一個代表元素
                        var representativeItem = g.First();

                        return new MatmResultDto
                        {
                            // 聚合 SerpMatNo: 收集所有非空且不重複的 SerpMatNo，排序後用換行符連接
                            SerpMatNo = string.Join("\n", g.Where(x => !string.IsNullOrEmpty(x.SerpMatNo))
                                                              .Select(x => x.SerpMatNo)
                                                              .Distinct()
                                                              .OrderBy(s => s) // 確保順序一致
                                                              .ToList()),
                            // 聚合 MatNo : 收集所有非空且不重複的 MatNo ，排序後用換行符連接
                            MatNo = string.Join("\n", g.Where(x => !string.IsNullOrEmpty(x.MatNo))
                                                               .Select(x => x.MatNo)
                                                               .Distinct()
                                                               .OrderBy(s => s) // 確保順序一致
                                                               .ToList()),
                            // 其他欄位：從代表元素中取值。
                            // 注意：如果這些欄位在同一個 MatFullNm 組內有不同值，
                            // 這裡只會取第一個元素的值。
                            MatFullNm = g.Key, // MatFullNm 就是分組鍵
                            ColorNo = representativeItem.ColorNo,
                            ColorNm = representativeItem.ColorNm,
                            Uom = representativeItem.Uom,
                            Memo = representativeItem.Memo,
                            Standard = representativeItem.Standard,
                            Colors = representativeItem.Colors // Colors 應該已經在 Service 層的 Select 中處理好
                        };
                    })
                    .OrderBy(m => m.MatFullNm) // 對聚合後的結果進行最終排序
                    .ToList(); // 轉換為 List<MatmResultDto>

                return Ok(new APIStatusResponse<List<MatmResultDto>>
                {
                    ErrorCode = "OK",
                    Message = "查詢成功",
                    Data = finalAggregatedResults
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIStatusResponse<List<MatmResultDto>>
                {
                    ErrorCode = "SERVER_ERROR",
                    Message = "ServerError",
                    Data = null
                });
            }
        }

    }
}
