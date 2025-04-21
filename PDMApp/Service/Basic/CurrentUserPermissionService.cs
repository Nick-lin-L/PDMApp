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
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;
        private readonly ICurrentUserService _currentUser;

        public CurrentUserPermissionService(pcms_pdm_testContext pcms_Pdm_TestContext, ICurrentUserService currentUser)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_TestContext;
            _currentUser = currentUser;
        }

        public async Task<bool> HasPermissionAsync(int permissionId, string action)
        {
            var userId = _currentUser.UserId;
            if (!userId.HasValue)
                return false;

            // 取得使用者角色
            var roleIds = await _pcms_Pdm_TestContext.pdm_user_roles
                .Where(r => r.user_id == userId)
                .Select(r => r.role_id)
                .ToListAsync();

            if (!roleIds.Any())
                return false;

            // 依據 action 轉換欄位名稱
            string column = action.ToLower() switch
            {
                "create" => "createp",
                "read" => "readp",
                "update" => "updatep",
                "delete" => "deletep",
                "export" => "exportp",
                "import" => "importp",
                _ => null
            };

            if (string.IsNullOrEmpty(column))
                return false;

            // 動態查詢對應欄位
            var matched = await _pcms_Pdm_TestContext.pdm_role_permissions
                .Where(p =>
                    roleIds.Contains(p.role_id.Value) &&
                    p.permission_id == permissionId &&
                    EF.Property<string>(p, column) == "Y")
                .AnyAsync();

            return matched;
        }

        public Task<bool> HasPermissionAsync(string permissionKey, string action)
        {
            throw new NotImplementedException();
        }
    }
}
