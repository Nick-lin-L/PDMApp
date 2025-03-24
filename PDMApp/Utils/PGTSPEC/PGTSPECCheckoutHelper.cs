using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Utils.PGTSPEC
{
    public class PGTSPECCheckoutHelper
    {
        public static async Task<(bool IsSuccess, string Message)> CheckoutSpecAsync(pcms_pdm_testContext _pcms_Pdm_TestContext, CheckoutSpecParameter value, string pccuid, string name, string name_en)
        {

            if (string.IsNullOrEmpty(name_en))
            {
                return (false, "無法取得使用者資訊。");
            }

            var spec = await _pcms_Pdm_TestContext.pcg_spec_head
                .Where(n => n.spec_m_id == value.SpecMId)
                .FirstOrDefaultAsync();

            if (spec == null)
            {
                return (false, "SPEC 不存在。");
            }

            if (spec.speclockmk == "Y")
            {
                return (false, "此份檔案已經 LOCK，請通知主管解 LOCK。");
            }

            if (spec.checkoutmk == "Y" && spec.checkoutuser != name_en)
            {
                return (false, "已有人在編輯此份 SPEC。");
            }

            try
            {
                if (spec.ver == null || spec.ver == 0)
                {
                    spec.ver = 1;
                    spec.checkoutmk = "Y";
                    spec.checkoutuser = name_en;
                    spec.update_date = DateTime.Now;
                    spec.update_user_id = pccuid; // TODO: 未來改為 pccuId
                    spec.update_user_nm = name;

                    await _pcms_Pdm_TestContext.SaveChangesAsync();
                    return (true, "CHECKOUT 成功。");
                }

                var maxVer = await _pcms_Pdm_TestContext.pcg_spec_head
                    .Where(sh => sh.product_d_id == spec.product_d_id)
                    .MaxAsync(sh => (int?)sh.ver) ?? 0;

                var newVer = maxVer + 1;

                spec.speclockmk = "Y";
                await _pcms_Pdm_TestContext.SaveChangesAsync(); // ✅ 確保舊版本 LOCK 先寫入

                var newSpecMId = Guid.NewGuid().ToString();

                var newSpec = new pcg_spec_head
                {
                    spec_m_id = newSpecMId,
                    product_d_id = spec.product_d_id,
                    ver = newVer,
                    stage_code = spec.stage_code,
                    checkoutmk = "Y",
                    checkoutuser = name_en,
                    speclockmk = null,
                    create_mode = spec.create_mode,
                    ref_dev_no = spec.ref_dev_no,
                    remarks_prohibit = spec.remarks_prohibit,
                    create_date = spec.create_date,
                    create_user_id = spec.create_user_id,
                    create_user_nm = spec.create_user_nm,
                    update_date = DateTime.Now,
                    update_user_id = pccuid, // TODO: 未來改為 pccuId
                    update_user_nm = name
                };

                await _pcms_Pdm_TestContext.pcg_spec_head.AddAsync(newSpec);

                var specItems = await _pcms_Pdm_TestContext.pcg_spec_item
                    .Where(si => si.spec_m_id == spec.spec_m_id)
                    .ToListAsync();

                var newSpecItems = specItems.Select(si => new pcg_spec_item
                {
                    spec_d_id = Guid.NewGuid().ToString(),
                    spec_m_id = newSpecMId,
                    material_sort = si.material_sort,
                    material_group = si.material_group,
                    parts_no = si.parts_no,
                    material_new = si.material_new,
                    parts = si.parts,
                    detail = si.detail,
                    process_mk = si.process_mk,
                    material = si.material,
                    mat_comment = si.mat_comment,
                    standard = si.standard,
                    agent = si.agent,
                    supplier = si.supplier,
                    quote_supplier = si.quote_supplier,
                    hcha = si.hcha,
                    sec = si.sec,
                    material_color = si.material_color,
                    clr_comment = si.clr_comment,
                    add_date = si.add_date,
                    update_date = si.update_date,
                    mtrtype = si.mtrtype,
                    mtrbase = si.mtrbase,
                    processing = si.processing,
                    effect = si.effect,
                    releasepaper = si.releasepaper,
                    basecolor = si.basecolor,
                    act_part_no = si.act_part_no,
                    part_mk = si.part_mk,
                    recycle = si.recycle
                }).ToList();

                await _pcms_Pdm_TestContext.pcg_spec_item.AddRangeAsync(newSpecItems);
                await _pcms_Pdm_TestContext.SaveChangesAsync();

                return (true, "CHECKOUT 成功。");
            }
            catch (Exception ex)
            {
                return (false, $"CHECKOUT 失敗: {ex.Message}");
            }
        }
    }
}
