using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Utils.PGTSPEC
{
    public class PGTSPECInsertHelper
    {
        public static async Task<IActionResult> InsertSpecAsync(pcms_pdm_testContext _pcms_Pdm_TestContext, [FromBody] InsertSpecParameter value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value.DevelopmentNo) ||
                    string.IsNullOrWhiteSpace(value.DevelopmentColorNo) ||
                    string.IsNullOrWhiteSpace(value.Stage) ||
                    string.IsNullOrWhiteSpace(value.DevFactoryNo) ||
                    string.IsNullOrWhiteSpace(value.SpecSource) ||
                    string.IsNullOrWhiteSpace(value.Brand))
                {
                    return new BadRequestObjectResult(new { Message = "Missing required parameters." });
                }

                // 取得 stage_code
                var stageCode = await (from n in _pcms_Pdm_TestContext.pdm_namevalue_new
                                       where n.group_key == "stage" && n.text == value.Stage
                                       select n.value_desc).FirstOrDefaultAsync();

                if (string.IsNullOrEmpty(stageCode))
                {
                    return new BadRequestObjectResult(new { Message = "Invalid Stage provided." });
                }

                // 取得 PRODUCT_D_ID & SPEC_M_ID
                var productData = await (from ph in _pcms_Pdm_TestContext.plm_product_head
                                         join pi in _pcms_Pdm_TestContext.plm_product_item
                                             on ph.product_m_id equals pi.product_m_id
                                         join sh in _pcms_Pdm_TestContext.plm_spec_head
                                             on pi.product_d_id equals sh.product_d_id
                                         join n in _pcms_Pdm_TestContext.pdm_namevalue_new
                                             on ph.brand_no equals n.value_desc
                                         where ph.development_no == value.DevelopmentNo
                                               && pi.development_color_no == value.DevelopmentColorNo
                                               && n.text == value.Brand // 根據品牌過濾
                                         select new
                                         {
                                             pi.product_d_id,
                                             sh.spec_m_id
                                         }).ToListAsync();

                if (!productData.Any())
                {
                    return new NotFoundObjectResult(new { Message = "No matching records found in plm_product_item or plm_spec_head." });
                }

                // 確保 PRODUCT_D_ID 存在
                var productDId = productData.First().product_d_id;
                var specIds = productData.First().spec_m_id;

                // **插入 pcg_spec_head**
                var newSpecHead = new pcg_spec_head
                {
                    spec_m_id = Guid.NewGuid().ToString(),
                    product_d_id = productDId, // 無論 SpecSource 都要有
                    stage_code = stageCode,
                    ver = 0,
                    create_mode = value.SpecSource == "NEW" ? "B" : "A",
                    create_date = DateTime.Now,
                    create_user_id = "20211200037074", // 這裡應該改為 USER ID
                    create_user_nm = "鄭名硯", // 這裡應該改為 USER_NAME
                    remarks_prohibit = value.DevFactoryNo == "6400" ? "※所有材質的使用，均需符合\"ASICS 化學物質管理運用方針\"之規定。" : null
                };

                _pcms_Pdm_TestContext.pcg_spec_head.Add(newSpecHead);

                // **只有當 SpecSource 為 "原文SPEC" 時才插入 pcg_spec_item**
                if (value.SpecSource == "原文SPEC")
                {
                    // 根據 spec_m_id 查詢 plm_spec_item
                    var specData = await (from si in _pcms_Pdm_TestContext.plm_spec_item
                                          where specIds.Contains(si.spec_m_id)
                                          select new
                                          {
                                              si.spec_m_id,
                                              si.spec_d_id,
                                              si.material_sort,
                                              si.material_group,
                                              si.parts_no,
                                              si.material_new,
                                              si.parts,
                                              si.detail,
                                              si.process_mk,
                                              si.material,
                                              si.mat_comment,
                                              si.standard,
                                              si.agent,
                                              si.supplier,
                                              si.quote_supplier,
                                              si.hcha,
                                              si.sec,
                                              si.material_color,
                                              si.clr_comment,
                                              si.add_date,
                                              si.update_date,
                                              si.mtrtype,
                                              si.mtrbase,
                                              si.processing,
                                              si.effect,
                                              si.releasepaper,
                                              si.basecolor,
                                              si.act_part_no,
                                              si.part_mk,
                                              si.recycle
                                          }).ToListAsync();

                    if (!specData.Any())
                    {
                        return new NotFoundObjectResult(new { Message = "No matching records found in plm_spec_item." });
                    }

                    // 查詢 material_group 對應的 text 值
                    var materialGroupData = await (from n in _pcms_Pdm_TestContext.pdm_namevalue_new
                                                   where n.group_key == "material_group"
                                                         && specData.Select(si => si.material_group).Contains(n.value_desc)
                                                   select new
                                                   {
                                                       n.value_desc,
                                                       n.text
                                                   }).ToListAsync();

                    var newSpecItems = specData.Select(si =>
                    {
                        // 查找對應的 material_group text
                        var materialGroupText = materialGroupData.FirstOrDefault(mg => mg.value_desc == si.material_group)?.text;

                        return new pcg_spec_item
                        {
                            spec_d_id = Guid.NewGuid().ToString(),
                            spec_m_id = newSpecHead.spec_m_id,
                            material_sort = si.material_sort,
                            material_group = materialGroupText ?? si.material_group, // 若找不到對應的 material_group，則使用原本的值
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
                        };
                    }).ToList();

                    _pcms_Pdm_TestContext.pcg_spec_item.AddRange(newSpecItems);
                }

                // 儲存變更
                await _pcms_Pdm_TestContext.SaveChangesAsync();

                return new OkObjectResult(new { Message = "Insert success." });
            }
            catch (DbException ex)
            {
                return new ObjectResult(new
                {
                    ErrorCode = "Server_ERROR",
                    Message = "Database error occurred.",
                    Details = ex.Message
                })
                {
                    StatusCode = 500
                };
            }
        }
    }
}
