﻿
using Dtos.FactorySpec;
using PDMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PDMApp.Service.FactorySpec
{
    public static class FactorySpecQueryHelper
    {
        public static (bool, string, IQueryable<FactorySpecHeaderDto>) QuerySpecHead(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            try
            {
                var query = (from ph in _pcms_Pdm_TestContext.pdm_product_head
                             join pi in _pcms_Pdm_TestContext.pdm_product_item on ph.product_m_id equals pi.product_m_id
                             join shf in _pcms_Pdm_TestContext.pdm_spec_head_factory on pi.product_d_id equals shf.product_d_id
                             join pn in _pcms_Pdm_TestContext.pdm_namevalue on shf.stage equals pn.value_desc
                             where pn.group_key == "stage"
                             join pnse in _pcms_Pdm_TestContext.pdm_namevalue on ph.season equals pnse.value_desc
                             where pnse.group_key == "season"
                             select new FactorySpecHeaderDto
                             {
                                 SpecMId = shf.spec_m_id,
                                 Year = ph.year,
                                 Season = pnse.text, //使用前端傳入的「值」直接查詢key value的value
                                 EntryMode = shf.entrymode,
                                 Factory = shf.factory,
                                 Stage = pn.text, //使用前端傳入的「值」直接查詢key value的value
                                 ItemNo = ph.item_no,
                                 DevNo = ph.dev_no,
                                 DevColorDispName = pi.dev_color_disp_name,
                                 ColorNo = pi.color_no,
                                 Fty1 = ph.factory1,
                                 Fty2 = ph.factory2,
                                 Fty3 = ph.factory3,
                                 Ver = shf.ver,
                                 VssVer = shf.vssver,
                                 SpecUpdateDate = shf.spec_update_date,
                                 SpecUpdateUser = shf.spec_update_user
                             });

                return (true, "Query successful", query);
            }
            catch (Exception ex)
            {
                return (false, $"Query failed: {ex.Message}", null);
            }
        }




        public static IQueryable<SpecBasicDTO> GetSpecBasicResponse(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            // 使用多表 Join 查詢來組合所需欄位
            return (from ph in _pcms_Pdm_TestContext.pdm_product_head
                    join pi in _pcms_Pdm_TestContext.pdm_product_item on ph.product_m_id equals pi.product_m_id
                    join shf in _pcms_Pdm_TestContext.pdm_spec_head_factory on pi.product_d_id equals shf.product_d_id
                    join sif in _pcms_Pdm_TestContext.pdm_spec_item_factory on shf.spec_m_id equals sif.spec_m_id                  
                    join pn in _pcms_Pdm_TestContext.pdm_namevalue on shf.stage equals pn.value_desc
                    where pn.group_key == "stage"
                    join pnse in _pcms_Pdm_TestContext.pdm_namevalue on ph.season equals pnse.value_desc
                    where pnse.group_key == "season"

                    let mailTo = (from f in _pcms_Pdm_TestContext.pdm_factoryspec_ref_signflow
                                  join h in _pcms_Pdm_TestContext.pdm_history_denamic_signflow on f.id equals h.id.ToString()
                                  where f.spec_m_id == shf.spec_m_id && f.sub_bill_class == "01"
                                  select h.signflow_cn).FirstOrDefault()
                    let mailCC = (from f in _pcms_Pdm_TestContext.pdm_factoryspec_ref_signflow
                                  join h in _pcms_Pdm_TestContext.pdm_history_denamic_signflow on f.id equals h.id.ToString()
                                  where f.spec_m_id == shf.spec_m_id && f.sub_bill_class == "02"
                                  select h.signflow_cn).FirstOrDefault()

                    select new SpecBasicDTO
                    {
                        SpecMId = shf.spec_m_id,
                        DevNo = ph.dev_no,
                        DevColorNo = pi.dev_color_no,
                        Stage = pn.text, //使用前端傳入的「值」直接查詢key value的value
                        Ver = shf.ver,
                        EntryMode = shf.entrymode,
                        SampleSize = ph.sample_size,
                        Year = ph.year,
                        Season = pnse.text,
                        CategoryKbn = ph.category_kbn,
                        Mode = ph.mode_name,
                        ItemNo = ph.item_no,
                        ItemNameEng = ph.item_name_eng,
                        ItemNameJpn = ph.item_name_jpn,
                        ColorNameEng = pi.color_name_eng,
                        ColorNameJpn = pi.color_name_jpn,
                        SizeRun = pi.size_run,
                        Factory = (ph.factory1 + "," + ph.factory2 + "," + ph.factory3).Replace(",,", ","),
                        FactoryUpper = ph.factory_upper,
                        HeelHeight = shf.heelheight,
                        Lasting = shf.lasting,
                        RequstWeight = ph.request_weight,
                        LastNo1 = ph.last_no1,
                        LastNo2 = ph.last_no2,
                        LastNo3 = ph.last_no3,
                        UpperSozaiCode = pi.upper_sozai_code,
                        SoleSozaiCode = pi.sole_sozai_code,
                        ColorNameChn = shf.color_name_chn,
                        RefDevNo = shf.ref_dev_no,
                        FactoryMoldNo1 = shf.mold_no1,
                        FactoryMoldNo2 = shf.mold_no2,
                        FactoryMoldNo3 = shf.mold_no3,
                        MailTo = mailTo,
                        MailCC = mailCC,
                        ColorNo = pi.color_no,
                        SizeConversionType = ph.kanzan_type,
                        SpecialConversion = ph.sp_kanzan,
                        Remarks = shf.remarks_spec,
                        RemarksProhibit = shf.remarks_prohibit
                    });
        }

        public static IQueryable<SpecUpperDTO> GetSpecUpperResponse(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from si in _pcms_Pdm_TestContext.pdm_spec_item_factory
                    select new SpecUpperDTO
                    {
                        SpecMId = si.spec_m_id,
                        No = si.no,
                        Type = si.newmaterial,
                        Parts = si.parts,
                        MoldNo = si.moldno,
                        FactoryMoldNo = si.factory_mold_no,
                        MaterialNo = si.materialno,
                        Material = si.material,
                        SubMaterial = si.submaterial,
                        Standard = si.standard,
                        Supplier = si.supplier,
                        Hcha = si.hcha,
                        Sec = si.sec,
                        Colors = si.colors,
                        DataId = si.data_id,
                        SeqNo = si.seqno,
                        ActNo = si.act_no,
                        Width = si.width,
                        Memo = si.memo,
                        PartClass = si.partclass
                    });
        }

        public static IQueryable<SpecStandardDTO> GetSpecStandardResponse(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from st in _pcms_Pdm_TestContext.pdm_spec_standard_factory
                    select new SpecStandardDTO
                    {
                        SpecMId = st.spec_m_id,
                        Seq = st.seqno,
                        Size = st.the_size,
                        ShoeLaceLength = st.itemval1,
                        ShoeBox = st.itemval2,
                        GelFore = st.itemval3,
                        GelRear = st.itemval4,
                        Toekeeper = st.itemval5,
                        ShoeBag = st.itemval6,
                        Itemval7 = st.itemval7,
                        Itemval8 = st.itemval8,
                        Itemval9 = st.itemval9,
                        Memo = st.memo
                    });
        }
        public static IQueryable<ItemSheetDTO> GetItemSheetResponse(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from ph in _pcms_Pdm_TestContext.pdm_product_head
                    join pi in _pcms_Pdm_TestContext.pdm_product_item on ph.product_m_id equals pi.product_m_id
                    join shf in _pcms_Pdm_TestContext.pdm_spec_head_factory on pi.product_d_id equals shf.product_d_id
                    join sif in _pcms_Pdm_TestContext.pdm_spec_item_factory on shf.spec_m_id equals sif.spec_m_id
                    join pn in _pcms_Pdm_TestContext.pdm_namevalue on shf.stage equals pn.value_desc
                    where pn.group_key == "stage"

                    let mailTo = (from f in _pcms_Pdm_TestContext.pdm_factoryspec_ref_signflow
                                  join h in _pcms_Pdm_TestContext.pdm_history_denamic_signflow on f.id equals h.id.ToString()
                                  where f.spec_m_id == shf.spec_m_id && f.sub_bill_class == "01"
                                  select h.signflow_cn).FirstOrDefault()
                    let mailCC = (from f in _pcms_Pdm_TestContext.pdm_factoryspec_ref_signflow
                                  join h in _pcms_Pdm_TestContext.pdm_history_denamic_signflow on f.id equals h.id.ToString()
                                  where f.spec_m_id == shf.spec_m_id && f.sub_bill_class == "02"
                                  select h.signflow_cn).FirstOrDefault()
                    select new ItemSheetDTO
                    {
                        SpecMId = shf.spec_m_id,
                        MailTo = mailTo,  // 預設為 null，根據需求填入
                        MailCC = mailCC,  // 預設為 null，根據需求填入
                        Stage = pn.text, // 使用 Join 的 stage 對應的 text 值
                        ActNo = sif.act_no,
                        CreateTime = DateTime.Now.ToString("yyyy/MM/dd"),              
                        DevNo = ph.dev_no,
                        RefDevNo = shf.ref_dev_no,
                        ItemNameEng = ph.item_name_eng,
                        ItemNo = ph.item_no,
                        ColorNo = pi.color_no,
                        SampleSize = ph.sample_size,
                        HeelHeight = shf.heelheight,
                        ColorNameChn = shf.color_name_chn,
                        ColorEng = pi.color_name_eng,
                        FactoryMoldNo1 = shf.mold_no1,
                        FactoryMoldNo2 = shf.mold_no2,
                        FactoryMoldNo3 = shf.mold_no3,
                        LastNo1 = ph.last_no1,
                        LastNo2 = ph.last_no2,
                        LastNo3 = ph.last_no3,
                        CreateUser = shf.create_user,
                        Type = sif.newmaterial == "*" ? "△" : sif.newmaterial, // 轉換邏輯
                        Parts = sif.parts, 
                        No = sif.no,
                        Material = sif.material ?? sif.submaterial, // 如果 Material 為 null，就使用 SubMaterial
                        SubMaterial = sif.submaterial,
                        Colors = sif.colors, 
                        Standard = sif.standard, 
                        Hcha = sif.hcha, 
                        Sec = sif.sec,
                        Supplier = sif.supplier,
                        Seqno = sif.seqno,
                        PartClass = sif.partclass,
                        RemarksProhibit = shf.remarks_prohibit 
                    });
        }
        public static IQueryable<StandardSheetDTO> GetSpecStandardSheetResponse(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from ph in _pcms_Pdm_TestContext.pdm_product_head
                    join pi in _pcms_Pdm_TestContext.pdm_product_item on ph.product_m_id equals pi.product_m_id
                    join shf in _pcms_Pdm_TestContext.pdm_spec_head_factory on pi.product_d_id equals shf.product_d_id
                    join st in _pcms_Pdm_TestContext.pdm_spec_standard_factory on shf.spec_m_id equals st.spec_m_id
                    join pn in _pcms_Pdm_TestContext.pdm_namevalue on shf.stage equals pn.value_desc
                    where pn.group_key == "stage"
                    select new StandardSheetDTO
                    {
                        SpecMId = st.spec_m_id,
                        Stage = pn.text,
                        CreateTime = DateTime.Now.ToString("yyyy/MM/dd"),
                        DevNo = ph.dev_no,
                        RefDevNo = shf.ref_dev_no,
                        ItemNameEng = ph.item_name_eng,
                        ItemNo = ph.item_no,
                        ColorNo = pi.color_no,
                        SampleSize = ph.sample_size,
                        HeelHeight = shf.heelheight,
                        ColorNameChn = shf.color_name_chn,
                        ColorEng = pi.color_name_eng,
                        FactoryMoldNo1 = shf.mold_no1,
                        FactoryMoldNo2 = shf.mold_no2,
                        FactoryMoldNo3 = shf.mold_no3,
                        LastNo1 = ph.last_no1,
                        LastNo2 = ph.last_no2,
                        LastNo3 = ph.last_no3,
                        CreateUser = shf.create_user,
                        Seq = st.seqno,
                        Size = st.the_size,
                        ShoeLaceLength = st.itemval1,
                        ShoeBox = st.itemval2,
                        GelFore = st.itemval3,
                        GelRear = st.itemval4,
                        Toekeeper = st.itemval5,
                        ShoeBag = st.itemval6,
                        Seqno = st.seqno,
                    });
        }

    }
}
