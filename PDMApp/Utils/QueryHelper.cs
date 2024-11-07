﻿using PDMApp.Dtos;
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
                    join pn in _pcms_Pdm_TestContext.pdm_namevalue on sh.stage equals pn.value_desc
                    where pn.group_key == "stage"
                    select new pdm_spec_headDto
                    {
                        Year = ph.year,
                        Season = ph.season,
                        Entrymode = sh.entrymode,
                        Stage = pn.text, //使用前端傳入的「值」直接查詢key value的value
                        OutMoldNo = ph.out_mold_no,
                        MoldNo = (ph.out_mold_no + "/" + ph.mid_mold_no + "/" + ph.etc_mold_no).Trim('/'),
                        Shfactory = sh.factory,
                        Factory = (ph.factory1 + "," + ph.factory2 + "," + ph.factory3).Replace(",,", ","),
                        ItemNameEng = ph.item_name_eng,
                        ItemNameJpn = ph.item_name_jpn,
                        ItemNo = ph.item_no,
                        DevNo = ph.dev_no,
                        DevColorDispName = pi.dev_color_disp_name,
                        ColorNo = pi.color_no,
                        Spec_m_id = sh.spec_m_id,
                        Cbdlockmk = sh.cbdlockmk,
                        ProductMId = ph.product_m_id,
                        ProductDId = pi.product_d_id,
                        pdm_Spec_ItemDtos = new List<pdm_spec_itemDto>() // 初始化空的 Spec_ItemDtos 列表
                    });
        }


        public static IQueryable<SpecBasicDTO> GetSpecBasicResponse(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            // 使用多表 Join 查詢來組合所需欄位
            return (from ph in _pcms_Pdm_TestContext.pdm_product_head
                    join pi in _pcms_Pdm_TestContext.pdm_product_item on ph.product_m_id equals pi.product_m_id
                    join sh in _pcms_Pdm_TestContext.pdm_spec_head on pi.product_d_id equals sh.product_d_id
                    join si in _pcms_Pdm_TestContext.pdm_spec_item on sh.spec_m_id equals si.spec_m_id
                    join pn in _pcms_Pdm_TestContext.pdm_namevalue on sh.stage equals pn.value_desc
                    where pn.group_key == "stage"
                    select new SpecBasicDTO
                    {
                        DevNo = ph.dev_no,
                        DevColorNo = pi.dev_color_no,
                        Stage = pn.text, //使用前端傳入的「值」直接查詢key value的value
                        Ver = sh.ver,
                        Entrymode = sh.entrymode,
                        SampleSize = ph.sample_size,
                        Year = ph.year,
                        Season = ph.season,
                        CategoryKbn = ph.category_kbn,
                        MoldNo = (ph.out_mold_no + "/" + ph.mid_mold_no + "/" + ph.etc_mold_no).Trim('/'),
                        ItemNo = ph.item_no,
                        ItemNameEng = ph.item_name_eng,
                        ItemNameJpn = ph.item_name_jpn,
                        ColorNameEng = pi.color_name_eng,
                        ColorNameJpn = pi.color_name_jpn,
                        SizeRun = pi.size_run,
                        //Factory = string.Join(",", new[] { ph.factory1, ph.factory2, ph.factory3 }.Where(f => !string.IsNullOrEmpty(f))),
                        Factory = (ph.factory1 + "," + ph.factory2 + "," + ph.factory3).Replace(",,", ","),
                        FactoryUpper = ph.factory_upper,
                        HeelHeight = sh.heelheight,
                        Lasting = sh.lasting,
                        RequstWeight = ph.request_weight,
                        LastNo1 = ph.last_no1,
                        LastNo2 = ph.last_no2,
                        LastNo3 = ph.last_no3,
                        UpperSozaiCode = pi.upper_sozai_code,
                        SoleSozaiCode = pi.sole_sozai_code,
                        ColorNo = pi.color_no,
                        SizeConversionType = ph.kanzan_type,
                        SpecialConversion = ph.sp_kanzan,
                        Remarks = sh.remarks_spec,

                        OutMoldNo = ph.out_mold_no,
                        Shfactory = sh.factory,

                        DevColorDispName = pi.dev_color_disp_name,
                        SpecMId = sh.spec_m_id,
                        Cbdlockmk = sh.cbdlockmk,
                        ProductMId = ph.product_m_id,
                        ProductDId = pi.product_d_id
                    });
        }
        public static IQueryable<SpecUpperDTO> GetSpecUpperResponse(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from si in _pcms_Pdm_TestContext.pdm_spec_item 
                    select new SpecUpperDTO
                    {
                        Spec_m_id = si.spec_m_id,
                        No = si.no,
                        Type = si.newmaterial,
                        Parts = si.parts,
                        Mold_no = si.moldno,
                        Factory_mold_no = si.factory_mold_no,
                        Material_no = si.materialno,
                        Material = si.material,
                        Sub_material = si.submaterial,
                        Standard = si.standard,
                        Supplier = si.supplier,
                        Hcha = si.hcha,
                        Sec = si.sec,
                        Colors = si.colors,
                        Data_id = si.data_id,
                        Seqno = si.seqno,
                        Act_no = si.act_no,
                        Width = si.width,
                        Memo = si.memo,
                        PartClass = si.partclass
                    });
        }

        public static IQueryable<SpecStandardDTO> GetSpecStandardResponse(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from st in _pcms_Pdm_TestContext.pdm_spec_standard
                    select new SpecStandardDTO
                    {
                        Spec_m_id = st.spec_m_id,
                        Seq = st.seqno,
                        Size = st.the_size,
                        Shoe_lace_length = st.itemval1,
                        Shoe_box = st.itemval2,
                        Gel_fore = st.itemval3,
                        Gel_rear = st.itemval4,
                        Toe_Keeper = st.itemval5,
                        Shoe_bag = st.itemval6,
                        Itemval7 = st.itemval7,
                        Itemval8 = st.itemval8,
                        Itemval9 = st.itemval9,
                        Memo = st.memo
                    });
        }
    }
}
