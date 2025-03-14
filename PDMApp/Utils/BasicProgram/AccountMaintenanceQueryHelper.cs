using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AccountMaintenanceQueryHelper
{

    public static async Task<IDictionary<string, object>> QueryRoleDropdown(pcms_pdm_testContext _pcms_Pdm_TestContext)
    {
        var roleQuery = await (from r in _pcms_Pdm_TestContext.pdm_roles
                               where r.is_active == "Y" // 過濾 is_active 為 "Y"
                               select new
                               {
                                   RoleId = r.role_id,          
                                   RoleName = r.role_name,
                                   DevFactoryNo = r.dev_factory_no 
                               }).ToListAsync();

        return new Dictionary<string, object>
        {
            { "Roles", roleQuery }
        };
    }


    public static IQueryable<pdm_usersDto> QueryFilteredAccounts(pcms_pdm_testContext _pcms_Pdm_TestContext, AccountSearchParameter value)
    {
        var query = from u in _pcms_Pdm_TestContext.pdm_users
                    select new pdm_usersDto
                    {
                        UserId = u.user_id,  
                        PccUid = (decimal)u.pccuid,
                        UserName = u.username,
                        LocalName = u.local_name,
                        SsoAcct = u.sso_acct,
                        Email = u.email,
                        IsSso = u.is_sso,
                        IsActive = u.is_active,
                        LastLogin = u.last_login,
                        CreatedBy = u.created_by,
                        CreatedAt = u.created_at,
                        UpdatedBy = u.updated_by,
                        UpdatedAt = u.updated_at
                    };

        // 根據 local_name 過濾 (模糊搜尋)
        if (!string.IsNullOrWhiteSpace(value.LocalName))
        {
            query = query.Where(u => u.LocalName.Contains(value.LocalName));
        }

        // 排序 (根據 local_name)
        query = query.OrderBy(u => u.LocalName);

        return query;
    }

    public static IQueryable<AccountDetailDto> QueryAccountDetails(pcms_pdm_testContext _pcms_Pdm_TestContext, AccountDetailSearchParameter value)
    {
        var query = from u in _pcms_Pdm_TestContext.pdm_users
                    join ur in _pcms_Pdm_TestContext.pdm_user_roles on u.user_id equals ur.user_id
                    join r in _pcms_Pdm_TestContext.pdm_roles on ur.role_id equals r.role_id
                    where u.user_id == value.UserId
                    select new AccountDetailDto
                    {
                        UserId = u.user_id,
                        PccUid = (decimal)u.pccuid,
                        UserName = u.username,
                        RoleId = r.role_id,    
                        RoleName = r.role_name,
                        DevFactoryNo = r.dev_factory_no
                    };      

        return query;
    }


}
