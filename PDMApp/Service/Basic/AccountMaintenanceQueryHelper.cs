using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Service.Basic
{
 public class AccountMaintenanceQueryHelper
{
    public static IQueryable<DevFactoryNoDto> QueryDevFactoryNo(pcms_pdm_testContext _pcms_Pdm_TestContext)
    {

        var factoryQuery = from Pf in _pcms_Pdm_TestContext.pdm_factory
                           select new 
                           {
                               DevFactoryNo = Pf.dev_factory_no,
                           };

        // 轉換成 ComboDto
        return factoryQuery.Select(n => new DevFactoryNoDto
        {
            Text = n.DevFactoryNo,
            Value = n.DevFactoryNo
        });

    }

    public static async Task<IDictionary<string, List<RoleDto>>> QueryRoles(pcms_pdm_testContext _pcms_Pdm_TestContext)
    {
        var roleQuery = await (from r in _pcms_Pdm_TestContext.pdm_roles
                               where r.is_active == "Y"
                               select new
                               {
                                   RoleId = r.role_id,          
                                   RoleName = r.role_name,
                                   DevFactoryNo = r.dev_factory_no 
                               }).ToListAsync();

        // **依據 DevFactoryNo 分組**
        var groupedData = roleQuery
            .GroupBy(r => r.DevFactoryNo)
            .ToDictionary(
                g => g.Key,
                g => g.Select(r => new RoleDto
        {
                    Value = r.RoleId,
                    Text = r.RoleName,
                }).ToList()
            );

        return groupedData;
    }


    public static IQueryable<pdm_usersDto> QueryFilteredAccounts(pcms_pdm_testContext _pcms_Pdm_TestContext, AccountSearchParameter value)
    {
        var query = from u in _pcms_Pdm_TestContext.pdm_users
                        // 進行 LEFT JOIN (Group Join)
                    join createdUser in _pcms_Pdm_TestContext.pdm_users
                        on u.created_by equals createdUser.user_id into createdUserGroup
                    from createdUser in createdUserGroup.DefaultIfEmpty() // 允許 NULL

                    join updatedUser in _pcms_Pdm_TestContext.pdm_users
                        on u.updated_by equals updatedUser.user_id into updatedUserGroup
                    from updatedUser in updatedUserGroup.DefaultIfEmpty() // 允許 NULL

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
                        CreatedBy = createdUser != null ? createdUser.username : "", // 改為 username
                        CreatedAt = u.created_at,
                        UpdatedBy = updatedUser != null ? updatedUser.username : "", // 改為 username
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
                        join cu in _pcms_Pdm_TestContext.pdm_users on ur.created_by equals cu.user_id into createdByUser
                        from cu in createdByUser.DefaultIfEmpty() // 左外部連接，避免 null crash
                        where u.user_id == value.UserId
                        select new AccountDetailDto
                        {
                            UserId = u.user_id,
                            PccUid = (decimal)u.pccuid,
                            UserName = u.username,
                            RoleId = r.role_id,
                            RoleName = r.role_name,
                            DevFactoryNo = r.dev_factory_no,
                            CreatedBy = cu != null ? cu.username : null, // 從 ur.created_by 對應 cu.username
                            CreatedAt = ur.created_at
                        };

            return query;
        }
    }
}
