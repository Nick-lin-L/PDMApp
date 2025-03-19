
using Dtos.PGTSPEC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
        [HttpPost]
        public async Task<ActionResult<APIStatusResponse<PagedResult<PGTSPECHeaderDto>>>> Post([FromBody] PGTSPECSearchParameter value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // **當 value.Ver 為空時，預設為 "Latest Ver"**
                bool latestVerOnly = string.IsNullOrWhiteSpace(value.Ver) || value.Ver == "Latest Ver";

                // **將篩選條件直接傳遞到 QuerySpecHead**
                var query = Utils.PGTSPEC.PGTSPECQueryHelper.QuerySpecHead(_pcms_Pdm_TestContext, latestVerOnly, value);

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

        // POST api/v1/PGTSpecHead/InsertSpec
        [HttpPost("InsertSpec")]
        public async Task<ActionResult<APIStatusResponse<string>>> InsertSpec([FromBody] InsertSpecParameter value)
        {
            try
            {
                var (isSuccess, message) = await Utils.PGTSPEC.PGTSPECInsertHelper.InsertSpecAsync(_pcms_Pdm_TestContext, value);

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
        [HttpPost("CopyToSpec")]
        public async Task<ActionResult<APIStatusResponse<string>>> CopyToSpec([FromBody] CopyToSpecParameter value)
        {
            try
            {
                var (isSuccess, message) = await Utils.PGTSPEC.PGTSPECCopyToHelper.CopyToSpecAsync(_pcms_Pdm_TestContext, value);

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
        [HttpPost("CheckoutSpec")]
        public async Task<ActionResult<APIStatusResponse<string>>> CheckoutSpec([FromBody] CheckoutSpecParameter value)
        {
            try
            {
                var (isSuccess, message) = await Utils.PGTSPEC.PGTSPECCheckoutHelper.CheckoutSpecAsync(_pcms_Pdm_TestContext, value);

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

        // POST api/v1/PGTSpecHead/CheckinSpec
        [HttpPost("CheckinSpec")]
        public async Task<ActionResult<APIStatusResponse<string>>> CheckinSpec([FromBody] CheckinSpecParameter value)
        {
            try
            {
                var (isSuccess, message) = await Utils.PGTSPEC.PGTSPECCheckinHelper.CheckinSpecAsync(_pcms_Pdm_TestContext, value);

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
        [HttpPost("LockSpec")]
        public async Task<ActionResult<APIStatusResponse<string>>> LockSpec([FromBody] SpecLockParameter value)
        {
            try
            {
                var (isSuccess, message) = await Utils.PGTSPEC.PGTSPECLockHelper.LockSpecAsync(_pcms_Pdm_TestContext, value, isLock: true);

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
        [HttpPost("UnlockSpec")]
        public async Task<ActionResult<APIStatusResponse<string>>> UnlockSpec([FromBody] SpecLockParameter value)
        {
            try
            {
                var (isSuccess, message) = await Utils.PGTSPEC.PGTSPECLockHelper.LockSpecAsync(_pcms_Pdm_TestContext, value, isLock: false);

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
                resultData["BrandCombo"] = await Utils.PGTSPEC.PGTSPECQueryHelper.QueryBrand(_pcms_Pdm_TestContext, value).ToListAsync();
                resultData["SpecSourceCombo"] = await Utils.PGTSPEC.PGTSPECQueryHelper.QuerySpecSource(_pcms_Pdm_TestContext, value).ToListAsync();
                resultData["StageCombo"] = await Utils.PGTSPEC.PGTSPECQueryHelper.QueryStage(_pcms_Pdm_TestContext, value).ToListAsync();
                resultData["DevelopmentNoCombo"] = await Utils.PGTSPEC.PGTSPECQueryHelper.QueryDevelopmentNo(_pcms_Pdm_TestContext);
                resultData["DevelopmentColorNoCombo"] = await Utils.PGTSPEC.PGTSPECQueryHelper.QueryDevelopmentColorNo(_pcms_Pdm_TestContext);

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
