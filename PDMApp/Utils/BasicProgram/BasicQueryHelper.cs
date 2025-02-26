using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Dtos.Cbd;
using PDMApp.Dtos.Spec;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Utils.BasicProgram
{
    public static class BasicQueryHelper
    {

        public static IQueryable<pdm_rolesDto> QueryRoles(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from pr in _pcms_Pdm_TestContext.pdm_roles
                    select new pdm_rolesDto
                    {
                        RoleId = pr.role_id,
                        RoleName = pr.role_name,
                        Description = pr.description,
                        DevFactoryNo = pr.dev_factory_no,
                        CreatedAt = pr.created_at,
                        CreatedBy = "",
                        UpdatedAt = pr.updated_at,
                        UpdatedBy = "",
                        IsActive = pr.is_active
                    });

        }

        // 查詢作業、作業權限權限
        public static IQueryable<pdm_permissionsDto> QueryPermissions(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from Pp in _pcms_Pdm_TestContext.pdm_permissions
                    join Prp in _pcms_Pdm_TestContext.pdm_role_permissions on Pp.permission_id equals Prp.permission_id
                    join Pur in _pcms_Pdm_TestContext.pdm_user_roles on Prp.role_id equals Pur.role_id
                    join Pu in _pcms_Pdm_TestContext.pdm_users on Pur.user_id equals Pu.user_id
                    select new pdm_permissionsDto
                    {
                        PermissionId = Pp.permission_id,
                        PermissionName = Pp.permission_name,
                        Description = Pp.description,
                        CreatedAt = Pp.created_at,
                        CreatedBy = Pu.username,
                        UpdatedAt = Pp.updated_at,
                        UpdatedBy = Pu.username,
                        //以下為pdm_role_permissions資料
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
                    });
        }

        // 查詢作業、作業權限權限Details
        public static IQueryable<pdm_role_permission_detailsDto> QueryPermissionDetails(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from Pp in _pcms_Pdm_TestContext.pdm_permissions
                    join Prpd in _pcms_Pdm_TestContext.pdm_role_permission_details on Pp.permission_id equals Prpd.permission_id
                    join Pur in _pcms_Pdm_TestContext.pdm_user_roles on Prpd.role_id equals Pur.role_id
                    join Pu in _pcms_Pdm_TestContext.pdm_users on Pur.user_id equals Pu.user_id
                    select new pdm_role_permission_detailsDto
                    {
                        PermissionId = Pp.permission_id,

                        //以下為pdm_role_permissions資料
                        //RolePermissionDetailId = Prpd.role_permission_detail_id,
                        RoleId = Prpd.role_id,
                        DevFactoryNoD = Prpd.dev_factory_no,
                        PermissionKey = Prpd.permission_key,
                        DescriptionD = Prpd.description,
                        IsActiveD = Prpd.is_active,
                    });
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
        /// <summary>
        /// New Initial，一次查詢所有資料後回傳
        /// </summary>
        /// <param name="_pcms_Pdm_TestContext"></param>
        /// <returns>廠別下拉、權限表、特殊權限表</returns>
        public static async Task<Dictionary<string, object>> QueryInitial(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            // 廠別下拉
            var factoryQuery = from Pf in _pcms_Pdm_TestContext.pdm_factory
                               select new pdm_DropDownDto
                               {
                                   Id = Pf.factory_id,
                                   Value = Pf.dev_factory_no,
                                   Text = Pf.dev_factory_no
                               };
            // 查詢權限清單
            var permissionsRaw = await (
                from Pp in _pcms_Pdm_TestContext.pdm_permissions
                join Prp in _pcms_Pdm_TestContext.pdm_role_permissions on Pp.permission_id equals Prp.permission_id
                select new pdm_permissionsInitDto
                {
                    PermissionId = Pp.permission_id,
                    PermissionName = Pp.permission_name,
                    Description = Pp.description,
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
                }).ToListAsync(); // **先把資料載入記憶體**

            var permissions = permissionsRaw
                .GroupBy(p => new { p.PermissionId, p.PermissionName, p.Description })
                .Select(g => new pdm_permissionsInitDto
                {
                    PermissionId = g.Key.PermissionId,
                    PermissionName = g.Key.PermissionName,
                    Description = g.Key.Description,
                    IsActive = g.Any(p => p.IsActive == "Y") ? "Y" : "N",
                    Createp = g.Any(p => p.Createp == "Y") ? "Y" : "N",
                    Readp = g.Any(p => p.Readp == "Y") ? "Y" : "N",
                    Updatep = g.Any(p => p.Updatep == "Y") ? "Y" : "N",
                    Deletep = g.Any(p => p.Deletep == "Y") ? "Y" : "N",
                    Exportp = g.Any(p => p.Exportp == "Y") ? "Y" : "N",
                    Importp = g.Any(p => p.Importp == "Y") ? "Y" : "N",
                    Permission1 = g.Any(p => p.Permission1 == "Y") ? "Y" : "N",
                    Permission2 = g.Any(p => p.Permission2 == "Y") ? "Y" : "N",
                    Permission3 = g.Any(p => p.Permission3 == "Y") ? "Y" : "N",
                    Permission4 = g.Any(p => p.Permission4 == "Y") ? "Y" : "N"
                }).ToList();


            // 查詢權限清單details
            var detailsRaw = await (
                from Prpd in _pcms_Pdm_TestContext.pdm_role_permission_details
                join Pp in _pcms_Pdm_TestContext.pdm_permissions on Prpd.permission_id equals Pp.permission_id
                select new pdm_role_permission_detailsInitDto
                {
                    PermissionId = Prpd.permission_id,
                    PermissionName = Pp.permission_name,
                    Description = Pp.description,
                    PermissionKey = Prpd.permission_key,
                    DescriptionD = Prpd.description,
                    IsActiveD = Prpd.is_active
                }).ToListAsync(); // **先查詢再處理**

            var permissionDetails = detailsRaw
                .GroupBy(d => new { d.PermissionId, d.PermissionKey })
                .Select(g => new pdm_role_permission_detailsInitDto
                {
                    PermissionId = g.Key.PermissionId,
                    PermissionName = g.First().PermissionName,
                    Description = g.First().Description,
                    PermissionKey = g.Key.PermissionKey,
                    DescriptionD = g.First().DescriptionD,
                    IsActiveD = g.Any(x => x.IsActiveD == "Y") ? "Y" : "N"
                }).OrderBy(g => g.PermissionId).ToList();

            // 將查詢結果包裝成 Dictionary
            return new Dictionary<string, object>
            {
                { "Factory", factoryQuery },
                { "Permissions", permissions },
                { "PermissionDetails", permissionDetails }
            };
        }

        // 查詢角色、作業、作業權限權限
        public static async Task<Dictionary<string, object>> QueryPermissionsWithDetailsAsync(pcms_pdm_testContext _pcms_Pdm_TestContext, PermissionsParameter parameters)
        {
            // 查詢 permissions
            var permissionsQuery = from Pp in _pcms_Pdm_TestContext.pdm_permissions
                                   join Prp in _pcms_Pdm_TestContext.pdm_role_permissions on Pp.permission_id equals Prp.permission_id
                                   join pur in _pcms_Pdm_TestContext.pdm_user_roles on Prp.role_id equals pur.role_id into purJoin
                                   from pur in purJoin.DefaultIfEmpty() // 將 pdm_user_roles 改為 left join
                                   join pu in _pcms_Pdm_TestContext.pdm_users on pur.user_id equals pu.user_id into puJoin
                                   from pu in puJoin.DefaultIfEmpty()   // pdm_users left join
                                   select new pdm_permissionsDto
                                   {
                                       PermissionId = Pp.permission_id,
                                       PermissionName = Pp.permission_name,
                                       Description = Pp.description,
                                       CreatedAt = Pp.created_at,
                                       CreatedBy = pu != null ? pu.username : string.Empty,
                                       UpdatedAt = Pp.updated_at,
                                       UpdatedBy = pu != null ? pu.username : string.Empty,
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
            if (!string.IsNullOrWhiteSpace(parameters.RoleId))
            {
                int roleId = int.Parse(parameters.RoleId);
                permissionsQuery = permissionsQuery.Where(p => p.RoleId == roleId);
            }
            if (!string.IsNullOrWhiteSpace(parameters.PermissionId))
            {
                int permissionId = int.Parse(parameters.PermissionId);
                permissionsQuery = permissionsQuery.Where(p => p.PermissionId == permissionId);
            }
            if (!string.IsNullOrWhiteSpace(parameters.PermissionName))
            {
                permissionsQuery = permissionsQuery.Where(p => p.PermissionName.Contains(parameters.PermissionName));
            }
            if (!string.IsNullOrWhiteSpace(parameters.DevFactoryNo))
            {
                permissionsQuery = permissionsQuery.Where(p => p.DevFactoryNo == parameters.DevFactoryNo);
            }

            var permissions = await permissionsQuery.OrderBy(q => q.PermissionId).ToListAsync();

            // 查詢 details
            var detailsQuery = from Prpd in _pcms_Pdm_TestContext.pdm_role_permission_details
                               join Pp in _pcms_Pdm_TestContext.pdm_permissions on Prpd.permission_id equals Pp.permission_id
                               select new pdm_role_permission_detailsDto
                               {
                                   //RolePermissionDetailId = Prpd.role_permission_detail_id,
                                   RoleId = Prpd.role_id,
                                   PermissionId = Prpd.permission_id,
                                   DevFactoryNoD = Prpd.dev_factory_no,
                                   PermissionKey = Prpd.permission_key,
                                   DescriptionD = Prpd.description,
                                   IsActiveD = Prpd.is_active
                               };
            if (!string.IsNullOrWhiteSpace(parameters.RoleId))
            {
                int roleId = int.Parse(parameters.RoleId);
                detailsQuery = detailsQuery.Where(d => d.RoleId == roleId);
            }
            if (!string.IsNullOrWhiteSpace(parameters.PermissionId))
            {
                int permissionId = int.Parse(parameters.PermissionId);
                detailsQuery = detailsQuery.Where(d => d.PermissionId == permissionId);
            }
            if (!string.IsNullOrWhiteSpace(parameters.DevFactoryNo))
            {
                detailsQuery = detailsQuery.Where(d => d.DevFactoryNoD == parameters.DevFactoryNo);
            }

            var permissionDetails = await detailsQuery.OrderBy(q => q.PermissionId).ToListAsync();

            // 將查詢結果包裝成 Dictionary
            return new Dictionary<string, object>
            {
                { "Permissions", permissions },
                { "PermissionDetails", permissionDetails }
            };
        }
    }
}
