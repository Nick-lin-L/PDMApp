using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using PDMApp.Parameters;
using PDMApp.Parameters.Basic;
using PDMApp.Service;
using PDMApp.Service.Basic;
using PDMApp.Utils;
using PDMApp.Utils.BasicProgram;
using PDMApp.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace PDMApp.Controllers
{
    [Route("api/v1/Basic/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "PDMToken")]
    public class UserRoleController : ControllerBase
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;
        private readonly PdmUsersRepository _repository;
        private readonly IMemoryCache _cache;
        private readonly ICurrentUserService _currentUser;

        private const string CACHE_KEYS_LIST = "user_role_cache_keys";

        public UserRoleController(pcms_pdm_testContext pcms_Pdm_testContext, PdmUsersRepository repository, IMemoryCache cache, ICurrentUserService currentUser)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
            _repository = repository;
            _cache = cache;
            _currentUser = currentUser;
        }

        /// <summary>
        /// 查詢使用者角色列表
        /// </summary>
        /// <param name="parameter">查詢參數</param>
        /// <returns>使用者角色列表</returns>
        [RequirePermission(1, "READ")]
        [HttpPost("list")]
        public async Task<ActionResult<APIStatusResponse<PagedResult<UserRoleDto>>>> GetUserRoles([FromBody] UserRoleSearchParameter parameter)
        {
            try
            {
                var query = UserRoleQueryHelper.QueryUserRoles(_pcms_Pdm_TestContext);

                // 套用過濾條件
                if (parameter.UserId.HasValue)
                    query = query.Where(ur => ur.UserId == parameter.UserId.Value);

                if (parameter.RoleId.HasValue)
                    query = query.Where(ur => ur.RoleId == parameter.RoleId.Value);

                if (!string.IsNullOrWhiteSpace(parameter.UserName))
                    query = query.Where(ur => ur.UserName.Contains(parameter.UserName));

                if (!string.IsNullOrWhiteSpace(parameter.LocalName))
                    query = query.Where(ur => ur.LocalName.Contains(parameter.LocalName));

                if (!string.IsNullOrWhiteSpace(parameter.RoleName))
                    query = query.Where(ur => ur.RoleName.Contains(parameter.RoleName));

                if (!string.IsNullOrWhiteSpace(parameter.DevFactoryNo))
                    query = query.Where(ur => ur.DevFactoryNo == parameter.DevFactoryNo);

                // 排序
                query = query.OrderBy(ur => ur.UserName).ThenBy(ur => ur.RoleName);

                var pagedResult = await query.ToPagedResultAsync(parameter.Pagination.PageNumber, parameter.Pagination.PageSize);

                return APIResponseHelper.HandlePagedApiResponse(pagedResult);
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<PagedResult<UserRoleDto>>(
                    errorCode: "10001",
                    message: $"查詢使用者角色時發生錯誤: {ex.Message}",
                    data: null
                );
            }
        }

        /// <summary>
        /// 單一使用者角色分配
        /// </summary>
        /// <param name="request">分配請求</param>
        /// <returns>分配結果</returns>
        [RequirePermission(1, "CREATE")]
        [HttpPost("assign")]
        public async Task<ActionResult<APIStatusResponse<UserRoleAssignResultDto>>> AssignUserRole([FromBody] UserRoleAssignRequest request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var currentUser = CurrentUserUtils.Get(HttpContext);
                    if (currentUser?.UserId == null)
                    {
                        return APIResponseHelper.HandleApiError<UserRoleAssignResultDto>(
                            errorCode: "40001",
                            message: "找不到登入者資訊",
                            data: null
                        );
                    }

                    // 驗證使用者是否存在
                    var user = await _pcms_Pdm_TestContext.pdm_users
                        .FirstOrDefaultAsync(u => u.user_id == request.UserId);

                    if (user == null)
                    {
                        return APIResponseHelper.HandleApiError<UserRoleAssignResultDto>(
                            errorCode: "40002",
                            message: $"使用者 ID {request.UserId} 不存在",
                            data: null
                        );
                    }

                    // 驗證角色是否存在
                    var role = await _pcms_Pdm_TestContext.pdm_roles
                        .FirstOrDefaultAsync(r => r.role_id == request.RoleId);

                    if (role == null)
                    {
                        return APIResponseHelper.HandleApiError<UserRoleAssignResultDto>(
                            errorCode: "40003",
                            message: $"角色 ID {request.RoleId} 不存在",
                            data: null
                        );
                    }

                    // 檢查是否已存在相同的使用者角色關聯
                    var existingUserRole = await _pcms_Pdm_TestContext.pdm_user_roles
                        .FirstOrDefaultAsync(ur => ur.user_id == request.UserId && ur.role_id == request.RoleId);

                    if (existingUserRole != null)
                    {
                        return APIResponseHelper.HandleApiError<UserRoleAssignResultDto>(
                            errorCode: "40004",
                            message: $"使用者 {user.username} 已經擁有角色 {role.role_name}",
                            data: null
                        );
                    }

                    // 建立新的使用者角色關聯
                    var newUserRole = new pdm_user_roles
                    {
                        user_id = request.UserId,
                        role_id = request.RoleId,
                        created_by = currentUser.UserId,
                        created_at = DateTime.UtcNow,
                        updated_by = currentUser.UserId,
                        updated_at = DateTime.UtcNow
                    };

                    _pcms_Pdm_TestContext.pdm_user_roles.Add(newUserRole);
                    await _pcms_Pdm_TestContext.SaveChangesAsync();

                    scope.Complete();

                    // 清除快取
                    ClearUserRoleCache();

                    var result = new UserRoleAssignResultDto
                    {
                        UserRoleId = newUserRole.user_role_id,
                        UserId = newUserRole.user_id.Value,
                        RoleId = newUserRole.role_id.Value,
                        UserName = user.username,
                        RoleName = role.role_name,
                        DevFactoryNo = role.dev_factory_no,
                        IsSuccess = true,
                        Message = "角色分配成功"
                    };

                    return APIResponseHelper.GenerateApiResponse("OK", "角色分配成功", result);
                }
                catch (Exception ex)
                {
                    return APIResponseHelper.HandleApiError<UserRoleAssignResultDto>(
                        errorCode: "50001",
                        message: $"分配使用者角色時發生錯誤: {ex.Message}",
                        data: null
                    );
                }
            }
        }

        /// <summary>
        /// 批次使用者角色分配
        /// </summary>
        /// <param name="request">批次分配請求</param>
        /// <returns>批次分配結果</returns>
        [RequirePermission(1, "CREATE")]
        [HttpPost("batch-assign")]
        public async Task<ActionResult<APIStatusResponse<BatchAssignResultDto>>> BatchAssignUserRoles([FromBody] BatchUserRoleAssignRequest request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var currentUser = CurrentUserUtils.Get(HttpContext);
                    if (currentUser?.UserId == null)
                    {
                        return APIResponseHelper.HandleApiError<BatchAssignResultDto>(
                            errorCode: "40001",
                            message: "找不到登入者資訊",
                            data: null
                        );
                    }

                    // 驗證角色是否存在
                    var role = await _pcms_Pdm_TestContext.pdm_roles
                        .FirstOrDefaultAsync(r => r.role_id == request.RoleId);

                    if (role == null)
                    {
                        return APIResponseHelper.HandleApiError<BatchAssignResultDto>(
                            errorCode: "40003",
                            message: $"角色 ID {request.RoleId} 不存在",
                            data: null
                        );
                    }

                    var results = new List<UserRoleAssignResultDto>();
                    int successCount = 0;
                    int failureCount = 0;

                    foreach (var userId in request.UserIds)
                    {
                        try
                        {
                            // 驗證使用者是否存在
                            var user = await _pcms_Pdm_TestContext.pdm_users
                                .FirstOrDefaultAsync(u => u.user_id == userId);

                            if (user == null)
                            {
                                results.Add(new UserRoleAssignResultDto
                                {
                                    UserId = userId,
                                    RoleId = request.RoleId,
                                    IsSuccess = false,
                                    Message = $"使用者 ID {userId} 不存在"
                                });
                                failureCount++;
                                continue;
                            }

                            // 檢查是否已存在相同的使用者角色關聯
                            var existingUserRole = await _pcms_Pdm_TestContext.pdm_user_roles
                                .FirstOrDefaultAsync(ur => ur.user_id == userId && ur.role_id == request.RoleId);

                            if (existingUserRole != null)
                            {
                                results.Add(new UserRoleAssignResultDto
                                {
                                    UserId = userId,
                                    RoleId = request.RoleId,
                                    UserName = user.username,
                                    RoleName = role.role_name,
                                    IsSuccess = false,
                                    Message = $"使用者 {user.username} 已經擁有角色 {role.role_name}"
                                });
                                failureCount++;
                                continue;
                            }

                            // 建立新的使用者角色關聯
                            var newUserRole = new pdm_user_roles
                            {
                                user_id = userId,
                                role_id = request.RoleId,
                                created_by = currentUser.UserId,
                                created_at = DateTime.UtcNow,
                                updated_by = currentUser.UserId,
                                updated_at = DateTime.UtcNow
                            };

                            _pcms_Pdm_TestContext.pdm_user_roles.Add(newUserRole);

                            results.Add(new UserRoleAssignResultDto
                            {
                                UserRoleId = newUserRole.user_role_id,
                                UserId = userId,
                                RoleId = request.RoleId,
                                UserName = user.username,
                                RoleName = role.role_name,
                                DevFactoryNo = role.dev_factory_no,
                                IsSuccess = true,
                                Message = "角色分配成功"
                            });
                            successCount++;
                        }
                        catch (Exception ex)
                        {
                            results.Add(new UserRoleAssignResultDto
                            {
                                UserId = userId,
                                RoleId = request.RoleId,
                                IsSuccess = false,
                                Message = $"處理使用者 {userId} 時發生錯誤: {ex.Message}"
                            });
                            failureCount++;
                        }
                    }

                    await _pcms_Pdm_TestContext.SaveChangesAsync();
                    scope.Complete();

                    // 清除快取
                    ClearUserRoleCache();

                    var batchResult = new BatchAssignResultDto
                    {
                        Results = results,
                        TotalCount = request.UserIds.Count,
                        SuccessCount = successCount,
                        FailureCount = failureCount
                    };

                    return APIResponseHelper.GenerateApiResponse("OK", "批次分配完成", batchResult);
                }
                catch (Exception ex)
                {
                    return APIResponseHelper.HandleApiError<BatchAssignResultDto>(
                        errorCode: "50001",
                        message: $"批次分配使用者角色時發生錯誤: {ex.Message}",
                        data: null
                    );
                }
            }
        }

        /// <summary>
        /// 移除使用者角色
        /// </summary>
        /// <param name="userRoleId">使用者角色 ID</param>
        /// <returns>移除結果</returns>
        [RequirePermission(1, "DELETE")]
        [HttpDelete("remove/{userRoleId}")]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> RemoveUserRole(int userRoleId)
        {
            try
            {
                var userRole = await _pcms_Pdm_TestContext.pdm_user_roles
                    .Include(ur => ur.user)
                    .Include(ur => ur.role)
                    .FirstOrDefaultAsync(ur => ur.user_role_id == userRoleId);

                if (userRole == null)
                {
                    return APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                        errorCode: "40004",
                        message: "找不到指定的使用者角色關聯",
                        data: null
                    );
                }

                _pcms_Pdm_TestContext.pdm_user_roles.Remove(userRole);
                await _pcms_Pdm_TestContext.SaveChangesAsync();

                // 清除快取
                ClearUserRoleCache();

                var result = new Dictionary<string, object>
                {
                    { "message", $"已成功移除使用者 {userRole.user?.username} 的角色 {userRole.role?.role_name}" },
                    { "removedUserRoleId", userRoleId }
                };

                return APIResponseHelper.GenerateApiResponse("OK", "移除成功", (IDictionary<string, object>)result);
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                    errorCode: "50001",
                    message: $"移除使用者角色時發生錯誤: {ex.Message}",
                    data: null
                );
            }
        }

        /// <summary>
        /// 根據使用者 ID 和角色 ID 移除使用者角色
        /// </summary>
        /// <param name="userId">使用者 ID</param>
        /// <param name="roleId">角色 ID</param>
        /// <returns>移除結果</returns>
        [RequirePermission(1, "DELETE")]
        [HttpDelete("remove/{userId}/{roleId}")]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> RemoveUserRoleByUserAndRole(long userId, int roleId)
        {
            try
            {
                var userRole = await _pcms_Pdm_TestContext.pdm_user_roles
                    .Include(ur => ur.user)
                    .Include(ur => ur.role)
                    .FirstOrDefaultAsync(ur => ur.user_id == userId && ur.role_id == roleId);

                if (userRole == null)
                {
                    return APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                        errorCode: "40004",
                        message: "找不到指定的使用者角色關聯",
                        data: null
                    );
                }

                _pcms_Pdm_TestContext.pdm_user_roles.Remove(userRole);
                await _pcms_Pdm_TestContext.SaveChangesAsync();

                // 清除快取
                ClearUserRoleCache();

                var result = new Dictionary<string, object>
                {
                    { "message", $"已成功移除使用者 {userRole.user?.username} 的角色 {userRole.role?.role_name}" },
                    { "removedUserRoleId", userRole.user_role_id }
                };

                return APIResponseHelper.GenerateApiResponse("OK", "移除成功", (IDictionary<string, object>)result);
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                    errorCode: "50001",
                    message: $"移除使用者角色時發生錯誤: {ex.Message}",
                    data: null
                );
            }
        }

        /// <summary>
        /// 取得使用者的所有角色
        /// </summary>
        /// <param name="userId">使用者 ID</param>
        /// <returns>使用者角色列表</returns>
        [HttpGet("user/{userId}/roles")]
        public async Task<ActionResult<APIStatusResponse<IEnumerable<UserRoleDto>>>> GetUserRoles(long userId)
        {
            try
            {
                var userRoles = await UserRoleQueryHelper.QueryUserRolesByUserId(_pcms_Pdm_TestContext, userId)
                    .ToListAsync();

                return APIResponseHelper.HandleApiResponse(userRoles);
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<IEnumerable<UserRoleDto>>(
                    errorCode: "10001",
                    message: $"查詢使用者角色時發生錯誤: {ex.Message}",
                    data: null
                );
            }
        }

        /// <summary>
        /// 取得角色的所有使用者
        /// </summary>
        /// <param name="roleId">角色 ID</param>
        /// <returns>角色使用者列表</returns>
        [HttpGet("role/{roleId}/users")]
        public async Task<ActionResult<APIStatusResponse<IEnumerable<UserRoleDto>>>> GetRoleUsers(int roleId)
        {
            try
            {
                var roleUsers = await UserRoleQueryHelper.QueryUserRolesByRoleId(_pcms_Pdm_TestContext, roleId)
                    .ToListAsync();

                return APIResponseHelper.HandleApiResponse(roleUsers);
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<IEnumerable<UserRoleDto>>(
                    errorCode: "10001",
                    message: $"查詢角色使用者時發生錯誤: {ex.Message}",
                    data: null
                );
            }
        }

        /// <summary>
        /// 清除使用者角色快取
        /// </summary>
        private void ClearUserRoleCache()
        {
            var cacheKeys = _cache.Get<HashSet<string>>(CACHE_KEYS_LIST) ?? new HashSet<string>();

            // 清除使用者角色相關的快取
            var keysToRemove = cacheKeys.Where(k =>
                k.StartsWith($"user_roles_") ||
                k.StartsWith($"role_users_") ||
                k.StartsWith($"menu_permissions_")
            ).ToList();

            foreach (var key in keysToRemove)
            {
                _cache.Remove(key);
                cacheKeys.Remove(key);
            }

            // 更新快取
            _cache.Set(CACHE_KEYS_LIST, cacheKeys);
        }
    }

    /// <summary>
    /// 使用者角色查詢參數
    /// </summary>
    public class UserRoleSearchParameter
    {
        public long? UserId { get; set; }
        public int? RoleId { get; set; }
        public string UserName { get; set; }
        public string LocalName { get; set; }
        public string RoleName { get; set; }
        public string DevFactoryNo { get; set; }
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }
}