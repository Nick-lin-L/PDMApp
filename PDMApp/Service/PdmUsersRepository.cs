using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PDMApp.Service
{
    public class PdmUsersRepository
    {
        private readonly pcms_pdm_testContext _pcms_Pdm_TestContext;

        public PdmUsersRepository(pcms_pdm_testContext pcms_Pdm_testContext)
        {
            _pcms_Pdm_TestContext = pcms_Pdm_testContext;
        }

        public async Task<pdm_users> GetByPccuid(decimal? pccuid)
        {
            return await _pcms_Pdm_TestContext.pdm_users.FirstOrDefaultAsync(u => u.pccuid == pccuid);
        }

        public async Task AddUser(pdm_users user)
        {
            _pcms_Pdm_TestContext.pdm_users.Add(user);
            await _pcms_Pdm_TestContext.SaveChangesAsync();
        }

        public async Task UpdateUser(pdm_users user)
        {
            _pcms_Pdm_TestContext.pdm_users.Update(user);
            await _pcms_Pdm_TestContext.SaveChangesAsync();
        }

        public async Task<List<string>> GetUserFactories(long userId)
        {
            // 使用 EF Core 的方式
            return await _pcms_Pdm_TestContext.pdm_user_roles
                .Where(ur => ur.user_id == userId)
                .Join(_pcms_Pdm_TestContext.pdm_role_permissions,
                    ur => ur.role_id,
                    rp => rp.role_id,
                    (ur, rp) => rp.dev_factory_no)
                .Distinct()
                .ToListAsync();

            // Dapper 的方式，一樣
            /*
            using (var connection = _context.CreateConnection())
            {
                var sql = @"
                    SELECT DISTINCT rp.dev_factory_no 
                    FROM pdm_user_roles ur
                    JOIN pdm_role_permissions rp ON ur.role_id = rp.role_id
                    WHERE ur.user_id = @UserId
                    AND ur.is_active = 'Y'
                    AND rp.is_active = 'Y'";

                var factories = await connection.QueryAsync<string>(sql, new { UserId = userId });
                return factories.ToList();
            }
            */
        }

        public class UserPermissionResultDto
        {
            public List<MenuTreeNodeDto> Menus { get; set; } = new(); // 用來組成 Tree Menu
            public Dictionary<string, ModuleCrudPermissionDto> ModulePermissions { get; set; } = new(); // CRUD 權限
            public HashSet<string> PermissionKeys { get; set; } = new(); // optional: 按鈕權限
        }

        public async Task<UserPermissionResultDto> GetUserPermissionTreeAsync(long userId, string devFactoryNo)
        {
            var result = new UserPermissionResultDto();

            // 1.查出使用者的角色 ID
            var roleIds = await _pcms_Pdm_TestContext.pdm_user_roles
                .Where(ur => ur.user_id == userId)
                .Select(ur => ur.role_id)
                .Distinct()
                .ToListAsync();

            if (!roleIds.Any())
                return result; // 無角色，直接回傳空結果

            // 2.查出該使用者在此廠別的所有權限（readp = 'Y'）
            var rolePermissions = await _pcms_Pdm_TestContext.pdm_role_permissions
                .Where(rp => roleIds.Contains(rp.role_id.Value)
                             && rp.dev_factory_no == devFactoryNo
                             && rp.is_active == "Y"
                             && rp.readp == "Y")
                .ToListAsync();

            if (!rolePermissions.Any())
                return result;

            // 取得所有 permission_id（查 menu 用）
            var permissionIds = rolePermissions
                .Where(rp => rp.permission_id.HasValue)
                .Select(rp => rp.permission_id.Value)
                .Distinct()
                .ToList();

            // 3.查出對應 sys_menus（使用 permission_id）
            var menus = await _pcms_Pdm_TestContext.sys_menus
                .Where(m => m.permission_id.HasValue &&
                            permissionIds.Contains(m.permission_id.Value) &&
                            m.is_active == "Y")
                .OrderBy(m => m.sort_order)
                .ToListAsync();

            // 將 menus 轉為 DTO
            var menuDtoList = menus.Select(m => new MenuTreeNodeDto
            {
                MenuId = m.menu_id,
                MenuName = m.menu_name,
                MenuPath = m.menu_path,
                ComponentPath = m.component_path,
                MenuIcon = m.menu_icon,
                MenuType = m.menu_type,
                PermissionKey = m.permission_key,
                SortOrder = m.sort_order,
            }).ToList();

            // 4.組 Tree 結構（根據 parent_id）
            var tree = BuildMenuTree(menuDtoList, null);
            result.Menus = tree;

            // 5.組 CRUD 權限（以 permission_id 分組 → union 權限）
            var permissionGroups = rolePermissions
                .GroupBy(rp => rp.permission_id)
                .ToDictionary(g => g.Key, g =>
                {
                    return new ModuleCrudPermissionDto
                    {
                        Create = g.Any(x => x.createp == "Y"),
                        Read = g.Any(x => x.readp == "Y"),
                        Update = g.Any(x => x.updatep == "Y"),
                        Delete = g.Any(x => x.deletep == "Y"),
                        Export = g.Any(x => x.exportp == "Y"),
                        Import = g.Any(x => x.importp == "Y")
                    };
                });

            // 6.把 CRUD 權限填入 result（key = permission_name）
            var permissionMap = await _pcms_Pdm_TestContext.pdm_permissions
                .Where(p => permissionIds.Contains(p.permission_id))
                .ToDictionaryAsync(p => p.permission_id, p => p.permission_name);

            foreach (var pid in permissionGroups.Keys)
            {
                if (permissionMap.ContainsKey((int)pid))
                {
                    var permissionName = permissionMap[(int)pid];
                    result.ModulePermissions[permissionName] = permissionGroups[pid];
                }
            }

            // 7 可選：撈按鈕權限 key（如果有需要）
            var permissionKeys = await _pcms_Pdm_TestContext.pdm_role_permission_details
                .Where(d => roleIds.Contains(d.role_id.Value)
                            && d.dev_factory_no == devFactoryNo
                            && d.is_active == "Y")
                .Select(d => d.permission_key)
                .Distinct()
                .ToListAsync();

            result.PermissionKeys = permissionKeys.Where(k => !string.IsNullOrEmpty(k)).ToHashSet();

            return result;
        }

        private List<MenuTreeNodeDto> BuildMenuTree(List<MenuTreeNodeDto> allMenus, int? parentId)
        {
            return allMenus
                .Where(m => (m.MenuId != m.MenuId) && ((parentId == null && m.MenuId == m.MenuId) || m.MenuId == parentId))
                .OrderBy(m => m.SortOrder)
                .Select(m => new MenuTreeNodeDto
                {
                    MenuId = m.MenuId,
                    MenuName = m.MenuName,
                    MenuPath = m.MenuPath,
                    ComponentPath = m.ComponentPath,
                    MenuIcon = m.MenuIcon,
                    MenuType = m.MenuType,
                    PermissionKey = m.PermissionKey,
                    SortOrder = m.SortOrder,
                    Children = BuildMenuTree(allMenus, m.MenuId) // 遞迴找子節點
                }).ToList();
        }
    }
}
