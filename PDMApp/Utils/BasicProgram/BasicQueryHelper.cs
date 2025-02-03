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
                    select new pdm_rolesDto
                    {
                        RoleId = rolesTable.role_id,
                        RoleName = rolesTable.role_name,
                        Description = rolesTable.description,
                        DevFactoryNo = rolesTable.dev_factory_no,
                        CreatedAt = rolesTable.created_at,
                        CreatedBy = rolesTable.created_by,
                        UpdatedAt = rolesTable.updated_at,
                        UpdatedBy = rolesTable.updated_by,
                        IsActive = rolesTable.is_active
                    });
        }

        public static IQueryable<pdm_permissionsDto> QueryPermissions(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from Pp in _pcms_Pdm_TestContext.pdm_permissions
                    select new pdm_permissionsDto
                    {
                        PermissionId = Pp.permission_id,
                        PermissionName = Pp.permission_name,
                        Description = Pp.description,
                        CreatedAt = Pp.created_at,
                        CreatedBy = Pp.created_by,
                        UpdatedAt = Pp.updated_at,
                        UpdatedBy = Pp.updated_by
                    });
        }
    }
}
