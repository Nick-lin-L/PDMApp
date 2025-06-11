using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Service.PGTSPEC
{
    public class PGTSPECCopyToHelper
    {
        public static async Task<(bool IsSuccess, string Message)> CopyToSpecAsync(pcms_pdm_testContext _pcms_Pdm_TestContext, CopyToSpecParameter value, string pccuid, string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value.DevelopmentNo) ||
                    string.IsNullOrWhiteSpace(value.DevelopmentColorNo) ||
                    string.IsNullOrWhiteSpace(value.Stage) ||
                    string.IsNullOrWhiteSpace(value.DevFactoryNo) ||
                    string.IsNullOrWhiteSpace(value.SpecMId))
                {
                    return (false, "Missing required parameters.");
                }

                // 取得 stage_code
                var stageCode = await (from n in _pcms_Pdm_TestContext.pdm_namevalue_new
                                       where n.group_key == "stage" && n.text == value.Stage
                                       select n.value_desc).FirstOrDefaultAsync();

                if (string.IsNullOrEmpty(stageCode))
                {
                    return (false, "Invalid Stage provided.");
                }

                // 取得 PRODUCT_D_ID
                var productDId = await (from ph in _pcms_Pdm_TestContext.plm_product_head
                                        join pi in _pcms_Pdm_TestContext.plm_product_item
                                            on ph.product_m_id equals pi.product_m_id
                                        where ph.development_no == value.DevelopmentNo
                                              && pi.development_color_no == value.DevelopmentColorNo
                                        select pi.product_d_id).FirstOrDefaultAsync();

                if (string.IsNullOrEmpty(productDId))
                {
                    return (false, "No matching product_d_id found.");
                }

                // 取得符合條件的 SPEC_M_ID (僅依據 SpecMId 查詢)
                var specMId = await (from sh in _pcms_Pdm_TestContext.pcg_spec_head
                                     where sh.spec_m_id == value.SpecMId
                                     select sh.spec_m_id).FirstOrDefaultAsync();

                if (string.IsNullOrEmpty(specMId))
                {
                    return (false, "No matching spec_m_id found.");
                }

                // 查詢是否已有相同 DevelopmentNo + DevelopmentColorNo + StageCode 的資料
                var existingVers = await (from sh in _pcms_Pdm_TestContext.pcg_spec_head
                                          where sh.ref_dev_no == value.DevelopmentNo
                                                && sh.product_d_id == productDId
                                                && sh.stage_code == stageCode
                                          select sh.ver).ToListAsync();

                int newVer = (int)(existingVers.Any() ? existingVers.Max() + 1 : 0); // 若找不到會是 0 ；若已有資料，則最大版本 +1

                // 產生新的 SPEC_M_ID
                var newSpecMId = Guid.NewGuid().ToString();
                var newSpecHead = new pcg_spec_head
                {
                    spec_m_id = newSpecMId,
                    product_d_id = productDId,
                    stage_code = stageCode,
                    ver = newVer,
                    create_mode = "C",
                    create_date = DateTime.Now,
                    create_user_id = pccuid, // 這裡應該改為 USER ID
                    create_user_nm = name, // 這裡應該改為 USER_NAME
                    ref_dev_no = value.DevelopmentNo,
                    remarks_prohibit = value.DevFactoryNo == "6400" ? "※所有材質的使用，均需符合\"ASICS 化學物質管理運用方針\"之規定。" : null
                };

                _pcms_Pdm_TestContext.pcg_spec_head.Add(newSpecHead);

                // **複製原始 SPEC_M_ID 的 pcg_spec_item**
                var specData = await (from si in _pcms_Pdm_TestContext.pcg_spec_item
                                      where si.spec_m_id == specMId
                                      select si).ToListAsync();

                var newSpecItems = specData.Select(si => new pcg_spec_item
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

                _pcms_Pdm_TestContext.pcg_spec_item.AddRange(newSpecItems);

                // 儲存變更
                await _pcms_Pdm_TestContext.SaveChangesAsync();

                return (true, "Copy success.");
            }
            catch (DbException ex)
            {
                return (false, $"Database error occurred: {ex.Message}");
            }
        }
    }
}
