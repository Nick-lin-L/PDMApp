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


        // 1. 查詢角色列表
        [HttpPost("roles")]
        //public IActionResult Roles([FromBody] RoleQueryRequest request)
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

                if (!string.IsNullOrWhiteSpace(value.IsActive?.ToString()))
                {
                    bool isActive;
                    if (bool.TryParse(value.IsActive.ToString(), out isActive))
                    {
                        filters.Add(proles => proles.IsActive == isActive);
                    }
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
                    message: $"匯出過程中發生錯誤: {ex.Message}",
                    data: null
                ));
            }
        }

        // 2. 查詢權限列表
        [HttpPost("permissions")]
        //public IActionResult Permissions([FromBody] PermissionQueryRequest request)
        public async Task<ActionResult<APIStatusResponse<PagedResult<pdm_permissionsDto>>>> Permissions([FromBody] PermissionsParameter value)
        {
            try
            {
                var query = BasicQueryHelper.QueryPermissions(_pcms_Pdm_TestContext);
                var filters = new List<Expression<Func<pdm_permissionsDto, bool>>>();

                if (!string.IsNullOrWhiteSpace(value.PermissionId)) // 判斷字串是否非空
                {
                    if (int.TryParse(value.PermissionId, out int permissionId)) // 將字串轉為整數
                    {
                        filters.Add(ppe => ppe.PermissionId == permissionId);
                    }
                }
                if (!string.IsNullOrWhiteSpace(value.PermissionName))
                    filters.Add(ppe => ppe.PermissionName.Contains(value.PermissionName));
                if (!string.IsNullOrWhiteSpace(value.Description))
                    filters.Add(ppe => ppe.Description.Contains(value.Description));

                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }

                // 排序,如果需要多重排序的話後面接.ThenBy(條件)即可
                //query = query.OrderBy(proles => proles.RoleId);
                var pagedResult = await query.Distinct().OrderBy(ppe => ppe.PermissionId)
                                             .ToPagedResultAsync(value.Pagination.PageNumber, value.Pagination.PageSize);

                return APIResponseHelper.HandlePagedApiResponse(pagedResult);
            }
            catch (Exception ex)
            {
                return new ObjectResult(APIResponseHelper.HandleApiError<object>(
                    errorCode: "10001",
                    message: $"匯出過程中發生錯誤: {ex.Message}",
                    data: null
                ));
            }
        }


        // 3. 新增或更新角色資料
        [HttpPost("upsert")]
        public async Task<IActionResult> UpsertRolePermission([FromBody] RoleRequest request)
        {
            using (var transaction = await _pcms_Pdm_TestContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (!int.TryParse(request.UpdatedBy, out int updatedBy))
                    {
                        return BadRequest("Invalid UpdatedBy value.");
                    }

                    pdm_roles role;

                    if (string.IsNullOrWhiteSpace(request.RoleId))
                    {
                        role = new pdm_roles
                        {
                            role_name = request.RoleName,
                            description = request.Description,
                            dev_factory_no = request.DevFactoryNo,
                            created_by = updatedBy,
                            created_at = DateTime.UtcNow,
                            updated_by = updatedBy,
                            updated_at = DateTime.UtcNow,
                            is_active = true
                        };
                        _pcms_Pdm_TestContext.pdm_roles.Add(role);
                        await _pcms_Pdm_TestContext.SaveChangesAsync();
                    }
                    else
                    {
                        if (!int.TryParse(request.RoleId, out int roleId))
                        {
                            return BadRequest($"Invalid RoleId: {request.RoleId}");
                        }

                        role = await _pcms_Pdm_TestContext.pdm_roles
                            .Include(r => r.pdm_role_permissions)
                            .FirstOrDefaultAsync(r => r.role_id == roleId);

                        if (role == null)
                        {
                            return NotFound($"Role with ID {request.RoleId} does not exist.");
                        }

                        bool isModified = false;

                        if (role.role_name != request.RoleName && !string.IsNullOrWhiteSpace(request.RoleName))
                        {
                            role.role_name = request.RoleName;
                            isModified = true;
                        }
                        if (role.description != request.Description && !string.IsNullOrWhiteSpace(request.Description))
                        {
                            role.description = request.Description;
                            isModified = true;
                        }
                        if (role.dev_factory_no != request.DevFactoryNo && !string.IsNullOrWhiteSpace(request.DevFactoryNo))
                        {
                            role.dev_factory_no = request.DevFactoryNo;
                            isModified = true;
                        }
                        if (role.is_active != request.IsActive)
                        {
                            role.is_active = request.IsActive ?? role.is_active;
                            isModified = true;
                        }

                        if (isModified)
                        {
                            role.updated_by = updatedBy;
                            role.updated_at = DateTime.UtcNow;
                            await _pcms_Pdm_TestContext.SaveChangesAsync();
                        }
                    }

                    if (request.Permissions != null && request.Permissions.Any())
                    {
                        foreach (var perm in request.Permissions)
                        {
                            var existingPerm = _pcms_Pdm_TestContext.pdm_role_permissions
                                .FirstOrDefault(rp => rp.role_id == role.role_id && rp.permission_id == perm.PermissionId);

                            if (existingPerm != null)
                            {
                                bool permModified = false;

                                if (existingPerm.is_active != perm.IsActive)
                                {
                                    existingPerm.is_active = perm.IsActive;
                                    permModified = true;
                                }
                                if (existingPerm.createp != perm.CreateP)
                                {
                                    existingPerm.createp = perm.CreateP;
                                    permModified = true;
                                }
                                if (existingPerm.readp != perm.ReadP)
                                {
                                    existingPerm.readp = perm.ReadP;
                                    permModified = true;
                                }
                                if (existingPerm.updatep != perm.UpdateP)
                                {
                                    existingPerm.updatep = perm.UpdateP;
                                    permModified = true;
                                }
                                if (existingPerm.deletep != perm.DeleteP)
                                {
                                    existingPerm.deletep = perm.DeleteP;
                                    permModified = true;
                                }
                                if (existingPerm.exportp != perm.ExportP)
                                {
                                    existingPerm.exportp = perm.ExportP;
                                    permModified = true;
                                }
                                if (existingPerm.importp != perm.ImportP)
                                {
                                    existingPerm.importp = perm.ImportP;
                                    permModified = true;
                                }

                                if (permModified)
                                {
                                    existingPerm.updated_by = updatedBy;
                                    existingPerm.updated_at = DateTime.UtcNow;
                                }
                            }
                            else
                            {
                                var newPerm = new pdm_role_permissions
                                {
                                    role_id = role.role_id,
                                    permission_id = perm.PermissionId,
                                    is_active = perm.IsActive,
                                    createp = perm.CreateP,
                                    readp = perm.ReadP,
                                    updatep = perm.UpdateP,
                                    deletep = perm.DeleteP,
                                    exportp = perm.ExportP,
                                    importp = perm.ImportP,
                                    dev_factory_no = perm.DevFactoryNo,
                                    created_by = updatedBy,
                                    created_at = DateTime.UtcNow,
                                    updated_by = updatedBy,
                                    updated_at = DateTime.UtcNow
                                };
                                _pcms_Pdm_TestContext.pdm_role_permissions.Add(newPerm);
                            }
                        }
                        await _pcms_Pdm_TestContext.SaveChangesAsync();
                    }

                    await transaction.CommitAsync();
                    return Ok(new { Message = "角色及權限處理成功", RoleId = role.role_id });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return HandleError("10001", "處理過程中發生錯誤", ex);
                }
            }
        }

            /*
                    // 4. 新增或更新權限設定
                    [HttpPost("permissions/update")]
                    public async Task<IActionResult> UpdatePermissions([FromBody] PermissionUpdateRequest request)
                    {
                        try
                        {
                            // 確認角色存在
                            var role = await _pcms_Pdm_TestContext.pdm_roles.FindAsync(request.RoleId);
                            if (role == null)
                            {
                                return NotFound($"Role ID {request.RoleId} 不存在");
                            }

                            // 更新或新增權限設定
                            foreach (var perm in request.Permissions)
                            {
                                var existingPerm = _pcms_Pdm_TestContext.pdm_role_permissions
                                    .FirstOrDefault(rp => rp.role_id == request.RoleId && rp.permission_id == perm.PermissionId);

                                if (existingPerm != null)
                                {
                                    // 更新權限設定
                                    existingPerm.is_active = perm.IsActive;
                                    existingPerm.createp = perm.CreateP;
                                    existingPerm.readp = perm.ReadP;
                                    existingPerm.updatep = perm.UpdateP;
                                    existingPerm.deletep = perm.DeleteP;
                                    existingPerm.exportp = perm.ExportP;
                                    existingPerm.importp = perm.ImportP;
                                    existingPerm.dev_factory_no = perm.DevFactoryNo;
                                    existingPerm.updated_by = request.UpdatedBy;
                                    existingPerm.updated_at = DateTime.UtcNow;
                                }
                                else
                                {
                                    // 新增權限設定
                                    var newPerm = new pdm_role_permissions
                                    {
                                        role_id = request.RoleId,
                                        permission_id = perm.PermissionId,
                                        is_active = perm.IsActive,
                                        createp = perm.CreateP,
                                        readp = perm.ReadP,
                                        updatep = perm.UpdateP,
                                        deletep = perm.DeleteP,
                                        exportp = perm.ExportP,
                                        importp = perm.ImportP,
                                        dev_factory_no = perm.DevFactoryNo,
                                        created_by = request.UpdatedBy,
                                        created_at = DateTime.UtcNow,
                                        updated_by = request.UpdatedBy,
                                        updated_at = DateTime.UtcNow
                                    };
                                    _pcms_Pdm_TestContext.pdm_role_permissions.Add(newPerm);
                                }

                                 記錄操作日誌
                                _pcms_Pdm_TestContext.pdm_permission_logs.Add(new pdm_permission_logs
                                {
                                    user_id = request.UpdatedBy,
                                    role_id = request.RoleId,
                                    operation = existingPerm != null ? "Update" : "Add",
                                    permission_detail = $"{(existingPerm != null ? "Updated" : "Added")} permission {perm.PermissionId} for role {request.RoleId}.",
                                    dev_center = perm.Dev_center,
                                    created_at = DateTime.UtcNow
                                });
                            }

                            await _pcms_Pdm_TestContext.SaveChangesAsync();
                            return Ok("Permissions updated successfully.");
                        }
                        catch (Exception ex)
                        {
                            return StatusCode(500, $"Error: {ex.Message}");
                        }
                    }*/
            private IActionResult HandleError(string errorCode, string message, Exception ex)
        {
            return new ObjectResult(new
            {
                ErrorCode = errorCode,
                Message = $"{message}: {ex.Message}",
                Data = (object)null
            })
            {
                StatusCode = 500
            };
        }
    }
    public class RoleRequest
    {
        public string? RoleId { get; set; } // 角色 ID（新增時為 null）
        public string? RoleName { get; set; } // 角色名稱
        public string? Description { get; set; } // 角色描述
        public string? DevFactoryNo { get; set; } // 開發工廠編號
        public bool? IsActive { get; set; } // 是否生效
        public string? UpdatedBy { get; set; } // 更新者 ID
        public List<PermissionRequest> Permissions { get; set; } // 權限列表
    }

    public class PermissionRequest
    {
        public int PermissionId { get; set; } // 權限 ID
        public bool IsActive { get; set; } // 是否啟用
        public bool CreateP { get; set; } // 新增權限
        public bool ReadP { get; set; } // 讀取權限
        public bool UpdateP { get; set; } // 更新權限
        public bool DeleteP { get; set; } // 刪除權限
        public bool ExportP { get; set; } // 匯出權限
        public bool ImportP { get; set; } // 匯入權限
        public string DevFactoryNo { get; set; } // 開發工廠編號
    }
}
