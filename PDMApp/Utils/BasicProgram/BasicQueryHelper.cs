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
            return (from rolesTable in _pcms_Pdm_TestContext.pdm_roles
                    join pur in _pcms_Pdm_TestContext.pdm_user_roles on rolesTable.role_id equals pur.role_id
                    join pu in _pcms_Pdm_TestContext.pdm_users on pur.user_id equals pu.user_id
                    select new pdm_rolesDto
                    {
                        RoleId = rolesTable.role_id,
                        RoleName = rolesTable.role_name,
                        Description = rolesTable.description,
                        DevFactoryNo = rolesTable.dev_factory_no,
                        CreatedAt = rolesTable.created_at,
                        CreatedBy = pu.username,
                        UpdatedAt = rolesTable.updated_at,
                        UpdatedBy = pu.username,
                        IsActive = rolesTable.is_active
                    });

        }

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
                        UpdatedBy = Pu.username
                    });
        }
    }
}
