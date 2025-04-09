using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PDMApp.Utils.BasicProgram
{
    public static class BasicQueryHelper
    {

        public static IQueryable<pdm_rolesDto> QueryRoles(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from pr in _pcms_Pdm_TestContext.pdm_roles
                    join pu in _pcms_Pdm_TestContext.pdm_users on pr.updated_by equals pu.user_id into puJoin
                    from pu in puJoin.DefaultIfEmpty()   // pdm_users left join
                    select new pdm_rolesDto
                    {
                        RoleId = pr.role_id,
                        RoleName = pr.role_name,
                        Description = pr.description,
                        DevFactoryNo = pr.dev_factory_no,
                        //CreatedAt = pr.created_at,
                        //CreatedBy = pu.username ?? string.Empty,
                        UpdatedAt = pr.updated_at,
                        UpdatedBy = pu.username ?? string.Empty,
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
                        RoleId = (int)Prpd.role_id,
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
            var permissionsQuery = from Pp in _pcms_Pdm_TestContext.pdm_permissions
                                   select new pdm_permissionsInitDto
                                   {
                                       PermissionId = Pp.permission_id,
                                       PermissionName = Pp.permission_name,
                                       Description = Pp.description,
                                       FrontEndId = Pp.frontend_id,
                                       IsActive = Pp.is_active ?? "Y",
                                       // 預設權限設定為 "Y"
                                       Createp = "Y",
                                       Readp = "Y",
                                       Updatep = "Y",
                                       Deletep = "Y",
                                       Exportp = "Y",
                                       Importp = "Y",
                                       Permission1 = "Y",
                                       Permission2 = "Y",
                                       Permission3 = "Y",
                                       Permission4 = "Y"
                                   };

            var permissions = await permissionsQuery
                .OrderBy(p => p.PermissionId)
                .ToListAsync();

            // 查詢權限清單details
            var detailsQuery = from Pp in _pcms_Pdm_TestContext.pdm_permissions
                               join Ppk in _pcms_Pdm_TestContext.pdm_permission_keys
                                   on Pp.permission_id equals Ppk.permission_id
                               select new pdm_role_permission_detailsInitDto
                               {
                                   PermissionId = Pp.permission_id,
                                   PermissionName = Pp.permission_name,
                                   Description = Pp.description,
                                   PermissionKey = Ppk.permission_key,
                                   PermissionKeyId = Ppk.permission_key_id,
                                   DescriptionD = Ppk.description,
                                   IsActiveD = "Y"  // 預設為未啟用
                               };

            var permissionDetails = await detailsQuery
                .OrderBy(d => d.PermissionId)
                .ToListAsync();

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
            //查詢 roles
            var rolesQuery = QueryRoles(_pcms_Pdm_TestContext);
            //if (!string.IsNullOrWhiteSpace(parameters.RoleId) && int.TryParse(parameters.RoleId, out int roleIdFilter)) string轉int判斷
            if (parameters.RoleId.HasValue)
            {
                //rolesQuery = rolesQuery.Where(r => r.RoleId == roleIdFilter);
                rolesQuery = rolesQuery.Where(r => r.RoleId == parameters.RoleId.Value);
            }
            var roles = await rolesQuery.ToListAsync();

            // 查詢 permissions
            var permissionsQuery = from Pp in _pcms_Pdm_TestContext.pdm_permissions
                                       // left join 連接 role_permissions，只查詢指定角色的權限設定
                                   join Prp in _pcms_Pdm_TestContext.pdm_role_permissions
                                       on new { pid = Pp.permission_id, rid = parameters.RoleId.Value }
                                       equals new { pid = (int)Prp.permission_id, rid = (int)Prp.role_id }
                                       into rolePerms
                                   from Prp in rolePerms.DefaultIfEmpty()
                                       // left join 連接 roles 取得角色資訊
                                   join pr in _pcms_Pdm_TestContext.pdm_roles
                                       on parameters.RoleId equals pr.role_id
                                       into roleInfo
                                   from pr in roleInfo.DefaultIfEmpty()
                                   select new pdm_permissionsDto
                                   {
                                       // 基本權限資訊
                                       PermissionId = Pp.permission_id,
                                       PermissionName = Pp.permission_name,
                                       Description = Pp.description,
                                       FrontEndId = Pp.frontend_id,
                                       //IsActive = Pp.is_active ?? "N",

                                       // 角色權限設定，如果沒有設定則使用預設值
                                       RolePermissionId = Prp != null ? Prp.role_permission_id : 0,
                                       RoleId = parameters.RoleId,
                                       DevFactoryNo = Prp.dev_factory_no ?? pr.dev_factory_no ?? parameters.DevFactoryNo,
                                       IsActive = Prp.is_active ?? "Y", // 因為前端沒有接收，但抓取tree menu會判斷此值。故給Y
                                       Createp = Prp.createp ?? "N",
                                       Readp = Prp.readp ?? "N",
                                       Updatep = Prp.updatep ?? "N",
                                       Deletep = Prp.deletep ?? "N",
                                       Exportp = Prp.exportp ?? "N",
                                       Importp = Prp.importp ?? "N",
                                       Permission1 = Prp.permission1 ?? "N",
                                       Permission2 = Prp.permission2 ?? "N",
                                       Permission3 = Prp.permission3 ?? "N",
                                       Permission4 = Prp.permission4 ?? "N",

                                       // 時間和建立/更新者資訊
                                       CreatedAt = Prp.created_at ?? Pp.created_at,
                                       UpdatedAt = Prp.updated_at ?? Pp.updated_at,
                                       CreatedBy = string.Empty, // 如果需要使用者名稱，可以再加入相關的 join
                                       UpdatedBy = string.Empty
                                   };

            // 加入篩選條件
            if (parameters.PermissionId.HasValue)
            {
                permissionsQuery = permissionsQuery.Where(p => p.PermissionId == parameters.PermissionId.Value);
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
            var detailsQuery = from Pp in _pcms_Pdm_TestContext.pdm_permissions
                                   // 先取得該作業的所有可用特殊權限
                               join Pk in _pcms_Pdm_TestContext.pdm_permission_keys
                                   on Pp.permission_id equals Pk.permission_id
                               // left join 該角色的權限設定
                               join Prpd in _pcms_Pdm_TestContext.pdm_role_permission_details
                                   on new { keyId = Pk.permission_key_id, rid = parameters.RoleId.Value }
                                   equals new { keyId = (int)Prpd.permission_key_id, rid = (int)Prpd.role_id }
                                   into rolePermDetails
                               from Prpd in rolePermDetails.DefaultIfEmpty()
                               select new pdm_role_permission_detailsDto
                               {
                                   RoleId = parameters.RoleId.Value,
                                   PermissionId = Pp.permission_id,
                                   PermissionKeyId = Pk.permission_key_id,
                                   PermissionKey = Pk.permission_key,
                                   Description = Pp.description,
                                   DescriptionD = Pk.description,
                                   DevFactoryNoD = Prpd.dev_factory_no ?? parameters.DevFactoryNo,
                                   IsActiveD = Prpd.is_active ?? "N"
                               };
            /*
                                              RoleId = (int)Prpd.role_id,
                                              PermissionId = (int)Prpd.permission_id,
                                              Description = Pp.description,
                                              DevFactoryNoD = Prpd.dev_factory_no,
                                              PermissionKey = Prpd.permission_key,
                                              DescriptionD = Prpd.description,
                                              IsActiveD = Prpd.is_active

                                              RoleId = parameters.RoleId.Value,
                                              PermissionId = Pp.permission_id,
                                              Description = Pp.description,
                                              // 如果該角色有設定，則使用設定值，否則使用預設值
                                              DevFactoryNoD = Prpd.dev_factory_no ?? pr.dev_factory_no ?? parameters.DevFactoryNo,
                                              PermissionKey = Prpd.permission_key ?? string.Empty,
                                              DescriptionD = Prpd.description ?? Pp.description,
                                              IsActiveD = Prpd.is_active ?? "N"*/
            // 加入篩選條件
            if (parameters.PermissionId.HasValue)
            {
                detailsQuery = detailsQuery.Where(d => d.PermissionId == parameters.PermissionId.Value);
            }
            if (!string.IsNullOrWhiteSpace(parameters.DevFactoryNo))
            {
                detailsQuery = detailsQuery.Where(d => d.DevFactoryNoD == parameters.DevFactoryNo);
            }

            var permissionDetails = await detailsQuery.OrderBy(q => q.PermissionKeyId).ToListAsync();

            // 將查詢結果包裝成 Dictionary
            return new Dictionary<string, object>
            {
                { "Roles", roles.FirstOrDefault() }, //object  { "Roles", roles }, //這段是array
                { "Permissions", permissions },
                { "PermissionDetails", permissionDetails }
            };

        }
    }
}
