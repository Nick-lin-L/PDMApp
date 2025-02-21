using Microsoft.Extensions.Logging;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using PDMApp.Repositories.Basic;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Service.Basic
{
    public class RolePermissionService : IRolePermissionService
    {
        /*
        private readonly IRolePermissionRepository _roleRepo;
        private readonly ILogger<RolePermissionService> _logger;

        public RolePermissionService(IRolePermissionRepository roleRepo, ILogger<RolePermissionService> logger)
        {
            _roleRepo = roleRepo;
            _logger = logger;
        }

        public async Task<IDictionary<string, object>> GetRolePageInitialAsync()
        {
            return await _roleRepo.GetRolePageInitialAsync();
        }

        public async Task<PagedResult<pdm_roles>> GetRolesAsync(RolesParameter param)
        {
            return await _roleRepo.GetRolesAsync(param);  // 確保回傳的是 PagedResult<T>
        }


        public async Task<IDictionary<string, object>> UpsertRoleAsync(RolePermissionsParameter request)
        {
            try
            {
                int? roleId = int.TryParse(request.RoleId, out int parsedId) ? parsedId : null;
                pdm_roles role = roleId.HasValue ? await _roleRepo.GetRoleByIdAsync(roleId.Value) : null;

                if (role == null)
                {
                    role = new pdm_roles
                    {
                        role_name = request.RoleName,
                        description = request.Description,
                        is_active = request.IsActive,
                        created_at = DateTime.UtcNow
                    };
                    await _roleRepo.AddRoleAsync(role);
                }
                else
                {
                    role.role_name = request.RoleName ?? role.role_name;
                    role.is_active = request.IsActive ?? role.is_active;
                    role.updated_at = DateTime.UtcNow;
                    await _roleRepo.UpdateRoleAsync(role);
                }

                await _roleRepo.AddOrUpdatePermissionsAsync(role.role_id, request.Permissions);
                await _roleRepo.SaveChangesAsync();

                return new Dictionary<string, object> { { "Role", role } };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating role.");
                throw;
            }
        }
        */
    }
}
