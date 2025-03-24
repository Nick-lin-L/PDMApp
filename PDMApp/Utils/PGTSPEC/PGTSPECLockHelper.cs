using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Utils.PGTSPEC
{
    public class PGTSPECLockHelper
    {
        public static async Task<(bool isSuccess, string message)> LockSpecAsync(pcms_pdm_testContext _pcms_Pdm_TestContext, SpecLockParameter value, bool isLock, string pccuid, string name)
        {
            var spec = await _pcms_Pdm_TestContext.pcg_spec_head.FirstOrDefaultAsync(s => s.spec_m_id == value.SpecMId);

            if (spec == null)
                return (false, "規格資料不存在"); 

            if (spec.speclockmk == (isLock ? "Y" : "N"))
                return (false, isLock ? "規格已鎖定" : "規格已解鎖");

            spec.speclockmk = isLock ? "Y" : "N";
            spec.update_date = DateTime.Now;
            spec.update_user_id = pccuid; // TODO: 未來改為 pccuId
            spec.update_user_nm = name; // TODO: 未來改為 userName

            await _pcms_Pdm_TestContext.SaveChangesAsync();

            return (true, isLock ? "規格已鎖定成功" : "規格已解鎖成功");
        }

    }
}
