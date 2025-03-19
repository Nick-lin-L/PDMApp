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

        public async Task<pdm_users> GetByPccuid(decimal pccuid)
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
    }
}
