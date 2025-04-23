using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Service.Basic
{
    public class CurrentUserPermissionService : ICurrentUserPermissionService
    {
        private readonly pcms_pdm_testContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CurrentUserPermissionService(
            pcms_pdm_testContext context,
            ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<bool> HasPermissionAsync(int permissionId, string action)
        {
            if (_currentUserService.UserId == null)
            {
                return false;
            }

            // 獲取用戶的角色
            var userRoles = await _context.pdm_user_roles
                .Where(ur => ur.user_id == _currentUserService.UserId)
                .Select(ur => ur.role_id)
                .ToListAsync();

            if (!userRoles.Any())
            {
                return false;
            }

            // 檢查角色權限
            var hasPermission = await _context.pdm_role_permissions
                .Where(rp => userRoles.Contains(rp.role_id.Value) &&
                           rp.permission_id == permissionId &&
                           rp.is_active == "Y")
                .AnyAsync();

            if (!hasPermission)
            {
                return false;
            }

            // 根據不同動作檢查具體權限
            switch (action.ToUpper())
            {
                case "CREATE":
                    return await _context.pdm_role_permissions
                        .AnyAsync(rp => userRoles.Contains(rp.role_id.Value) &&
                                      rp.permission_id == permissionId &&
                                      rp.createp == "Y");
                case "READ":
                    return await _context.pdm_role_permissions
                        .AnyAsync(rp => userRoles.Contains(rp.role_id.Value) &&
                                      rp.permission_id == permissionId &&
                                      rp.readp == "Y");
                case "UPDATE":
                    return await _context.pdm_role_permissions
                        .AnyAsync(rp => userRoles.Contains(rp.role_id.Value) &&
                                      rp.permission_id == permissionId &&
                                      rp.updatep == "Y");
                case "DELETE":
                    return await _context.pdm_role_permissions
                        .AnyAsync(rp => userRoles.Contains(rp.role_id.Value) &&
                                      rp.permission_id == permissionId &&
                                      rp.deletep == "Y");
                case "EXPORT":
                    return await _context.pdm_role_permissions
                        .AnyAsync(rp => userRoles.Contains(rp.role_id.Value) &&
                                      rp.permission_id == permissionId &&
                                      rp.exportp == "Y");
                case "IMPORT":
                    return await _context.pdm_role_permissions
                        .AnyAsync(rp => userRoles.Contains(rp.role_id.Value) &&
                                      rp.permission_id == permissionId &&
                                      rp.importp == "Y");
                default:
                    return false;
            }
        }

        public async Task<bool> HasExtendedPermissionAsync(int permissionId, string permissionKey)
        {
            if (_currentUserService.UserId == null)
            {
                return false;
            }

            // 獲取用戶的角色
            var userRoles = await _context.pdm_user_roles
                .Where(ur => ur.user_id == _currentUserService.UserId)
                .Select(ur => ur.role_id)
                .ToListAsync();

            if (!userRoles.Any())
            {
                return false;
            }

            // 檢查擴充權限
            return await _context.pdm_role_permission_details
                .AnyAsync(d => userRoles.Contains(d.role_id.Value) &&
                              d.permission_id == permissionId &&
                              d.permission_key == permissionKey &&
                              d.is_active == "Y");
        }

        public async Task<Dictionary<string, bool>> GetExtendedPermissionsAsync(int permissionId)
        {
            if (_currentUserService.UserId == null)
            {
                return new Dictionary<string, bool>();
            }

            // 獲取用戶的角色
            var userRoles = await _context.pdm_user_roles
                .Where(ur => ur.user_id == _currentUserService.UserId)
                .Select(ur => ur.role_id)
                .ToListAsync();

            if (!userRoles.Any())
            {
                return new Dictionary<string, bool>();
            }

            // 獲取所有擴充權限
            var extendedPermissions = await _context.pdm_role_permission_details
                .Where(d => userRoles.Contains(d.role_id.Value) &&
                           d.permission_id == permissionId)
                .Select(d => new
                {
                    d.permission_key,
                    d.is_active
                })
                .ToListAsync();

            // 轉換為字典格式
            return extendedPermissions
                .GroupBy(p => p.permission_key)
                .ToDictionary(
                    g => g.Key,
                    g => g.Any(p => p.is_active == "Y")
                );
        }

        public Task<bool> HasPermissionAsync(string permissionKey, string action)
        {
            throw new NotImplementedException();
        }
    }
}
