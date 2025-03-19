using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using PDMApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Repositories.Basic
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        /*
        private readonly pcms_pdm_testContext _context;

        public RolePermissionRepository(pcms_pdm_testContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<string, object>> GetRolePageInitialAsync()
        {
            var factories = await _context.pdm_factory
                .Select(f => new { f.factory_no, f.factory_name })
                .ToListAsync();

            var permissions = await _context.pdm_role_permissions.ToListAsync();
            var permissionDetails = await _context.pdm_role_permission_details.ToListAsync();

            return new Dictionary<string, object>
        {
            { "DevFactoryNo", factories },
            { "Permissions", permissions },
            { "PermissionDetails", permissionDetails }
        };
        }

        public async Task<PagedResult<pdm_roles>> GetRolesAsync(RolesParameter param)
        {
            var query = _context.pdm_roles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(param.RoleName))
                query = query.Where(r => r.role_name.Contains(param.RoleName));

            return await query
                .OrderBy(r => r.role_id)
                .ToPagedResultAsync(param.Pagination.PageNumber, param.Pagination.PageSize);  // 確保回傳的是 PagedResult<T>
        }

        public async Task<pdm_roles> GetRoleByIdAsync(int roleId)
        {
            return await _context.pdm_roles.FirstOrDefaultAsync(r => r.role_id == roleId);
        }

        public async Task AddRoleAsync(pdm_roles role)
        {
            await _context.pdm_roles.AddAsync(role);
        }

        public async Task UpdateRoleAsync(pdm_roles role)
        {
            _context.pdm_roles.Update(role);
        }

        public async Task AddOrUpdatePermissionsAsync(int roleId, List<PermissionRequest> permissions)
        {
            foreach (var perm in permissions)
            {
                var existingPerm = await _context.pdm_role_permissions
                    .FirstOrDefaultAsync(p => p.permission_id == perm.PermissionId && p.role_id == roleId);

                if (existingPerm != null)
                {
                    existingPerm.is_active = perm.IsActive ?? existingPerm.is_active;
                    existingPerm.updated_at = DateTime.UtcNow;
                }
                else
                {
                    var newPerm = new pdm_role_permissions
                    {
                        role_id = roleId,
                        permission_id = perm.PermissionId,
                        is_active = perm.IsActive,
                        created_at = DateTime.UtcNow
                    };
                    _context.pdm_role_permissions.Add(newPerm);
                }
            }
        }

        public async Task AddOrUpdatePermissionDetailsAsync(int roleId, List<PermissionDetails> details)
        {
            foreach (var detail in details)
            {
                var existingDetail = await _context.pdm_role_permission_details
                    .FirstOrDefaultAsync(d => d.permission_id == detail.PermissionId && d.role_id == roleId);

                if (existingDetail != null)
                {
                    existingDetail.is_active = detail.IsActiveD ?? existingDetail.is_active;
                    existingDetail.updated_at = DateTime.UtcNow;
                }
                else
                {
                    var newDetail = new pdm_role_permission_details
                    {
                        role_id = roleId,
                        permission_id = detail.PermissionId,
                        is_active = detail.IsActiveD,
                        created_at = DateTime.UtcNow
                    };
                    _context.pdm_role_permission_details.Add(newDetail);
                }
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        */
    }
}
