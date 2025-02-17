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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers
{
    [Route("api/v1/[controller]")]
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
        /// Roles頁面初始化傳入的參數
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
        [HttpPost("permissions")]
        public async Task<ActionResult<APIStatusResponse<IDictionary<string, object>>>> Permissions([FromBody] PermissionsParameter value)
        {
            try
            {
                // permissions 查詢
                var result = await BasicQueryHelper.QueryPermissionsWithDetailsAsync(_pcms_Pdm_TestContext);
                return APIResponseHelper.HandleDynamicMultiPageResponse(result);
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

        // 3. 新增或更新角色資料
        [HttpPost("upsert")]
        public async Task<IActionResult> UpsertRolePermission([FromBody] RolePermissionsParameter request)
        {
            using var transaction = await _pcms_Pdm_TestContext.Database.BeginTransactionAsync();
            try
            {
                // 更新角色基本資訊
                var role = await _pcms_Pdm_TestContext.pdm_roles
                    .FirstOrDefaultAsync(r => r.role_id == request.RoleId);
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

                // 更新 Permissions
                foreach (var perm in request.Permissions)
                {
                    var existingPerm = await _pcms_Pdm_TestContext.pdm_role_permissions
                        .FirstOrDefaultAsync(p => p.permission_id == perm.PermissionId && p.role_id == request.RoleId);

                    if (existingPerm != null)
                    {
                        // 更新權限
                        existingPerm.is_active = perm.IsActive ?? existingPerm.is_active;
                        existingPerm.createp = perm.CreateP ?? existingPerm.createp;
                        existingPerm.readp = perm.ReadP ?? existingPerm.readp;
                        existingPerm.updated_at = DateTime.UtcNow;
                    }
                    else
                    {
                        // 新增權限
                        var newPerm = new pdm_role_permissions
                        {
                            role_id = request.RoleId,
                            permission_id = perm.PermissionId,
                            is_active = perm.IsActive,
                            createp = perm.CreateP,
                            readp = perm.ReadP,
                            created_by = request.UpdatedBy,
                            created_at = DateTime.UtcNow
                        };
                        _pcms_Pdm_TestContext.pdm_role_permissions.Add(newPerm);
                    }
                }

                // 更新 PermissionDetails
                foreach (var detail in request.PermissionDetails)
                {
                    var existingDetail = await _pcms_Pdm_TestContext.pdm_role_permission_details
                        .FirstOrDefaultAsync(d => d.role_permission_detail_id == detail.RolePermissionDetailsId);

                    if (existingDetail != null)
                    {
                        // 更新詳細權限
                        existingDetail.is_active = detail.IsActiveD ?? existingDetail.is_active;
                        existingDetail.updated_at = DateTime.UtcNow;
                    }
                    else
                    {
                        // 新增詳細權限
                        var newDetail = new pdm_role_permission_details
                        {
                            role_id = request.RoleId,
                            permission_id = detail.PermissionId,
                            permission_key = detail.PermissionKey,
                            is_active = detail.IsActiveD,
                            created_by = request.UpdatedBy,
                            created_at = DateTime.UtcNow
                        };
                        _pcms_Pdm_TestContext.pdm_role_permission_details.Add(newDetail);
                    }
                }

                await _pcms_Pdm_TestContext.SaveChangesAsync();
                await transaction.CommitAsync();  // 交易提交
                return Ok("Role and permissions updated successfully.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();  // 交易回滾
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }



        private void UpdateRolePermission(pdm_role_permissions existingPerm, PermissionRequest perm, int updatedBy)
        {
            bool isModified = false;

            if (existingPerm.is_active != perm.IsActive)
            {
                existingPerm.is_active = perm.IsActive;
                isModified = true;
            }
            if (existingPerm.createp != perm.CreateP)
            {
                existingPerm.createp = perm.CreateP;
                isModified = true;
            }
            if (existingPerm.readp != perm.ReadP)
            {
                existingPerm.readp = perm.ReadP;
                isModified = true;
            }
            if (existingPerm.updatep != perm.UpdateP)
            {
                existingPerm.updatep = perm.UpdateP;
                isModified = true;
            }
            if (existingPerm.deletep != perm.DeleteP)
            {
                existingPerm.deletep = perm.DeleteP;
                isModified = true;
            }
            if (existingPerm.exportp != perm.ExportP)
            {
                existingPerm.exportp = perm.ExportP;
                isModified = true;
            }
            if (existingPerm.importp != perm.ImportP)
            {
                existingPerm.importp = perm.ImportP;
                isModified = true;
            }
            if (existingPerm.dev_factory_no != perm.DevFactoryNo)
            {
                existingPerm.dev_factory_no = perm.DevFactoryNo;
                isModified = true;
            }

            if (isModified)
            {
                existingPerm.updated_by = updatedBy;
                existingPerm.updated_at = DateTime.UtcNow;
            }
        }
    }
    public class PermissionsWrapper
    {
        public IEnumerable<pdm_permissionsDto> Permissions { get; set; }
    }
}
