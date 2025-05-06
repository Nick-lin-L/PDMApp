using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos.Basic;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Service.Basic
{
    public static class MaterialQueryHelper
    {
        public static async Task<(bool, string, IQueryable<MaterialDto>)> QueryMaterial(pcms_pdm_testContext _pcms_Pdm_TestContext, MaterialSearchParameter param)
        {
            try
            {
                // 查詢條件卡控：SerpMatNo、MatNo、MatFullNm 至少填一個
                if (string.IsNullOrWhiteSpace(param.SerpMatNo) &&
                    string.IsNullOrWhiteSpace(param.MatNo) &&
                    string.IsNullOrWhiteSpace(param.MatFullNm))
                {
                    return (false, "SERP MATL NO、MATL INFO、PDM MATL NO 需擇一有值", null);
                }

                var baseQuery = from m in _pcms_Pdm_TestContext.matm

                                    // Join attyp name
                                join attypName in _pcms_Pdm_TestContext.sys_namevalue
                                    on new { Key = m.attyp, Group = "attyp" }
                                    equals new { Key = attypName.data_no, Group = attypName.group_key }
                                    into attypJoin
                                from attypName in attypJoin.DefaultIfEmpty()

                                    // Join order_status name
                                join orderStatusName in _pcms_Pdm_TestContext.sys_namevalue
                                    on new { Key = m.order_status, Group = "mat_status" }
                                    equals new { Key = orderStatusName.data_no, Group = orderStatusName.group_key }
                                    into orderStatusJoin
                                from orderStatusName in orderStatusJoin.DefaultIfEmpty()

                                    // Join UOM name
                                join uomName in _pcms_Pdm_TestContext.sys_namevalue
                                    on new { Key = m.uom, Group = "uom" }
                                    equals new { Key = uomName.data_no, Group = uomName.group_key }
                                    into uomJoin
                                from uomName in uomJoin.DefaultIfEmpty()

                                    // Join sys_material_large_class (ScmBclassNoName)
                                join bclass in _pcms_Pdm_TestContext.sys_material_large_class
                                    on m.scm_bclass_no equals bclass.class_l_no
                                    into bclassJoin
                                from bclass in bclassJoin.DefaultIfEmpty()

                                    // Join sys_material_medium_class (ScmMclassNoName)
                                join mclass in _pcms_Pdm_TestContext.sys_material_medium_class
                                    on new { L = m.scm_bclass_no, M = m.scm_mclass_no }
                                    equals new { L = mclass.class_l_no, M = mclass.class_m_no }
                                    into mclassJoin
                                from mclass in mclassJoin.DefaultIfEmpty()

                                    // Join sys_material_small_class (ScmSclassNoName)
                                join sclass in _pcms_Pdm_TestContext.sys_material_small_class
                                    on new { L = m.scm_bclass_no, M = m.scm_mclass_no, S = m.scm_sclass_no }
                                    equals new { L = sclass.class_l_no, M = sclass.class_m_no, S = sclass.class_s_no }
                                    into sclassJoin
                                from sclass in sclassJoin.DefaultIfEmpty()

                                select new MaterialDto
                                {
                                    FactNo = m.fact_no,
                                    MatId = m.mat_id,
                                    Attyp = m.attyp + "-" + attypName.text,
                                    SerpMatNo = m.serp_mat_no,
                                    MatNo = m.mat_no,
                                    MatNm = m.mat_nm,
                                    MatFullNm = m.mat_full_nm,
                                    Uom = m.uom + "-" + uomName.text,
                                    ColorNo = m.color_no,
                                    ColorNm = m.color_nm,
                                    Standard = m.standard,
                                    CustNo = m.cust_no,
                                    Matnr = m.matnr,
                                    ScmBclassNo = m.scm_bclass_no + "-" + bclass.class_name_zh_tw,
                                    ScmMclassNo = m.scm_mclass_no + "-" + mclass.class_name_zh_tw,
                                    ScmSclassNo = m.scm_sclass_no + "-" + sclass.class_name_zh_tw,
                                    Status = m.status,
                                    StopDate = m.stop_date,
                                    Memo = m.memo,
                                    ModifyTime = m.modify_tm,
                                    ModifyUser = m.modify_user,
                                    Locked = m.locked,
                                    OrderStatus = m.order_status + "-" + orderStatusName.text,
                                    TransMsg = m.trans_msg
                                };

                // 篩選條件（以完整格式篩選，例如 1-單材）
                if (!string.IsNullOrWhiteSpace(param.Attyp))
                    baseQuery = baseQuery.Where(x => x.Attyp == param.Attyp);

                if (!string.IsNullOrWhiteSpace(param.SerpMatNo))
                    baseQuery = baseQuery.Where(x => x.SerpMatNo.Contains(param.SerpMatNo));

                if (!string.IsNullOrWhiteSpace(param.MatNo))
                    baseQuery = baseQuery.Where(x => x.MatNo.Contains(param.MatNo));

                if (!string.IsNullOrWhiteSpace(param.MatFullNm))
                    baseQuery = baseQuery.Where(x => x.MatFullNm.Contains(param.MatFullNm));

                if (!string.IsNullOrWhiteSpace(param.Status))
                    baseQuery = baseQuery.Where(x => x.Status == param.Status);

                if (!string.IsNullOrWhiteSpace(param.OrderStatus))
                    baseQuery = baseQuery.Where(x => x.OrderStatus == param.OrderStatus);

                if (!string.IsNullOrWhiteSpace(param.DevFactoryNo))
                    baseQuery = baseQuery.Where(x => x.FactNo == param.DevFactoryNo);

                return (true, "Query successful", baseQuery);
            }
            catch (Exception ex)
            {
                return (false, $"查詢發生錯誤：{ex.Message}", null);
            }
        }



        public static IQueryable<ComboDto> QueryAttyp(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var query = from n in _pcms_Pdm_TestContext.sys_namevalue
                        where n.group_key == "attyp" && n.status == "Y"
                        orderby n.pkid
                        select new ComboDto
                        {
                            Text = n.data_no + "-" + n.text,
                            Value = n.data_no + "-" + n.text
                        };

            return query;
        }

        public static IQueryable<ComboDto> QueryUom(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var query = from n in _pcms_Pdm_TestContext.sys_namevalue
                        where n.group_key == "uom" && n.status == "Y"
                        orderby n.pkid
                        select new ComboDto
                        {
                            Text = n.data_no + "-" + n.text,
                            Value = n.data_no + "-" + n.text
                        };

            return query;
        }

        public static IQueryable<ComboDto> QueryOrderStatus(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var query = from n in _pcms_Pdm_TestContext.sys_namevalue
                        where n.group_key == "mat_status" && n.status == "Y"
                        orderby n.pkid
                        select new ComboDto
                        {
                            Text = n.data_no + "-" + n.text,
                            Value = n.data_no + "-" + n.text
                        };

            return query;
        }

        public static IQueryable<ComboDto> QueryBClass(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var query = from dlc in _pcms_Pdm_TestContext.sys_material_large_class
                        where dlc.is_activate == 'Y'
                        orderby dlc.class_l_no
                        select new ComboDto
                        {
                            Text = dlc.class_l_no + "-" + dlc.class_name_zh_tw,
                            Value = dlc.class_l_no + "-" + dlc.class_name_zh_tw
                        };

            return query;
        }

        public static async Task<Dictionary<string, List<MClassDto>>> QueryMClass(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var query = from dmc in _pcms_Pdm_TestContext.sys_material_medium_class
                        join dlc in _pcms_Pdm_TestContext.sys_material_large_class on dmc.class_l_no equals dlc.class_l_no
                        where dmc.is_activate == 'Y' && dlc.is_activate == 'Y'
                        orderby dlc.class_l_no, dmc.class_m_no
                        select new
                        {
                            ClassLNo = dlc.class_l_no,
                            ClassLName = dlc.class_name_zh_tw,
                            ClassMNo = dmc.class_m_no,
                            ClassName = dmc.class_name_zh_tw
                        };

            // 執行查詢並載入資料
            var rawData = await query.ToListAsync();

            // 根據大分類 (class_l_no + class_name_zh_tw) 分組，並為每個大分類建立中分類列表
            var groupedData = rawData
                .GroupBy(d => d.ClassLNo + "-" + d.ClassLName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(d => new MClassDto
                    {
                        ID = d.ClassLNo + "-" + d.ClassMNo,
                        Text = d.ClassMNo + "-" + d.ClassName,
                        Value = d.ClassMNo + "-" + d.ClassName
                    }).ToList()
                );

            return groupedData;
        }


        public static async Task<Dictionary<string, List<ComboDto>>> QuerySClass(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var query = from dsc in _pcms_Pdm_TestContext.sys_material_small_class
                        join dmc in _pcms_Pdm_TestContext.sys_material_medium_class
                            on new { dsc.class_l_no, dsc.class_m_no } equals new { dmc.class_l_no, dmc.class_m_no }
                        join dlc in _pcms_Pdm_TestContext.sys_material_large_class
                            on dmc.class_l_no equals dlc.class_l_no
                        where dsc.is_activate == 'Y' && dmc.is_activate == 'Y' && dlc.is_activate == 'Y'
                        orderby dmc.class_m_no, dsc.class_s_no
                        select new
                        {
                            ClassLNo = dsc.class_l_no,
                            ClassMNo = dsc.class_m_no,
                            ClassSNo = dsc.class_s_no,
                            ClassSName = dsc.class_name_zh_tw
                        };

            var rawData = await query.ToListAsync();

            // 依 "大分類-中分類" 分組，轉成 Dictionary
            var groupedData = rawData
                .GroupBy(d => d.ClassLNo + "-" + d.ClassMNo)
                .ToDictionary(
                    g => g.Key,// Key 為 "大分類-中分類"
                    g => g
                        .Where(d => !string.IsNullOrEmpty(d.ClassSNo) && !string.IsNullOrEmpty(d.ClassSName))// 過濾小分類代號與名稱不為空的資料
                        .Select(d => new ComboDto
                        {
                            Text = d.ClassSNo + "-" + d.ClassSName,
                            Value = d.ClassSNo + "-" + d.ClassSName
                        })
                        .ToList()
                );

            return groupedData;
        }


    }
}
