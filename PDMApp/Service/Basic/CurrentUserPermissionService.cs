using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
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
        private readonly IMemoryCache _cache;
        private readonly ILogger<CurrentUserPermissionService> _logger;

        // 快取時間設定
        private static readonly TimeSpan CACHE_DURATION = TimeSpan.FromMinutes(10);

        private const string CACHE_KEYS_LIST = "permission_cache_keys";

        public CurrentUserPermissionService(
            pcms_pdm_testContext context,
            ICurrentUserService currentUserService,
            IMemoryCache cache,
            ILogger<CurrentUserPermissionService> logger)
        {
            _context = context;
            _currentUserService = currentUserService;
            _cache = cache;
            _logger = logger;
        }

        // 在設定快取時記錄快取鍵
        private void SetCacheWithKey(string key, object value)
        {
            _cache.Set(key, value, CACHE_DURATION);

            // 記錄快取鍵
            var cacheKeys = _cache.Get<HashSet<string>>(CACHE_KEYS_LIST) ?? new HashSet<string>();
            cacheKeys.Add(key);
            _cache.Set(CACHE_KEYS_LIST, cacheKeys);
        }

        public async Task<bool> HasPermissionAsync(int permissionId, string action)
        {
            try
            {
                // 1. 檢查用戶是否登入
                if (_currentUserService.UserId == null)
                {
                    return false;
                }

                // 2. 檢查快取
                var cacheKey = $"permission_{_currentUserService.UserId}_{permissionId}_{action.ToUpper()}";
                if (_cache.TryGetValue(cacheKey, out bool cachedResult))
                {
                    return cachedResult;
                }

                // 3. 獲取用戶角色（使用快取）
                var userRoles = await GetUserRolesAsync();
                if (!userRoles.Any())
                {
                    return false;
                }

                // 4. 單次查詢所有需要的權限資訊
                var permissions = await _context.pdm_role_permissions
                    .Where(rp => userRoles.Contains(rp.role_id.Value) &&
                               rp.permission_id == permissionId &&
                               rp.is_active == "Y")
                    .Select(rp => new
                    {
                        rp.createp,
                        rp.readp,
                        rp.updatep,
                        rp.deletep,
                        rp.exportp,
                        rp.importp,
                        rp.dev_factory_no
                    })
                    .ToListAsync();

                if (!permissions.Any())
                {
                    return false;
                }

                // 5. 在記憶體中判斷權限
                var result = permissions.Any(p => action.ToUpper() switch
                {
                    "CREATE" => p.createp == "Y",
                    "READ" => p.readp == "Y",
                    "UPDATE" => p.updatep == "Y",
                    "DELETE" => p.deletep == "Y",
                    "EXPORT" => p.exportp == "Y",
                    "IMPORT" => p.importp == "Y",
                    _ => false
                });

                // 6. 設定快取
                SetCacheWithKey(cacheKey, result);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "權限檢查失敗: UserId={UserId}, PermissionId={PermissionId}, Action={Action}",
                    _currentUserService.UserId,
                    permissionId,
                    action);
                return false;
            }
        }

        // 快取用戶角色
        private async Task<List<int>> GetUserRolesAsync()
        {
            var cacheKey = $"user_roles_{_currentUserService.UserId}";

            if (_cache.TryGetValue(cacheKey, out List<int> cachedRoles))
            {
                return cachedRoles;
            }

            var roles = await _context.pdm_user_roles
                .Where(ur => ur.user_id == _currentUserService.UserId)
                .Select(ur => ur.role_id.Value)
                .ToListAsync();

            // 設定快取時使用新方法
            SetCacheWithKey(cacheKey, roles);

            return roles;
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

            // 檢查擴充權限，將 permissionKey 轉為大寫
            return await _context.pdm_role_permission_details
                .AnyAsync(d => userRoles.Contains(d.role_id.Value) &&
                              d.permission_id == permissionId &&
                              d.permission_key.ToUpper() == permissionKey.ToUpper() &&
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
