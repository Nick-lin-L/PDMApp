using Dtos.PGTSPEC;
using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Service.PGTSPEC
{
    public class PGTSPECCheckoutHelper
    {
        public static async Task<(bool IsSuccess, string Message, PGTSPECHeaderDto SpecHeaderDto)> CheckoutSpecAsync(pcms_pdm_testContext _pcms_Pdm_TestContext, CheckoutSpecParameter value, string pccuid, string name, string name_en)
        {
            if (string.IsNullOrEmpty(name_en))
            {
                return (false, "無法取得使用者資訊。", null);
            }

            var spec = await _pcms_Pdm_TestContext.pcg_spec_head
                .Where(n => n.spec_m_id == value.SpecMId)
                .FirstOrDefaultAsync();

            if (spec == null)
            {
                return (false, "SPEC 不存在。", null);
            }

            if (spec.speclockmk == "Y")
            {
                return (false, "此份檔案已經 LOCK，請通知主管解 LOCK。", null);
            }

            if (spec.checkoutmk == "Y" && spec.checkoutuser != name_en)
            {
                return (false, "已有人在編輯此份 SPEC。", null);
            }

            try
            {
                pcg_spec_head finalSpec = null; // 用來儲存最終要回傳的 spec_head 物件

                if (spec.ver == null || spec.ver == 0)
                {
                    spec.ver = 1;
                    spec.checkoutmk = "Y";
                    spec.checkoutuser = name_en;
                    spec.update_date = DateTime.Now;
                    spec.update_user_id = pccuid;
                    spec.update_user_nm = name;

                    await _pcms_Pdm_TestContext.SaveChangesAsync();
                    finalSpec = spec; // 儲存更新後的 spec
                }
                else
                {
                    var maxVer = await _pcms_Pdm_TestContext.pcg_spec_head
                        .Where(sh => sh.product_d_id == spec.product_d_id)
                        .MaxAsync(sh => (int?)sh.ver) ?? 0;

                    var newVer = maxVer + 1;

                    spec.speclockmk = "Y";
                    await _pcms_Pdm_TestContext.SaveChangesAsync(); // 確保舊版本 LOCK 先寫入

                    var newSpecMId = Guid.NewGuid().ToString();

                    var newSpec = new pcg_spec_head
                    {
                        spec_m_id = newSpecMId,
                        product_d_id = spec.product_d_id,
                        ver = newVer,
                        stage_code = spec.stage_code,
                        checkoutmk = "Y",
                        checkoutuser = name_en,
                        speclockmk = null, // 新版本預設不鎖定
                        create_mode = spec.create_mode,
                        ref_dev_no = spec.ref_dev_no,
                        remarks_prohibit = spec.remarks_prohibit,
                        create_date = DateTime.Now, // 新版本創建日期為現在
                        create_user_id = pccuid,
                        create_user_nm = name,
                        update_date = DateTime.Now,
                        update_user_id = pccuid,
                        update_user_nm = name
                    };

                    await _pcms_Pdm_TestContext.pcg_spec_head.AddAsync(newSpec);

                    var specItems = await _pcms_Pdm_TestContext.pcg_spec_item
                        .Where(si => si.spec_m_id == spec.spec_m_id)
                        .AsNoTracking() // 這裡可以使用 AsNoTracking，因為只是複製資料
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
                        add_date = DateTime.Now,
                        update_date = DateTime.Now, // 更新為現在
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
                    finalSpec = newSpec; // 儲存新增的 spec
                }

                // 將 finalSpec 轉換為 PGTSPECHeaderDto
                var queryResult = from ph in _pcms_Pdm_TestContext.plm_product_head
                                  join pi in _pcms_Pdm_TestContext.plm_product_item on ph.product_m_id equals pi.product_m_id
                                  join sh in _pcms_Pdm_TestContext.pcg_spec_head on pi.product_d_id equals sh.product_d_id
                                  join n_stage in _pcms_Pdm_TestContext.pdm_namevalue_new on sh.stage_code equals n_stage.value_desc
                                  where n_stage.group_key == "stage" && sh.spec_m_id == finalSpec.spec_m_id // 篩選出目標 SpecMId
                                  join n_brand in _pcms_Pdm_TestContext.pdm_namevalue_new on ph.brand_no equals n_brand.value_desc
                                  where n_brand.group_key == "brand"
                                  select new PGTSPECHeaderDto
                                  {
                                      SpecMId = sh.spec_m_id,
                                      Brand = n_brand.text,
                                      DevelopmentNo = ph.development_no,
                                      DevelopmentColorNo = pi.development_color_no,
                                      ColorCode = pi.color_code,
                                      Colorway = pi.colorway,
                                      Stage = n_stage.text,
                                      ModelName = ph.working_name,
                                      Ver = sh.ver,
                                      CheckoutMk = sh.checkoutmk,
                                      CheckoutUser = sh.checkoutuser,
                                      SpecLockMk = sh.speclockmk,
                                      UpdateDate = sh.update_date,
                                      UpdateUser = sh.update_user_nm,
                                      EditMk = (sh.checkoutuser == name_en && sh.checkoutmk == "Y") ? "Y" : "N"
                                  };

                var finalDto = await queryResult.FirstOrDefaultAsync();

                return (true, "CHECKOUT 成功。", finalDto);
            }
            catch (Exception ex)
            {
                return (false, $"CHECKOUT 失敗: {ex.Message}", null);
            }
        }
    }
}
