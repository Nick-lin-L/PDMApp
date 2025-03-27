using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using PDMApp.Utils;
using PDMApp.Utils.BasicProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountMaintenanceController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public AccountMaintenanceController(pcms_pdm_testContext pcms_Pdm_TestContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_TestContext;
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
                    role_id = userRoleParam.RoleId
                };

                _pcms_Pdm_TestContext.pdm_user_roles.Add(newUserRole);
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



        // DELETE api/accountmaintenance/DeleteRole
        [HttpDelete("DeleteUserRole/{userId}/{roleId}")]
        public async Task<ActionResult<APIStatusResponse<object>>> DeleteUserRole(long userId, int roleId)
        {
            try
            {
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
