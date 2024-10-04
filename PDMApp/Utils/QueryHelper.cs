using PDMApp.Dtos;
using PDMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Utils
{
    public static class QueryHelper
    {
        public static IQueryable<pdm_spec_headDto> QuerySpecHead(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            // 使用多表 Join 查詢來組合所需欄位
            return (from ph in _pcms_Pdm_TestContext.pdm_product_head
                    join pi in _pcms_Pdm_TestContext.pdm_product_item on ph.product_m_id equals pi.product_m_id
                    join sh in _pcms_Pdm_TestContext.pdm_spec_head on pi.product_d_id equals sh.product_d_id
                    join si in _pcms_Pdm_TestContext.pdm_spec_item on sh.spec_m_id equals si.spec_m_id
                    select new pdm_spec_headDto
                    {
                        Year = ph.year,
                        Season = ph.season,
                        Entrymode = sh.entrymode,
                        Stage = sh.stage,
                        out_mold_no = ph.out_mold_no,
                        Mold_no = (ph.out_mold_no + "/" + ph.mid_mold_no + "/" + ph.etc_mold_no).Trim('/'),
                        Shfactory = sh.factory,
                        Factory = (ph.factory1 + "," + ph.factory2 + "," + ph.factory3).Replace(",,", ","),
                        Item_name_eng = ph.item_name_eng,
                        Item_name_jpn = ph.item_name_jpn,
                        Item_no = ph.item_no,
                        Dev_no = ph.dev_no,
                        Dev_color_disp_name = pi.dev_color_disp_name,
                        Color_no = pi.color_no,
                        Spec_m_id = sh.spec_m_id,
                        Cbdlockmk = sh.cbdlockmk,
                        Product_m_id = ph.product_m_id,
                        Product_d_id = pi.product_d_id,
                        pdm_Spec_ItemDtos = new List<pdm_spec_itemDto>() // 初始化空的 Spec_ItemDtos 列表
                    });
        }
    }
}
