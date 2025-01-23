using Microsoft.AspNetCore.Mvc;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using PDMApp.Utils;
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
                var query = QueryHelper.QueryRoles(_pcms_Pdm_TestContext);
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

        // 2. 查詢角色權限
        [HttpPost("permissions")]
        public IActionResult GetPermissions([FromBody] PermissionQueryRequest request)
        {
            try
            {
                var permissions = _pcms_Pdm_TestContext.pdm_role_permissions
                    .Where(rp => rp.role_id == request.RoleId)
                    .Select(rp => new
                    {
                        rp.permission_id,
                        rp.is_active,
                        rp.createp,
                        rp.readp,
                        rp.updatep,
                        rp.deletep,
                        rp.exportp,
                        rp.importp,
                        rp.dev_factory_no
                    })
                    .ToList();

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
                var role = _pcms_Pdm_TestContext.pdm_roles.FirstOrDefault(r => r.role_id == request.RoleId);
                if (role == null)
                {
                    // 新增角色
                    role = new pdm_roles
                    {
                        role_name = request.RoleName,
                        description = request.Description,
                        dev_factory_no = request.DevFactoryNo,
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
                    role.role_name = request.RoleName;
                    role.description = request.Description;
                    role.dev_factory_no = request.DevFactoryNo;
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

                    /*/ 記錄操作日誌
                    _pcms_Pdm_TestContext.pdm_permission_logs.Add(new pdm_permission_logs
                    {
                        user_id = request.UpdatedBy,
                        role_id = request.RoleId,
                        operation = existingPerm != null ? "Update" : "Add",
                        permission_detail = $"{(existingPerm != null ? "Updated" : "Added")} permission {perm.PermissionId} for role {request.RoleId}.",
                        dev_center = perm.Dev_center,
                        created_at = DateTime.UtcNow
                    });*/
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
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string DevFactoryNo { get; set; }

    }

    public class PermissionQueryRequest
    {
        public int RoleId { get; set; }
    }

    public class RoleRequest
    {
        public int? RoleId { get; set; } // 若為 null 表示新增
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string DevFactoryNo { get; set; }
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
        public bool IsActive { get; set; }
        public bool CreateP { get; set; }
        public bool ReadP { get; set; }
        public bool UpdateP { get; set; }
        public bool DeleteP { get; set; }
        public bool ExportP { get; set; }
        public bool ImportP { get; set; }
        public string DevFactoryNo { get; set; }
    }
}
