using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using PDMApp.Service.Basic;
using PDMApp.Utils;
using PDMApp.Utils.BasicProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace PDMApp.Controllers
{
    [ApiController]
    [Route("api/v1/systembasic/[controller]")]
    public class AccountMaintenanceController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;
        private readonly IUserManagementService _userManagementService;

        public AccountMaintenanceController(pcms_pdm_testContext pcms_Pdm_TestContext, IUserManagementService userManagementService)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_TestContext;
            _userManagementService = userManagementService;
        }

        // POST api/accountmaintenance/initial
        [HttpPost("initial")]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> AccountPageInitial()
        {
            try
            {
                // 創建字典來儲存查詢結果
                var resultData = new Dictionary<string, object>();

                // 依序執行查詢，確保每次只有一個查詢在執行
                resultData["DevFactoryNo"] = await AccountMaintenanceQueryHelper.QueryDevFactoryNo(_pcms_Pdm_TestContext).ToListAsync(); ;
                resultData["Roles"] = await AccountMaintenanceQueryHelper.QueryRoles(_pcms_Pdm_TestContext);

                // 封裝結果並回傳
                return APIResponseHelper.HandleDynamicMultiPageResponse(resultData);
            }
            catch (Exception ex)
            {
                return new ObjectResult(APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                    errorCode: "10001",
                    message: $"查詢過程中發生錯誤: {ex.Message}",
                    data: null
                ));
            }
        }

        // POST api/accountmaintenance/SearchAccounts
        [HttpPost("SearchAccounts")]
        public async Task<ActionResult<APIStatusResponse<PagedResult<pdm_usersDto>>>> SearchAccounts([FromBody] AccountSearchParameter searchParameter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // 取得所有結果
                var resultQueryable = AccountMaintenanceQueryHelper.QueryFilteredAccounts(_pcms_Pdm_TestContext, searchParameter);

                // 進行分頁處理
                var pagedResult = await resultQueryable
                                        .Distinct()
                                        .ToPagedResultAsync(searchParameter.Pagination.PageNumber, searchParameter.Pagination.PageSize);

                // 回傳分頁結果
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

        // POST api/accountmaintenance/SearchAccountDetails
        [HttpPost("SearchAccountDetails")]
        public async Task<ActionResult<APIStatusResponse<IEnumerable<AccountDetailDto>>>> SearchAccountDetails([FromBody] AccountDetailSearchParameter searchParameter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                // 查詢並強制轉換為 List
                var result = await AccountMaintenanceQueryHelper.QueryAccountDetails(_pcms_Pdm_TestContext, searchParameter)
                                                                 .ToListAsync(); // 這裡強制轉換為 List

                // 轉換成 List<AccountDetailDto> 再傳入 HandleApiResponse
                return APIResponseHelper.HandleApiResponse(result);
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

        // POST api/accountmaintenance/CreateUserRole
        [HttpPost("CreateUserRole")]
        [Authorize(AuthenticationSchemes = "PDMToken")]
        public async Task<ActionResult<APIStatusResponse<object>>> CreateUserRole([FromBody] CreateUserRoleParameter userRoleParam)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 檢查 RoleId 是否為 0 或負數
            if (userRoleParam.RoleId <= 0)
            {
                return StatusCode(200, new
                {
                    ErrorCode = "INVALID_ROLE_ID",
                    Message = "請選擇有效的角色進行新增"
                });
            }

            try
            {
                // 取得當前登入者資訊
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var userid = currentUser.UserId;  // 取得當前操作人的 UserId

                // 先檢查是否已經存在相同的 user_id 和 role_id
                bool isExist = await _pcms_Pdm_TestContext.pdm_user_roles
                    .AnyAsync(ur => ur.user_id == userRoleParam.UserId && ur.role_id == userRoleParam.RoleId);

                if (isExist)
                {
                    return StatusCode(200, new
                    {
                        ErrorCode = "DUPLICATE_ENTRY",
                        Message = "此使用者已經擁有該角色，無法重複新增"
                    });
                }

                // 若不存在，則新增
                var newUserRole = new pdm_user_roles
                {
                    user_id = userRoleParam.UserId,
                    role_id = userRoleParam.RoleId,
                    created_by = userid // 加入 created_by
                };

                _pcms_Pdm_TestContext.pdm_user_roles.Add(newUserRole);

                // **更新 pdm_users 表的 updated_by 和 updated_at 欄位**
                var user = await _pcms_Pdm_TestContext.pdm_users.FirstOrDefaultAsync(u => u.user_id == userRoleParam.UserId);
                if (user != null)
                {
                    user.updated_by = userid;
                    user.updated_at = DateTime.Now;
                }

                await _pcms_Pdm_TestContext.SaveChangesAsync();

                return StatusCode(200, new
                {
                    ErrorCode = "OK",
                    Message = "使用者角色關聯新增成功"
                });
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "DB_ERROR",
                    Message = "資料庫錯誤，可能是使用者或角色不存在",
                    Details = dbEx.InnerException?.Message ?? dbEx.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "SERVER_ERROR",
                    Message = "伺服器發生錯誤",
                    Details = ex.Message
                });
            }
        }

        // POST api/accountmaintenance/check-user
        [HttpPost("check-user")]
        [Authorize(AuthenticationSchemes = "PDMToken")]
        public async Task<ActionResult<APIStatusResponse<object>>> CheckUser([FromBody] SearchUserBySSOParameter SsoParam)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var normalizedSsoAcct = SsoParam.SsoAcct?.Trim()?.ToUpper();

            if (string.IsNullOrWhiteSpace(normalizedSsoAcct))
            {
                return APIResponseHelper.HandleApiError<object>(
                    errorCode: "10001",
                    message: "請輸入有效的SSO帳號",
                    data: null
                );
            }

            try
            {
                // 檢查是否已存在於 DB
                bool isExist = await _userManagementService.IsUserExistsBySSOAsync(normalizedSsoAcct);
                if (isExist)
                {
                    return APIResponseHelper.HandleApiError<object>(
                        errorCode: "10002",
                        message: "此SSO帳號已存在於系統中",
                        data: null
                    );
                }

                // 從 SSO 查詢使用者資訊
                var userInfo = await _userManagementService.GetUserInfoFromSSOAsync(normalizedSsoAcct);
                if (userInfo == null)
                {
                    return APIResponseHelper.HandleApiError<object>(
                        errorCode: "10004",
                        message: $"找不到SSO帳號為 {normalizedSsoAcct} 的使用者資訊",
                        data: null
                    );
                }

                // 回傳使用者資訊供前端確認
                var userData = new
                {
                    SsoAcct = userInfo.sso_acct ?? normalizedSsoAcct,
                    UserName = userInfo.chinese_nm,
                    LocalName = userInfo.local_pnl_nm,
                    Email = userInfo.contact_mail,
                    Pccuid = userInfo.pccuid.ToString()
                };

                return APIResponseHelper.GenerateApiResponse<object>("OK", "使用者資訊查詢成功", userData);
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<object>(
                    errorCode: "10006",
                    message: "伺服器發生錯誤",
                    data: null
                );
            }
        }

        // POST api/accountmaintenance/create-users
        [HttpPost("create-users")]
        [Authorize(AuthenticationSchemes = "PDMToken")]
        public async Task<ActionResult<APIStatusResponse<object>>> CreateUsers([FromBody] List<CreateUserBySSOParameter> SsoParams)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var userid = currentUser.UserId;

                var userRequests = new List<UserCreateRequest>();
                var errors = new List<string>();

                // 驗證所有使用者
                foreach (var ssoParam in SsoParams)
                {
                    if (string.IsNullOrWhiteSpace(ssoParam.SsoAcct))
                    {
                        errors.Add($"SSO帳號 {ssoParam.SsoAcct} 無效");
                        continue;
                    }

                    // 檢查是否已存在
                    bool isExist = await _userManagementService.IsUserExistsBySSOAsync(ssoParam.SsoAcct);
                    if (isExist)
                    {
                        errors.Add($"SSO帳號 {ssoParam.SsoAcct} 已存在");
                        continue;
                    }

                    // 從 SSO 查詢使用者資訊
                    var userInfo = await _userManagementService.GetUserInfoFromSSOAsync(ssoParam.SsoAcct);
                    if (userInfo == null)
                    {
                        errors.Add($"找不到SSO帳號 {ssoParam.SsoAcct} 的使用者資訊");
                        continue;
                    }

                    userRequests.Add(new UserCreateRequest
                    {
                        SsoAcct = userInfo.sso_acct ?? ssoParam.SsoAcct,
                        FirstName = userInfo.english_nm?.Split(' ').FirstOrDefault() ?? "",
                        LastName = userInfo.english_nm?.Split(' ').Skip(1).FirstOrDefault() ?? "",
                        Email = userInfo.contact_mail,
                        Pccuid = userInfo.pccuid.ToString(),
                        KeycloakSub = ""
                    });
                }

                if (errors.Any())
                {
                    return APIResponseHelper.HandleApiError<object>(
                        errorCode: "10007",
                        message: "部分使用者驗證失敗",
                        data: new { Errors = errors }
                    );
                }

                // 批次建立使用者
                var createdUsers = await _userManagementService.BatchCreateUsersFromSSOAsync(userRequests, userid);

                var successData = new
                {
                    CreatedCount = createdUsers.Count,
                    Users = createdUsers.Select(u => new
                    {
                        UserId = u.user_id,
                        Username = u.username,
                        SsoAcct = u.sso_acct,
                        Email = u.email
                    }).ToList()
                };

                return APIResponseHelper.GenerateApiResponse("OK", $"成功建立 {createdUsers.Count} 個使用者", (dynamic)successData);
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<object>(
                    errorCode: "10006",
                    message: "伺服器發生錯誤",
                    data: null
                );
            }
        }

        // DELETE api/accountmaintenance/DeleteRole
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpDelete("DeleteUserRole/{userId}/{roleId}")]
        public async Task<ActionResult<APIStatusResponse<object>>> DeleteUserRole(long userId, int roleId)
        {
            try
            {
                // 取得當前登入者資訊
                var currentUser = CurrentUserUtils.Get(HttpContext);
                var userid = currentUser.UserId;  // 從 currentUser 取得 UserId

                var userRole = await _pcms_Pdm_TestContext.pdm_user_roles
                    .FirstOrDefaultAsync(ur => ur.user_id == userId && ur.role_id == roleId);

                if (userRole == null)
                {
                    return StatusCode(200, new
                    {
                        ErrorCode = "BUSINESS_ERROR",
                        Message = "找不到該使用者的角色關聯"
                    });
                }

                _pcms_Pdm_TestContext.pdm_user_roles.Remove(userRole);

                // 更新 pdm_users 表的 updated_by 和 updated_at 欄位
                var user = await _pcms_Pdm_TestContext.pdm_users.FirstOrDefaultAsync(u => u.user_id == userId);
                if (user != null)
                {
                    user.updated_by = userid;
                    user.updated_at = DateTime.Now;
                }

                await _pcms_Pdm_TestContext.SaveChangesAsync();

                return StatusCode(200, new
                {
                    ErrorCode = "OK",
                    Message = "使用者角色關聯刪除成功"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorCode = "Server_ERROR",
                    Message = "伺服器發生錯誤",
                    Details = ex.Message
                });
            }
        }

    }
}
