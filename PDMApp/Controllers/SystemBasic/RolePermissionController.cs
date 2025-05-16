using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using PDMApp.Parameters.SystemBasic;
using PDMApp.Service;
using PDMApp.Service.Basic;
using PDMApp.Utils;
using PDMApp.Utils.BasicProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using PDMApp.Attributes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers
{
    [Route("api/v1/Basic/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "PDMToken")]
    public class RolePermissionController : ControllerBase
    {
        // GET: api/<RolePermissionController>
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;
        private readonly PdmUsersRepository _repository;
        private readonly IMemoryCache _cache;
        private readonly ICurrentUserService _currentUser;

        private const string CACHE_KEYS_LIST = "permission_cache_keys";

        public RolePermissionController(pcms_pdm_testContext pcms_Pdm_testContext, PdmUsersRepository repository, IMemoryCache cache, ICurrentUserService currentUser)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
            _repository = repository;
            _cache = cache;
            _currentUser = currentUser;
        }

        // 0. Pageload 下拉查詢列表
        /// <summary>
        /// Roles頁面初始化傳入的參數，與新增角色時的畫面資料
        /// </summary>
        /// <param name="value">傳入的參數物件，用於判斷是否需要加載特定的初始資料。</param>
        /// <returns>回傳一個包含初始數據的 <see cref="APIStatusResponse{IDictionary}"/> 格式。</returns>
        [ProducesResponseType(typeof(APIStatusResponse<IDictionary<string, object>>), 200)]
        [ProducesResponseType(typeof(object), 500)]
        [HttpPost("initial")]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> RolePageInitial([FromBody] PermissionsParameter value)
        {
            try
            {
                /*/
                // Factory 查詢
                var queryF = BasicQueryHelper.QueryFactory(_pcms_Pdm_TestContext);
                var factoryq = await queryF.Distinct().ToListAsync();

                // permissions 查詢
                var queryP = BasicQueryHelper.QueryPermissions(_pcms_Pdm_TestContext);
                var filters = await queryP.Distinct().OrderBy(q => q.RolePermissionId).ToListAsync();

                // details 查詢
                var queryD = BasicQueryHelper.QueryPermissionDetails(_pcms_Pdm_TestContext);
                var filtersD = await queryD.Distinct().OrderBy(q => q.RolePermissionDetailId).ToListAsync();

                var dynamicData = new Dictionary<string, object>
                {
                    { "DevFactoryNo", factoryq },
                    { "Permissions", filters },
                    { "PermissionDetails", filtersD },
                };
                return APIResponseHelper.HandleDynamicMultiPageResponse(dynamicData);
                /*/
                // init 查詢
                var queryInit = await BasicQueryHelper.QueryInitial(_pcms_Pdm_TestContext);
                return APIResponseHelper.HandleDynamicMultiPageResponse(queryInit);


                //*/
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

        // 1. 查詢角色列表
        /// <summary>
        /// 查詢角色列表
        /// </summary>
        /// <param name="value">傳入的參數物件，用於判斷是否需要過濾資料。</param>
        /// <returns>回傳查詢後的角色資料 <see cref="APIStatusResponse{IDictionary}"/> 格式。</returns>
        [RequirePermission(1, "READ")]
        [HttpPost("roles")]
        public async Task<ActionResult<APIStatusResponse<PagedResult<pdm_rolesDto>>>> Roles([FromBody] RolesParameter value)
        {
            try
            {
                var query = BasicQueryHelper.QueryRoles(_pcms_Pdm_TestContext);
                var filters = new List<Expression<Func<pdm_rolesDto, bool>>>();

                if (!string.IsNullOrWhiteSpace(value.RoleName))
                    filters.Add(proles => proles.RoleName.Contains(value.RoleName));
                if (!string.IsNullOrWhiteSpace(value.Description))
                    filters.Add(proles => proles.Description.Contains(value.Description));
                if (!string.IsNullOrWhiteSpace(value.DevFactoryNo))
                    filters.Add(proles => proles.DevFactoryNo.Contains(value.DevFactoryNo));

                if (!string.IsNullOrWhiteSpace(value.IsActive))
                {
                    string TrimIsActive = value.IsActive.Trim();
                    filters.Add(proles => proles.IsActive == TrimIsActive);
                }


                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }

                // 排序,如果需要多重排序的話後面接.ThenBy(條件)即可
                //query = query.OrderBy(proles => proles.RoleId);
                var pagedResult = await query.Distinct().OrderBy(proles => proles.RoleId)
                                             .ToPagedResultAsync(value.Pagination.PageNumber, value.Pagination.PageSize);

                return APIResponseHelper.HandlePagedApiResponse(pagedResult);
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

        // 2. 查詢角色+權限列表
        /// <summary>
        /// 查詢角色列表+權限列表
        /// </summary>
        /// <param name="value">當使用者點擊畫面上的角色時會查詢該角色的權限有哪些。</param>
        /// <returns>回傳查詢後的角色+角色權限資料 <see cref="APIStatusResponse{IDictionary}"/> 格式。</returns>
        [HttpPost("role-permissions")]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> RolePermissions([FromBody] PermissionsParameter value)
        {
            try
            {
                // permissions 查詢
                var result = await BasicQueryHelper.QueryPermissionsWithDetailsAsync(_pcms_Pdm_TestContext, value);
                return APIResponseHelper.HandleDynamicMultiPageResponse(result);
            }
            catch (Exception ex)
            {
                /*
                return new ObjectResult(APIResponseHelper.HandleApiError<object>(
                    errorCode: "10001",
                    message: $"查詢過程中發生錯誤: {ex.Message}",
                    data: null
                )); 不確認型別的寫法，也可以但可能轉型會出現CS0029*/
                return APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                    errorCode: "50001",
                    message: $"權限查詢過程中發生錯誤: {ex.Message}",
                    data: null
                );
            }
        }

        // 3. 新增或更新角色資料
        [RequirePermission(1, "CREATE")]
        [HttpPost("upsert")]
        //public async Task<IActionResult> UpsertRolePermission([FromBody] RolePermissionsParameter request)
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> UpsertRolePermission([FromBody] RolePermissionsParameter request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var currentUser = CurrentUserUtils.Get(HttpContext);

                    if (currentUser?.UserId == null)
                    {
                        return APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                            errorCode: "40001",
                            message: "The P.permission_id or RoleID must not be empty.",
                            data: null
                        );
                        //return APIResponseHelper.HandleApiError<object>("401", "找不到登入者資訊");
                    }

                    // 然後就可以用：
                    var updatedBy = currentUser.UserId;

                    // 確保 Permissions 和 PermissionDetails 不為 null
                    request.Permissions ??= new List<PermissionRequest>();
                    request.PermissionDetails ??= new List<PermissionDetails>();

                    // 驗證廠別是否存在
                    var factoryExists = await _pcms_Pdm_TestContext.pdm_factory
                        .AnyAsync(f => f.dev_factory_no == request.DevFactoryNo);

                    if (!factoryExists)
                    {
                        return APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                            errorCode: "40001",
                            message: $"DevFactoryNo {request.DevFactoryNo} does not exist in the system.",
                            data: null
                        );
                    }

                    int? roleId = null;
                    if (!string.IsNullOrWhiteSpace(request.RoleId))
                    {
                        roleId = int.TryParse(request.RoleId, out int parsedId) ? parsedId : null;
                    }

                    // **[1] 角色處理**
                    var role = roleId.HasValue
                        ? await _pcms_Pdm_TestContext.pdm_roles.FirstOrDefaultAsync(r => r.role_id == roleId.Value)
                        : null;

                    if (role == null)
                    {
                        // 驗證必要欄位
                        if (string.IsNullOrWhiteSpace(request.RoleName) || string.IsNullOrWhiteSpace(request.Description) || string.IsNullOrWhiteSpace(request.DevFactoryNo))
                        {
                            return APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                                errorCode: "40001",
                                message: "RoleName,Description,DevFactoryNo must not be empty.",
                                data: null
                            );
                        }

                        // 檢查相同廠別下是否已存在相同角色名稱
                        var existingRole = await _pcms_Pdm_TestContext.pdm_roles
                            .FirstOrDefaultAsync(r => r.role_name == request.RoleName &&
                                                     r.dev_factory_no == request.DevFactoryNo);

                        if (existingRole != null)
                        {
                            return APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                                errorCode: "40002",
                                message: $"角色名稱 '{request.RoleName}' 在廠別 '{request.DevFactoryNo}' 已存在。",
                                data: null
                            );
                        }

                        // 新增角色
                        role = new pdm_roles
                        {
                            role_name = request.RoleName,
                            description = request.Description,
                            dev_factory_no = request.DevFactoryNo,
                            is_active = request.IsActive,
                            created_by = updatedBy,
                            created_at = DateTime.UtcNow,
                            updated_by = updatedBy,
                            updated_at = DateTime.UtcNow
                        };
                        _pcms_Pdm_TestContext.pdm_roles.Add(role);
                        await _pcms_Pdm_TestContext.SaveChangesAsync();
                    }
                    else
                    {
                        // 更新角色時檢查重複名稱（排除自己）
                        if (request.RoleName != role.role_name)
                        {
                            var existingRole = await _pcms_Pdm_TestContext.pdm_roles
                                .FirstOrDefaultAsync(r => r.role_name == request.RoleName &&
                                                         r.dev_factory_no == request.DevFactoryNo &&
                                                         r.role_id != role.role_id);

                            if (existingRole != null)
                            {
                                return APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                                    errorCode: "40002",
                                    message: $"角色名稱 '{request.RoleName}' 在廠別 '{request.DevFactoryNo}' 已存在。",
                                    data: null
                                );
                            }
                        }

                        // 更新角色
                        role.role_name = request.RoleName ?? role.role_name;
                        role.description = request.Description ?? role.description;
                        role.dev_factory_no = request.DevFactoryNo ?? role.dev_factory_no;
                        role.is_active = request.IsActive ?? role.is_active;
                        role.updated_by = updatedBy;
                        role.updated_at = DateTime.UtcNow;
                    }

                    // **確保 RoleId 正確**
                    int roleIdt = role.role_id;

                    // **[2] 更新 Permissions**
                    foreach (var perm in request.Permissions)
                    {
                        var existingPerm = await _pcms_Pdm_TestContext.pdm_role_permissions
                            .FirstOrDefaultAsync(p => p.permission_id == perm.PermissionId && p.role_id == roleIdt);

                        if (existingPerm != null)
                        {
                            // 更新權限
                            existingPerm.is_active = perm.IsActive ?? existingPerm.is_active;
                            existingPerm.createp = perm.CreateP ?? existingPerm.createp;
                            existingPerm.readp = perm.ReadP ?? existingPerm.readp;
                            existingPerm.updatep = perm.UpdateP ?? existingPerm.updatep;
                            existingPerm.deletep = perm.DeleteP ?? existingPerm.deletep;
                            existingPerm.exportp = perm.ExportP ?? existingPerm.exportp;
                            existingPerm.importp = perm.ImportP ?? existingPerm.importp;
                            existingPerm.permission1 = perm.Permission1 ?? existingPerm.permission1;
                            existingPerm.permission2 = perm.Permission2 ?? existingPerm.permission2;
                            existingPerm.permission3 = perm.Permission3 ?? existingPerm.permission3;
                            existingPerm.permission4 = perm.Permission4 ?? existingPerm.permission4;
                            existingPerm.dev_factory_no = request.DevFactoryNo;
                            existingPerm.updated_by = updatedBy;
                            existingPerm.updated_at = DateTime.UtcNow;
                        }
                        else
                        {
                            // 新增權限
                            var newPerm = new pdm_role_permissions
                            {
                                role_id = roleIdt,
                                permission_id = perm.PermissionId,
                                is_active = perm.IsActive ?? "Y",
                                createp = perm.CreateP ?? "Y",
                                readp = perm.ReadP ?? "Y",
                                updatep = perm.UpdateP ?? "Y",
                                deletep = perm.DeleteP ?? "Y",
                                exportp = perm.ExportP ?? "Y",
                                importp = perm.ImportP ?? "Y",
                                permission1 = perm.Permission1 ?? "Y",
                                permission2 = perm.Permission2 ?? "Y",
                                permission3 = perm.Permission3 ?? "Y",
                                permission4 = perm.Permission4 ?? "Y",
                                dev_factory_no = request.DevFactoryNo,
                                created_by = updatedBy,
                                created_at = DateTime.UtcNow
                            };
                            _pcms_Pdm_TestContext.pdm_role_permissions.Add(newPerm);
                        }
                    }

                    // **[3] 更新 PermissionDetails**
                    foreach (var detail in request.PermissionDetails)
                    {
                        // 檢查 PermissionKeyId 是否存在於 pdm_permission_keys
                        var permissionKey = await _pcms_Pdm_TestContext.pdm_permission_keys
                            .FirstOrDefaultAsync(pk => pk.permission_key_id == detail.PermissionKeyId);

                        // 如果 permission key 不存在，則新增一個
                        if (permissionKey == null)
                        {
                            permissionKey = new pdm_permission_keys
                            {
                                permission_key_id = detail.PermissionKeyId,
                                permission_key = detail.PermissionKey,
                                created_by = updatedBy,
                                created_at = DateTime.UtcNow
                            };
                            _pcms_Pdm_TestContext.pdm_permission_keys.Add(permissionKey);
                            await _pcms_Pdm_TestContext.SaveChangesAsync(); // 先儲存以獲得正確的 ID
                        }

                        var existingDetail = await _pcms_Pdm_TestContext.pdm_role_permission_details
                            .FirstOrDefaultAsync(d => d.role_id == roleId &&
                                d.permission_key_id == detail.PermissionKeyId &&
                                d.dev_factory_no == request.DevFactoryNo);

                        if (existingDetail != null)
                        {
                            // 更新詳細權限
                            existingDetail.is_active = detail.IsActiveD ?? existingDetail.is_active;
                            existingDetail.dev_factory_no = request.DevFactoryNo;
                            existingDetail.permission_key = detail.PermissionKey ?? existingDetail.permission_key;
                            existingDetail.description = detail.DescriptionD ?? existingDetail.description;
                            existingDetail.updated_by = updatedBy;
                            existingDetail.updated_at = DateTime.UtcNow;
                        }
                        else
                        {
                            // 新增詳細權限，預設為停用狀態
                            var newDetail = new pdm_role_permission_details
                            {
                                role_id = roleIdt,
                                permission_id = detail.PermissionId,
                                permission_key_id = detail.PermissionKeyId,
                                is_active = detail.IsActiveD ?? "N",  // 如果沒有指定，預設為 "N"
                                description = detail.DescriptionD,
                                permission_key = detail.PermissionKey,
                                dev_factory_no = request.DevFactoryNo,
                                created_by = updatedBy,
                                created_at = DateTime.UtcNow
                            };
                            _pcms_Pdm_TestContext.pdm_role_permission_details.Add(newDetail);
                        }
                    }

                    // **[4] 儲存 & 交易提交**
                    await _pcms_Pdm_TestContext.SaveChangesAsync();
                    scope.Complete();

                    // 清除快取
                    var cacheKeys = _cache.Get<HashSet<string>>(CACHE_KEYS_LIST) ?? new HashSet<string>();

                    // 清除該角色的所有快取
                    var keysToRemove = cacheKeys.Where(k =>
                        k.StartsWith($"permission_") ||
                        k.StartsWith($"user_roles_")
                    ).ToList();

                    foreach (var key in keysToRemove)
                    {
                        _cache.Remove(key);
                        cacheKeys.Remove(key);
                    }

                    // 更新快取
                    _cache.Set(CACHE_KEYS_LIST, cacheKeys);

                    var resultData = new Dictionary<string, object>
                    {
                        { "Role", new { role.role_id, role.role_name, role.description, role.dev_factory_no, role.is_active } },
                        { "Permissions", request.Permissions },
                        { "PermissionDetails", request.PermissionDetails }
                    };

                    return APIResponseHelper.HandleDynamicMultiPageResponse(resultData);
                }

                catch (Exception ex)
                {
                    //Console.WriteLine($"[ERROR] {ex.Message}");
                    //Console.WriteLine($"[STACKTRACE] {ex.StackTrace}");
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"[INNER EXCEPTION] {ex.InnerException.Message}");
                    }

                    return APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                        errorCode: "50001",
                        message: $"權限更新過程中發生錯誤: {ex.Message}",
                        data: null
                    );
                    throw;
                }
            }
        }

        // 4. 停用角色及其相關權限
        /// <summary>
        /// 停用角色及其相關權限
        /// </summary>
        /// <param name="roleId">要停用的角色ID</param>
        /// <param name="request">更新請求資訊包</param>
        /// <returns>停用結果</returns>
        [HttpPut("deactivate/{roleId}")]
        public async Task<ActionResult<APIStatusResponse<object>>> DeactivateRole(int roleId, [FromBody] RolePermissionsParameter request)
        {

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    long updatedBy = (long)request.UpdatedBy;
                    // 查找角色是否存在
                    var role = await _pcms_Pdm_TestContext.pdm_roles
                        .FirstOrDefaultAsync(r => r.role_id == roleId);

                    if (role == null)
                    {
                        return APIResponseHelper.HandleApiError<object>(
                            errorCode: "40004",
                            message: "找不到指定的角色",
                            data: null
                        );
                    }

                    var currentTime = DateTime.UtcNow;

                    // 更新角色狀態
                    role.is_active = "N";
                    role.updated_by = updatedBy;
                    role.updated_at = currentTime;

                    // 更新相關的權限記錄
                    var permissions = await _pcms_Pdm_TestContext.pdm_role_permissions
                        .Where(p => p.role_id == roleId)
                        .ToListAsync();

                    foreach (var permission in permissions)
                    {
                        permission.is_active = "N";
                        permission.updated_by = updatedBy;
                        permission.updated_at = currentTime;
                    }

                    // 更新相關的權限詳細記錄
                    var permissionDetails = await _pcms_Pdm_TestContext.pdm_role_permission_details
                        .Where(d => d.role_id == roleId)
                        .ToListAsync();

                    foreach (var detail in permissionDetails)
                    {
                        detail.is_active = "N";
                        detail.updated_by = updatedBy;
                        detail.updated_at = currentTime;
                    }

                    // 儲存變更
                    await _pcms_Pdm_TestContext.SaveChangesAsync();
                    scope.Complete();

                    return APIResponseHelper.HandleDynamicMultiPageResponse(new Dictionary<string, object>
                    {
                        { "message", "角色已成功停用" },
                        { "deactivatedRecords", new {
                            roleId = roleId,
                            permissionsCount = permissions.Count,
                            permissionDetailsCount = permissionDetails.Count
                        }}
                    }).Result;
                }
                catch (Exception ex)
                {
                    return APIResponseHelper.HandleApiError<object>(
                        errorCode: "50002",
                        message: $"停用角色時發生錯誤: {ex.Message}",
                        data: null
                    );
                }
            }
        }

        // 4. 刪除角色及其相關權限
        /// <summary>
        /// 刪除角色及其相關權限
        /// </summary>
        /// <param name="roleId">要刪除的角色ID</param>
        /// <returns>刪除結果</returns>
        [RequirePermission(1, "DELETE")]
        [HttpDelete("delete/{roleId}")]
        public async Task<ActionResult<APIStatusResponse<object>>> DeleteRole(int roleId)
        {
            using (var transaction = await _pcms_Pdm_TestContext.Database.BeginTransactionAsync())
            {
                try
                {
                    // 查找角色是否存在
                    var role = await _pcms_Pdm_TestContext.pdm_roles
                        .FirstOrDefaultAsync(r => r.role_id == roleId);

                    if (role == null)
                    {
                        return APIResponseHelper.HandleApiError<object>(
                            errorCode: "40004",
                            message: "找不到指定的角色",
                            data: null
                        );
                    }

                    // 刪除使用者角色關聯記錄
                    var userRoles = await _pcms_Pdm_TestContext.pdm_user_roles
                        .Where(ur => ur.role_id == roleId)
                        .ToListAsync();
                    _pcms_Pdm_TestContext.pdm_user_roles.RemoveRange(userRoles);

                    // 刪除相關的權限詳細記錄
                    var permissionDetails = await _pcms_Pdm_TestContext.pdm_role_permission_details
                        .Where(d => d.role_id == roleId)
                        .ToListAsync();
                    _pcms_Pdm_TestContext.pdm_role_permission_details.RemoveRange(permissionDetails);

                    // 刪除相關的權限記錄
                    var permissions = await _pcms_Pdm_TestContext.pdm_role_permissions
                        .Where(p => p.role_id == roleId)
                        .ToListAsync();
                    _pcms_Pdm_TestContext.pdm_role_permissions.RemoveRange(permissions);

                    // 刪除角色
                    _pcms_Pdm_TestContext.pdm_roles.Remove(role);

                    // 儲存變更
                    await _pcms_Pdm_TestContext.SaveChangesAsync();

                    // 提交交易
                    await transaction.CommitAsync();
                    return APIResponseHelper.GenerateApiResponse("OK", "刪除成功", "").Result;
                    /*return APIResponseHelper.HandleDynamicMultiPageResponse(new Dictionary<string, object>
                    {
                        { "message", "角色已成功刪除" },
                        { "deletedRecords", new {
                            userRolesCount = userRoles.Count,
                            permissionDetailsCount = permissionDetails.Count,
                            permissionsCount = permissions.Count,
                            roleId = roleId
                        }}
                    }).Result;*/
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return APIResponseHelper.HandleApiError<object>(
                        errorCode: "50002",
                        message: $"刪除角色時發生錯誤: {ex.Message}",
                        data: null
                    );
                }
            }
        }

        // 5. 取得user選單權限
        /// <summary>
        /// 取得user選單權限
        /// </summary>
        /// <param name="request">選單權限參數</param>
        /// <returns>選單權限結果</returns>
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("menu-permissions")]
        public async Task<IActionResult> GetUserPermissions([FromBody] MenuPermissionParameter request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.DevFactoryNo))
                    return APIResponseHelper.HandleApiError<object>("40001", "廠別不可為空").Result;

                if (_currentUser.UserId == null)
                    return APIResponseHelper.HandleApiError<object>("401", "尚未登入").Result;

                // 加入語系到快取鍵中
                //var cacheKey = $"menu_permissions_{_currentUser.UserId}_{request.DevFactoryNo}_{request.LangCode}";

                //if (_cache.TryGetValue(cacheKey, out UserPermissionResultDto cachedResult))
                //return APIResponseHelper.GenerateApiResponse("OK", "查詢成功 (cache)", cachedResult).Result;

                // 傳入語系參數
                var result = await _repository.GetUserPermissionTreeAsync(
                    _currentUser.UserId.Value,
                    request.DevFactoryNo,
                    request.LangCode
                );

                //_cache.Set(cacheKey, result, new MemoryCacheEntryOptions
                //{
                //    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                //});

                return APIResponseHelper.GenerateApiResponse("OK", "查詢成功", result).Result;
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<object>(
                    "50001",
                    $"取得選單權限時發生錯誤：{ex.Message}",
                    null
                ).Result;
            }
        }



        // 5. 取得user tree menu
        /// <summary>
        /// 取得user選單
        /// </summary>
        /// <param name="languageCode">語言國別完整代號</param>
        /// <returns>選單的樹狀結構</returns>
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpGet("user-menu")]
        public async Task<ActionResult<APIStatusResponse<IEnumerable<MenuTreeDto>>>> GetUserMenu([FromQuery] string languageCode = "zh-TW")
        {
            try
            {
                // 1. 從 Token 獲取用戶資訊
                var userId = User.FindFirst("user_id")?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    return APIResponseHelper.HandleApiError<IEnumerable<MenuTreeDto>>(
                        "401", "未登入或Token無效", null);
                }

                // 2. 獲取用戶的角色和權限
                var userRoles = await _pcms_Pdm_TestContext.pdm_user_roles
                    .Where(ur => ur.user_id.ToString() == userId)
                    .Select(ur => ur.role_id)
                    .ToListAsync();

                // 3. 獲取該角色可以訪問的選單
                var permissionKeys = await _pcms_Pdm_TestContext.pdm_role_permissions
                    .Where(rp => userRoles.Contains(rp.role_id.Value))
                    .Select(rp => rp.permission.pdm_permission_keys
                        .Select(pk => pk.permission_key))
                    .SelectMany(x => x)
                    .Distinct()
                    .ToListAsync();

                // 4. 獲取選單樹
                var menus = await _pcms_Pdm_TestContext.sys_menus
                    .Include(m => m.sys_menu_i18n)
                    .Where(m => m.is_active == "Y") //permissionKeys.Contains(m.permission_key))
                    .OrderBy(m => m.sort_order)
                    .Select(m => new MenuTreeDto
                    {
                        MenuId = m.menu_id,
                        ParentId = m.parent_id,
                        PermissionId = m.permission_id,
                        MenuName = m.sys_menu_i18n.Any(i => i.language_code == languageCode)
                        ? m.sys_menu_i18n.First(i => i.language_code == languageCode).menu_name
                        : m.menu_name,
                        MenuPath = m.menu_path,
                        ComponentPath = m.component_path,
                        Icon = m.menu_icon,
                        SortOrder = m.sort_order ?? 0
                    })
                    .ToListAsync();

                var menuTree = BuildMenuTree(menus).ToList();
                return APIResponseHelper.HandleApiResponse(menuTree);
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? $" Inner exception: {ex.InnerException.Message}" : "";
                return APIResponseHelper.HandleApiError<IEnumerable<MenuTreeDto>>(
                    "50001", $"獲取選單失敗: {ex.Message}{innerException}", null);
            }
        }

        // 建立樹狀結構
        private List<MenuTreeDto> BuildMenuTree(List<MenuTreeDto> menus, int? parentId = null)
        {
            return menus
                .Where(m => m.ParentId == parentId)
                .Select(m => new MenuTreeDto
                {
                    MenuId = m.MenuId,
                    ParentId = m.ParentId,
                    PermissionId = m.PermissionId,
                    MenuName = m.MenuName,
                    MenuPath = m.MenuPath,
                    ComponentPath = m.ComponentPath,
                    Icon = m.Icon,
                    SortOrder = m.SortOrder,
                    Children = BuildMenuTree(menus, m.MenuId)
                })
                .OrderBy(m => m.SortOrder)
                .ToList();
        }

        public class PermissionsWrapper
        {
            public IEnumerable<pdm_permissionsDto> Permissions { get; set; }
        }


        // 6. 取得該作業權限
        /// <summary>
        /// 取得該作業權限
        /// </summary>
        /// <param name="request">傳入frotendID</param>
        /// <returns>單支作業權限的主、擴充結構</returns>
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpPost("check-permission")]
        public async Task<ActionResult<APIStatusResponse<PermissionCheckResultDto>>> CheckPermission([FromBody] PermissionCheckParameter request)
        {
            try
            {
                if (_currentUser.UserId == null)
                {
                    return APIResponseHelper.HandleApiError<PermissionCheckResultDto>(
                        "401", "尚未登入", null);
                }

                if (string.IsNullOrEmpty(request.DevFactoryNo))
                {
                    return APIResponseHelper.HandleApiError<PermissionCheckResultDto>(
                        "40001", "廠別不可為空", null);
                }

                // 1. 取得使用者角色
                var userRoles = await _pcms_Pdm_TestContext.pdm_user_roles
                    .Where(ur => ur.user_id == _currentUser.UserId)
                    .Select(ur => ur.role_id)
                    .ToListAsync();

                // 2. 取得權限資料
                var permission = await _pcms_Pdm_TestContext.pdm_permissions
                    .FirstOrDefaultAsync(p => p.frontend_id == request.FrontendId);

                if (permission == null)
                {
                    return APIResponseHelper.HandleApiError<PermissionCheckResultDto>(
                        "40002", "找不到對應的權限資料", null);
                }

                // 3. 取得角色權限
                var rolePermissions = await _pcms_Pdm_TestContext.pdm_role_permissions
                    .Where(rp => userRoles.Contains(rp.role_id.Value) &&
                                rp.permission_id == permission.permission_id &&
                                rp.dev_factory_no == request.DevFactoryNo &&
                                rp.is_active == "Y")
                    .ToListAsync();

                // 4. 取得擴充權限
                var permissionDetails = await _pcms_Pdm_TestContext.pdm_role_permission_details
                    .Where(d => userRoles.Contains(d.role_id.Value) &&
                               d.permission_id == permission.permission_id &&
                               d.dev_factory_no == request.DevFactoryNo)
                    .ToListAsync();

                // 在記憶體中進行分組和判斷
                var extendedPermissions = permissionDetails
                    .GroupBy(d => new { d.permission_key_id, d.permission_key, d.description })
                    .ToDictionary(
                        g => g.Key.permission_key,
                        g => g.Any(x => x.is_active == "Y") ? "Y" : "N"
                    );

                // 5. 建立回傳結果
                var result = new PermissionCheckResultDto
                {
                    PermissionId = permission.permission_id,
                    PermissionName = permission.permission_name,
                    HasPermission = rolePermissions.Any() ? "Y" : "N",
                    OperationPermissions = new Dictionary<string, string>
                    {
                        { "Create", rolePermissions.Any(rp => rp.createp == "Y") ? "Y" : "N" },
                        { "Read", rolePermissions.Any(rp => rp.readp == "Y") ? "Y" : "N" },
                        { "Update", rolePermissions.Any(rp => rp.updatep == "Y") ? "Y" : "N" },
                        { "Delete", rolePermissions.Any(rp => rp.deletep == "Y") ? "Y" : "N" },
                        { "Export", rolePermissions.Any(rp => rp.exportp == "Y") ? "Y" : "N" },
                        { "Import", rolePermissions.Any(rp => rp.importp == "Y") ? "Y" : "N" }
                    },
                    ExtendedPermissions = extendedPermissions
                };

                return APIResponseHelper.GenerateApiResponse("OK", "查詢成功", result);
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<PermissionCheckResultDto>(
                    "50001", $"權限檢查時發生錯誤：{ex.Message}", null);
            }
        }
    }
}