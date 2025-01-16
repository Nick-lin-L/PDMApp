using Microsoft.AspNetCore.Mvc;
using PDMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult GetRoles([FromBody] RoleRequest request)
        {
            try
            {
                var roles = _pcms_Pdm_TestContext.pdm_roles
                    .Where(r => string.IsNullOrEmpty(request.Factory) || r.factory == request.Factory)
                    .Where(r=> string.IsNullOrEmpty(request.RoleName) || r.role_name == request.RoleName)
                    .Where(r => string.IsNullOrEmpty(request.Description) || r.description.Contains(request.Description))
                    .Select(r => new
                    {
                        r.role_id,
                        r.role_name,
                        r.description,
                        r.factory
                    })
                    .ToList().OrderBy(r=>r.role_id);

                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // 2. 查詢角色權限
        [HttpPost("permissions")]
        public IActionResult GetPermissions([FromBody] PermissionQueryRequest request)
        {
            try
            {
                int? roleId = null;
                if (!string.IsNullOrWhiteSpace(request.RoleId) && int.TryParse(request.RoleId, out var parsedRoleId))
                {
                    roleId = parsedRoleId;
                }

                var permissions = _pcms_Pdm_TestContext.pdm_role_permissions
                    .Where(rp => !roleId.HasValue || rp.role_id == roleId)
                    .Select(rp => new
                    {
                        rp.role_permission_id,
                        rp.role_id,
                        rp.permission_id,
                        rp.is_active,
                        rp.createp,
                        rp.readp,
                        rp.updatep,
                        rp.deletep,
                        rp.exportp,
                        rp.importp,
                        rp.factory
                    })
                    .ToList().OrderBy(rp => rp.role_permission_id)
                    .ThenBy(rp => rp.role_id)
                    .ThenBy(rp => rp.permission_id);

                return Ok(new { RoleId = request.RoleId, Permissions = permissions });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // 3. 新增或更新角色資料
        [HttpPost("roles/update")]
        public async Task<IActionResult> AddOrUpdateRole([FromBody] RoleRequest request)
        {
            try
            {
                var user = _pcms_Pdm_TestContext.pdm_users_new.FirstOrDefault(u => u.user_id == request.UpdatedBy);
                if (user == null)
                {
                    return BadRequest($"更新者 '{request.UpdatedBy}' 不存在於使用者表中。");
                }
                var role = _pcms_Pdm_TestContext.pdm_roles.FirstOrDefault(r => r.role_id == request.RoleId);
                if (role == null)
                {
                    // 新增角色
                    role = new pdm_roles
                    {
                        role_name = request.RoleName,
                        description = request.Description,
                        factory = request.Factory ?? "default",
                        created_by = request.UpdatedBy,
                        created_at = DateTime.UtcNow,
                        updated_by = request.UpdatedBy,
                        updated_at = DateTime.UtcNow
                    };
                    _pcms_Pdm_TestContext.pdm_roles.Add(role);
                }
                else
                {
                    // 更新角色
                    role.role_name = request.RoleName ?? role.role_name;
                    role.description = request.Description ?? role.description;
                    role.factory = request.Factory ?? role.factory;
                    role.updated_by = request.UpdatedBy;
                    role.updated_at = DateTime.UtcNow;
                }

                await _pcms_Pdm_TestContext.SaveChangesAsync();
                return Ok("Role processed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
        // 4. 刪除角色資料
        [HttpPost("roles/delete")]
        public async Task<IActionResult> DeleteRole([FromBody] RoleDeleteRequest request)
        {
            try
            {
                // 驗證使用者
                var user = _pcms_Pdm_TestContext.pdm_users_new.FirstOrDefault(u => u.user_id == request.DeletedBy);
                if (user == null)
                {
                    return BadRequest($"刪除者 '{request.DeletedBy}' 不存在於使用者表中。");
                }

                // 查找角色
                var role = _pcms_Pdm_TestContext.pdm_roles.FirstOrDefault(r => r.role_id == request.RoleId);
                if (role == null)
                {
                    return NotFound($"角色 ID {request.RoleId} 不存在，無法刪除。");
                }
                _pcms_Pdm_TestContext.pdm_roles.Remove(role);

                // 級聯刪除關聯的權限記錄
                var rolePermissions = _pcms_Pdm_TestContext.pdm_role_permissions
                    .Where(rp => rp.role_id == request.RoleId)
                    .ToList();
                _pcms_Pdm_TestContext.pdm_role_permissions.RemoveRange(rolePermissions);
                /*
                // 邏輯刪除
                role.is_active = false;
                role.updated_by = request.DeletedBy;
                role.updated_at = DateTime.UtcNow;
                */
                // 保存更改
                await _pcms_Pdm_TestContext.SaveChangesAsync();
                return Ok($"角色 ID {request.RoleId} 已成功刪除。");
                //return Ok($"角色 ID {request.RoleId} 已成功刪除（邏輯刪除）。");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // 5. 新增或更新權限設定
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
                        existingPerm.factory = perm.Factory ?? existingPerm.factory;
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
                            is_active = perm.IsActive ?? true, // 預設為 true
                            createp = perm.CreateP ?? false,
                            readp = perm.ReadP ?? false,
                            updatep = perm.UpdateP ?? false,
                            deletep = perm.DeleteP ?? false,
                            exportp = perm.ExportP ?? false,
                            importp = perm.ImportP ?? false,
                            permission1 = perm.Permission1 ?? false,
                            permission2 = perm.Permission2 ?? false,
                            permission3 = perm.Permission3 ?? false,
                            permission4 = perm.Permission4 ?? false,
                            factory = perm.Factory ?? "DEFAULT",
                            created_by = request.UpdatedBy,
                            created_at = DateTime.UtcNow,
                            updated_by = request.UpdatedBy,
                            updated_at = DateTime.UtcNow
                        };

                        _pcms_Pdm_TestContext.pdm_role_permissions.Add(newPerm);
                    }

                    // 記錄操作日誌
                    _pcms_Pdm_TestContext.pdm_permission_logs.Add(new pdm_permission_logs
                    {
                        user_id = request.UpdatedBy,
                        role_id = request.RoleId,
                        operation = existingPerm != null ? "Update" : "Add",
                        permission_detail = $"{(existingPerm != null ? "Updated" : "Added")} permission {perm.PermissionId} for role {request.RoleId}.",
                        factory = perm.Factory ?? "default",
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
        }
    }
    public class RoleQueryRequest
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string Factory { get; set; }
    }

    public class PermissionQueryRequest
    {
        public string? RoleId { get; set; }
    }

    public class RoleRequest
    {
        public int? RoleId { get; set; } // 若為 null 表示新增
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string Factory { get; set; }
        public long UpdatedBy { get; set; }
    }

    public class PermissionUpdateRequest
    {
        public int RoleId { get; set; }
        public List<PermissionRequest> Permissions { get; set; }
        public long UpdatedBy { get; set; }
    }

    public class PermissionRequest
    {
        public int PermissionId { get; set; }
        public bool? IsActive { get; set; }
        public bool? CreateP { get; set; }
        public bool? ReadP { get; set; }
        public bool? UpdateP { get; set; }
        public bool? DeleteP { get; set; }
        public bool? ExportP { get; set; }
        public bool? ImportP { get; set; }
        public bool? Permission1 { get; set; }
        public bool? Permission2 { get; set; }
        public bool? Permission3 { get; set; }
        public bool? Permission4 { get; set; }
        public string Factory { get; set; }
    }


    public class RoleDeleteRequest
    {
        public int RoleId { get; set; }
        public long DeletedBy { get; set; } // 刪除操作的執行者
    }

}
