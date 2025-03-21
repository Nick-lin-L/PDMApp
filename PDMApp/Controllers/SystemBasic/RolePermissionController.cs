using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using PDMApp.Utils;
using PDMApp.Utils.BasicProgram;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers
{
    [Route("api/v1/Basic/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        // GET: api/<RolePermissionController>
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public RolePermissionController(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
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
        [HttpPost("upsert")]
        //public async Task<IActionResult> UpsertRolePermission([FromBody] RolePermissionsParameter request)
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> UpsertRolePermission([FromBody] RolePermissionsParameter request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    // 確保 Permissions 和 PermissionDetails 不為 null
                    request.Permissions ??= new List<PermissionRequest>();
                    request.PermissionDetails ??= new List<PermissionDetails>();

                    int? roleId = int.TryParse(request.RoleId, out int parsedId) ? parsedId : null;
                    // **[1] 角色處理**
                    var role = await _pcms_Pdm_TestContext.pdm_roles
                        .FirstOrDefaultAsync(r => roleId.HasValue && r.role_id == roleId.Value);

                    if (role == null)
                    {
                        // 新增角色
                        role = new pdm_roles
                        {
                            role_name = request.RoleName,
                            description = request.Description,
                            dev_factory_no = request.DevFactoryNo,
                            is_active = request.IsActive,
                            created_by = request.UpdatedBy,
                            created_at = DateTime.UtcNow
                        };
                        _pcms_Pdm_TestContext.pdm_roles.Add(role);
                        if (string.IsNullOrWhiteSpace(request.RoleName) || string.IsNullOrWhiteSpace(request.DevFactoryNo))
                        {
                            return APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                                errorCode: "40001",
                                message: "The role name and development factory code must not be empty.",
                                data: null
                            );
                        }
                        await _pcms_Pdm_TestContext.SaveChangesAsync();
                    }
                    else
                    {
                        // 更新角色
                        role.role_name = request.RoleName ?? role.role_name;
                        role.description = request.Description ?? role.description;
                        role.dev_factory_no = request.DevFactoryNo ?? role.dev_factory_no;
                        role.is_active = request.IsActive ?? role.is_active;
                        role.updated_by = request.UpdatedBy;
                        role.updated_at = DateTime.UtcNow;
                    }

                    // **確保 RoleId 正確**
                    int roleIdt = role.role_id;

                    // **[2] 更新 Permissions**
                    foreach (var perm in request.Permissions)
                    {
                        var existingPerm = await _pcms_Pdm_TestContext.pdm_role_permissions
                            .FirstOrDefaultAsync(p => p.permission_id == perm.PermissionId && p.role_id == roleId);

                        if (existingPerm != null)
                        {
                            // 更新權限
                            existingPerm.is_active = perm.IsActiveP ?? existingPerm.is_active;
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
                            existingPerm.updated_by = request.UpdatedBy;
                            existingPerm.updated_at = DateTime.UtcNow;
                        }
                        else
                        {
                            // 新增權限
                            var newPerm = new pdm_role_permissions
                            {
                                role_id = roleIdt,
                                permission_id = perm.PermissionId,
                                is_active = perm.IsActiveP,
                                createp = perm.CreateP,
                                readp = perm.ReadP,
                                updatep = perm.UpdateP,
                                deletep = perm.DeleteP,
                                exportp = perm.ExportP,
                                importp = perm.ImportP,
                                permission1 = perm.Permission1,
                                permission2 = perm.Permission2,
                                permission3 = perm.Permission3,
                                permission4 = perm.Permission4,
                                dev_factory_no = request.DevFactoryNo,
                                created_by = request.UpdatedBy,
                                created_at = DateTime.UtcNow
                            };
                            if (!newPerm.permission_id.HasValue || roleIdt == 0)
                            {
                                return APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                                    errorCode: "40001",
                                    message: "The P.permission_id or RoleID must not be empty.",
                                    data: null
                                );
                            }
                            _pcms_Pdm_TestContext.pdm_role_permissions.Add(newPerm);
                        }
                    }

                    // **[3] 更新 PermissionDetails**
                    foreach (var detail in request.PermissionDetails)
                    {
                        var existingDetail = await _pcms_Pdm_TestContext.pdm_role_permission_details
                            .FirstOrDefaultAsync(d => d.role_id == roleId &&
                              //                              d.permission_id == detail.PermissionId &&
                              d.permission_key_id == detail.PermissionKeyId &&
                              d.dev_factory_no == request.DevFactoryNo);

                        if (existingDetail != null)
                        {
                            // 更新詳細權限
                            existingDetail.is_active = detail.IsActiveD ?? existingDetail.is_active;
                            existingDetail.dev_factory_no = request.DevFactoryNo;
                            existingDetail.permission_key = detail.PermissionKey ?? existingDetail.permission_key;
                            existingDetail.description = detail.DescriptionD ?? existingDetail.description;
                            existingDetail.updated_by = request.UpdatedBy;
                            existingDetail.updated_at = DateTime.UtcNow;
                        }
                        else
                        {
                            // 新增詳細權限
                            var newDetail = new pdm_role_permission_details
                            {
                                role_id = roleIdt,
                                permission_id = detail.PermissionId,
                                permission_key_id = detail.PermissionKeyId,
                                is_active = detail.IsActiveD,
                                description = detail.DescriptionD,
                                dev_factory_no = request.DevFactoryNo,
                                created_by = request.UpdatedBy,
                                created_at = DateTime.UtcNow
                            };/*
                            if (newDetail.permission_id == 0)
                            {
                                return APIResponseHelper.HandleApiError<IDictionary<string, object>>(
                                    errorCode: "40001",
                                    message: "The D.permission_id must not be empty.",
                                    data: null
                                );
                            }*/
                            _pcms_Pdm_TestContext.pdm_role_permission_details.Add(newDetail);
                        }
                    }

                    // **[4] 儲存 & 交易提交**
                    await _pcms_Pdm_TestContext.SaveChangesAsync();
                    scope.Complete();
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



        public class PermissionsWrapper
        {
            public IEnumerable<pdm_permissionsDto> Permissions { get; set; }
        }
    }
}