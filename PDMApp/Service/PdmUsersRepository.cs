using Microsoft.EntityFrameworkCore;
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

            // 或者使用 Dapper 的方式（如果你使用的是 Dapper）
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
    }
}
