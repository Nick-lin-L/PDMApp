using PDMApp.Dtos;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Dtos.Cbd;
using PDMApp.Dtos.Spec;
using PDMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Utils.BasicProgram
{
    public static class BasicQueryHelper
    {

        public static IQueryable<pdm_rolesDto> QueryRoles (pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from pr in _pcms_Pdm_TestContext.pdm_roles
                    join pur in _pcms_Pdm_TestContext.pdm_user_roles on pr.role_id equals pur.role_id
                    join pu in _pcms_Pdm_TestContext.pdm_users on pur.user_id equals pu.user_id
                    select new pdm_rolesDto
                    {
                        RoleId = pr.role_id,
                        RoleName = pr.role_name,
                        Description = pr.description,
                        DevFactoryNo = pr.dev_factory_no,
                        CreatedAt = pr.created_at,
                        CreatedBy = pu.username,
                        UpdatedAt = pr.updated_at,
                        UpdatedBy = pu.username,
                        IsActive = pr.is_active
                    });

        }

        // 查詢作業、作業權限權限
        public static IQueryable<pdm_permissionsDto> QueryPermissions(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var query = from Pp in _pcms_Pdm_TestContext.pdm_permissions
                        join Prp in _pcms_Pdm_TestContext.pdm_role_permissions on Pp.permission_id equals Prp.permission_id
                        join Pur in _pcms_Pdm_TestContext.pdm_user_roles on Prp.role_id equals Pur.role_id
                        join Pu in _pcms_Pdm_TestContext.pdm_users on Pur.user_id equals Pu.user_id
                        select new
                        {
                            PermissionId = Pp.permission_id,
                            PermissionName = Pp.permission_name,
                            Description = Pp.description,
                            CreatedAt = Pp.created_at,
                            CreatedBy = Pu.username,
                            UpdatedAt = Pp.updated_at,
                            UpdatedBy = Pu.username,
                            RolePermissionId = Prp.role_permission_id,
                            RoleId = Prp.role_id,
                            DevFactoryNo = Prp.dev_factory_no,
                            IsActive = Prp.is_active,
                            Createp = Prp.createp,
                            Readp = Prp.readp,
                            Updatep = Prp.updatep,
                            Deletep = Prp.deletep,
                            Exportp = Prp.exportp,
                            Importp = Prp.importp,
                            Permission1 = Prp.permission1,
                            Permission2 = Prp.permission2,
                            Permission3 = Prp.permission3,
                            Permission4 = Prp.permission4
                        };

            var result = query.ToList().Select(item =>
            {
                // 取得動態權限
                var dynamicPermissions = _pcms_Pdm_TestContext.pdm_role_permission_details
                    .Where(d => d.role_permission_id == item.RolePermissionId)
                    .OrderBy(d=>d.role_permission_detail_id)
                    .ToDictionary(d => d.permission_key, d => d.is_active)
                    ;

                // 回傳合併結果
                return new pdm_permissionsDto
                {
                    PermissionId = item.PermissionId,
                    PermissionName = item.PermissionName,
                    Description = item.Description,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    UpdatedAt = item.UpdatedAt,
                    UpdatedBy = item.UpdatedBy,
                    RolePermissionId = item.RolePermissionId,
                    RoleId = item.RoleId,
                    DevFactoryNo = item.DevFactoryNo,
                    IsActive = item.IsActive,
                    Createp = item.Createp,
                    Readp = item.Readp,
                    Updatep = item.Updatep,
                    Deletep = item.Deletep,
                    Exportp = item.Exportp,
                    Importp = item.Importp,
                    Permission1 = item.Permission1,
                    Permission2 = item.Permission2,
                    Permission3 = item.Permission3,
                    Permission4 = item.Permission4,
                    PermissionDetails = dynamicPermissions // 這裡會是 `Dictionary<string, string>`
                };
            });

            return result.AsQueryable();
        }

        /// <summary>
        /// 廠別下拉，只要是下拉都預設使用pdm_DropDownDto
        /// </summary>
        /// <param name="_pcms_Pdm_TestContext"></param>
        /// <returns></returns>
        public static IQueryable<pdm_DropDownDto> QueryFactory(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from Pf in _pcms_Pdm_TestContext.pdm_factory
                    select new pdm_DropDownDto
                    {
                        Id = Pf.factory_id,
                        Value = Pf.dev_factory_no,
                        Text = Pf.dev_factory_no
                    });
        }
    }
}
