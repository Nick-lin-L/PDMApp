using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Service.PGTSPEC
{
    public class PGTSPECInsertHelper
    {
        /// <summary>
        /// 插入 SPEC 資料，根據 SpecSource 決定是否插入 pcg_spec_item。
        /// </summary>
        public static async Task<(bool, string)> InsertSpecAsync(pcms_pdm_testContext _pcms_Pdm_TestContext, InsertSpecParameter value,string pccuid,string name)
        {
            try
            {
                // 檢查必要參數是否缺失
                if (string.IsNullOrWhiteSpace(value.DevelopmentNo) ||
                    string.IsNullOrWhiteSpace(value.DevelopmentColorNo) ||
                    string.IsNullOrWhiteSpace(value.Stage) ||
                    string.IsNullOrWhiteSpace(value.DevFactoryNo) ||
                    string.IsNullOrWhiteSpace(value.SpecSource) ||
                    string.IsNullOrWhiteSpace(value.Brand))
                {
                    return (false, "Missing required parameters.");
                }

                // 查詢 StageCode
                var stageCode = await (from n in _pcms_Pdm_TestContext.pdm_namevalue_new
                                       where n.group_key == "stage" && n.text == value.Stage
                                       select n.value_desc).FirstOrDefaultAsync();

                if (string.IsNullOrEmpty(stageCode))
                {
                    return (false, "Invalid Stage provided.");
                }

                // 查詢 plm_product_head, plm_product_item, plm_spec_head，確保產品與規格匹配
                var productData = await (from ph in _pcms_Pdm_TestContext.plm_product_head
                                         join pi in _pcms_Pdm_TestContext.plm_product_item on ph.product_m_id equals pi.product_m_id
                                         join sh in _pcms_Pdm_TestContext.plm_spec_head on pi.product_d_id equals sh.product_d_id
                                         join n in _pcms_Pdm_TestContext.pdm_namevalue_new on ph.brand_no equals n.value_desc
                                         where ph.development_no == value.DevelopmentNo
                                         && pi.development_color_no == value.DevelopmentColorNo
                                         && n.text == value.Brand
                                         select new { pi.product_d_id, sh.spec_m_id }).ToListAsync();

                if (!productData.Any())
                {
                    return (false, "No matching records found in plm_product_item or plm_spec_head.");
                }

                var productDId = productData.First().product_d_id;
                var specIds = productData.First().spec_m_id;

                // 確認是否已有相同 productDId  的 pcg_spec_head
                bool exists = await _pcms_Pdm_TestContext.pcg_spec_head
                    .AnyAsync(x => x.product_d_id == productDId);

                if (exists)
                {
                    return (false, "該型體&階段已存在於系統中，若要進版請使用 CHECK OUT 功能。");
                }

                // 建立新 pcg_spec_head 記錄
                var newSpecHead = new pcg_spec_head
                {
                    spec_m_id = Guid.NewGuid().ToString(), // 產生新的 SPEC 主鍵
                    product_d_id = productDId,
                    stage_code = stageCode,
                    ver = 0,
                    create_mode = value.SpecSource == "NEW" ? "B" : "A",
                    create_date = DateTime.Now,
                    create_user_id = pccuid,
                    create_user_nm = name,
                    remarks_prohibit = value.DevFactoryNo == "6400" ? "※所有材質的使用，均需符合\"ASICS 化學物質管理運用方針\"之規定。" : null
                };

                _pcms_Pdm_TestContext.pcg_spec_head.Add(newSpecHead);

                // 若 SpecSource 為 "原文SPEC"，則需同步插入 pcg_spec_item
                if (value.SpecSource == "原文SPEC")
                {
                    // 查詢對應的規格項目
                    var specData = await (from si in _pcms_Pdm_TestContext.plm_spec_item
                                          where specIds.Contains(si.spec_m_id)
                                          select si).ToListAsync();

                    if (!specData.Any())
                    {
                        return (false, "No matching records found in plm_spec_item.");
                    }

                    // 取得 material_group 的對應名稱
                    var materialGroupData = await (from n in _pcms_Pdm_TestContext.pdm_namevalue_new
                                                   where n.group_key == "material_group"
                                                   && specData.Select(si => si.material_group).Contains(n.value_desc)
                                                   select new { n.value_desc, n.text }).ToListAsync();

                    // 生成新的 pcg_spec_item 記錄
                    var newSpecItems = specData.Select(si => new pcg_spec_item
                    {
                        spec_d_id = Guid.NewGuid().ToString(),
                        spec_m_id = newSpecHead.spec_m_id,
                        material_sort = si.material_sort,
                        material_group = materialGroupData.FirstOrDefault(mg => mg.value_desc == si.material_group)?.text ?? si.material_group,
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
                }

                // 儲存變更
                await _pcms_Pdm_TestContext.SaveChangesAsync();
                return (true, "Insert success.");
            }
            catch (DbException ex)
            {
                return (false, $"Database error occurred: {ex.Message}");
            }
        }
    }
}