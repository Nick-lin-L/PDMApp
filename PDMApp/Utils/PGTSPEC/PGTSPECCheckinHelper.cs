using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Utils.PGTSPEC
{
    public class PGTSPECCheckinHelper
    {
        public static async Task<(bool IsSuccess, string Message)> CheckinSpecAsync(pcms_pdm_testContext _pcms_Pdm_TestContext, CheckinSpecParameter value)
        {
            // 取得當前登入使用者
            var userId = "allen1.cheng"; // TODO: 從身份驗證系統取得
            var userName = "鄭名硯";  // TODO: 從身份驗證系統取得

            if (string.IsNullOrEmpty(userId))
            {
                return (false, "無法取得使用者資訊。");
            }

            // 查詢 SPEC 資料
            var spec = await _pcms_Pdm_TestContext.pcg_spec_head
                .Where(n => n.spec_m_id == value.SpecMId)
                .FirstOrDefaultAsync();

            if (spec == null)
            {
                return (false, "SPEC 不存在。");
            }

            // 檢查 CHECKOUT 狀態
            if (spec.checkoutmk == "N")
            {
                return (false, "尚未 CHECK OUT。");
            }

            if (spec.checkoutmk == "Y" && spec.checkoutuser != userId)
            {
                return (false, "你非 CHECK OUT 人員，無權執行 CHECK IN。");
            }

            // 執行 CHECK IN，清除 CHECKOUT 狀態
            spec.checkoutmk = "N";
            spec.checkoutuser = "";
            spec.update_date = DateTime.Now;
            spec.update_user_id = "20211200037074";
            spec.update_user_nm = userName;

            await _pcms_Pdm_TestContext.SaveChangesAsync();
            return (true, "CHECK IN 成功。");
        }
    }
}
