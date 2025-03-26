using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using PDMApp.Parameters.ALink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Utils
{
    public static class QueryHelper
    {
        public static IQueryable<pdm_spec_headDto> QuerySpecHead(pcms_pdm_testContext _pcms_Pdm_TestContext,SpecSearchParameter searchParams)
        {
            // 基礎查詢
            var query = from ph in _pcms_Pdm_TestContext.pdm_product_head
                        join pi in _pcms_Pdm_TestContext.pdm_product_item on ph.product_m_id equals pi.product_m_id
                        join sh in _pcms_Pdm_TestContext.pdm_spec_head on pi.product_d_id equals sh.product_d_id
                        join si in _pcms_Pdm_TestContext.pdm_spec_item on sh.spec_m_id equals si.spec_m_id
                        join pn in _pcms_Pdm_TestContext.pdm_namevalue on sh.stage equals pn.value_desc
                        where pn.group_key == "stage"
                        join pnse in _pcms_Pdm_TestContext.pdm_namevalue on ph.season equals pnse.value_desc
                        where pnse.group_key == "season"
                        select new pdm_spec_headDto
                        {
                            Year = ph.year,
                            Season = pnse.text,
                            EntryMode = sh.entrymode,
                            Stage = pn.text,
                            MoldNo = (ph.out_mold_no + "/" + ph.mid_mold_no + "/" + ph.etc_mold_no).Trim('/'),
                            OutMoldNo = ph.out_mold_no,
                            Shfactory = sh.factory,
                            Factory = (ph.factory1 + "," + ph.factory2 + "," + ph.factory3).Replace(",,", ","),
                            ItemNameEng = ph.item_name_eng,
                            ItemNameJpn = ph.item_name_jpn,
                            ItemNo = ph.item_no,
                            DevNo = ph.dev_no,
                            DevColorDispName = pi.dev_color_disp_name,
                            ColorNo = pi.color_no,
                            SpecMId = sh.spec_m_id,
                            Cbdlockmk = sh.cbdlockmk,
                            ProductMId = ph.product_m_id,
                            ProductDId = pi.product_d_id,
                            CustomerKbn = ph.customer_kbn,
                            Mode = ph.mode_name,
                            LastNo = string.Join(",", new[] {ph.last_no1,ph.last_no2,ph.last_no3 }.Where(ln => !string.IsNullOrEmpty(ln))),
                            LastNo1 = ph.last_no1,
                            LastNo2 = ph.last_no2,
                            LastNo3 = ph.last_no3,
                            HeelHeight = sh.heelheight.ToString(),
                            Material = si.material,
                            SubMaterial = si.submaterial,
                            Supplier = si.supplier,
                            Width = si.width,
                            PartNo = si.act_no,
                            MatColor = si.colors
                        };

            // 精確匹配條件
            if (!string.IsNullOrWhiteSpace(searchParams.SpecMId))
                query = query.Where(ph => ph.SpecMId == searchParams.SpecMId);
            if (!string.IsNullOrWhiteSpace(searchParams.Factory))
                query = query.Where(ph => ph.Factory == searchParams.Factory);
            if (!string.IsNullOrWhiteSpace(searchParams.EntryMode))
                query = query.Where(ph => ph.EntryMode == searchParams.EntryMode);
            if (!string.IsNullOrWhiteSpace(searchParams.Season))
                query = query.Where(ph => ph.Season == searchParams.Season);
            if (!string.IsNullOrWhiteSpace(searchParams.Year))
                query = query.Where(ph => ph.Year == searchParams.Year);
            if (!string.IsNullOrWhiteSpace(searchParams.Stage))
                query = query.Where(ph => ph.Stage == searchParams.Stage);
            if (!string.IsNullOrWhiteSpace(searchParams.CustomerKbn))
                query = query.Where(ph => ph.CustomerKbn == searchParams.CustomerKbn);
            if (!string.IsNullOrWhiteSpace(searchParams.ModeName))
                query = query.Where(ph => ph.Mode == searchParams.ModeName);

            // 模糊匹配條件
            if (!string.IsNullOrWhiteSpace(searchParams.ItemNo))
                query = query.Where(ph => ph.ItemNo != null && EF.Functions.Like(ph.ItemNo, $"%{searchParams.ItemNo}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.ColorNo))
                query = query.Where(ph => ph.ColorNo != null && EF.Functions.Like(ph.ColorNo, $"%{searchParams.ColorNo}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.DevNo))
                query = query.Where(ph => ph.DevNo != null && EF.Functions.Like(ph.DevNo, $"%{searchParams.DevNo}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.Devcolorno))
                query = query.Where(ph => ph.DevColorDispName != null && EF.Functions.Like(ph.DevColorDispName, $"%{searchParams.Devcolorno}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.OutMoldNo))
                query = query.Where(ph => ph.OutMoldNo != null && EF.Functions.Like(ph.OutMoldNo, $"%{searchParams.OutMoldNo}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.LastNo))
                query = query.Where(ph => ph.LastNo != null && EF.Functions.Like(ph.LastNo, $"%{searchParams.LastNo}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.ItemNameENG))
                query = query.Where(ph => ph.ItemNameEng != null && EF.Functions.Like(ph.ItemNameEng, $"%{searchParams.ItemNameENG}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.ItemNameJPN))
                query = query.Where(ph => ph.ItemNameJpn != null && EF.Functions.Like(ph.ItemNameJpn, $"%{searchParams.ItemNameJPN}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.PartName))
                query = query.Where(ph => ph.PartName != null && EF.Functions.Like(ph.PartName, $"%{searchParams.PartName}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.PartNo))
                query = query.Where(ph => ph.PartNo != null && EF.Functions.Like(ph.PartNo, $"%{searchParams.PartNo}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.MatColor))
                query = query.Where(ph => ph.MatColor != null && EF.Functions.Like(ph.MatColor, $"%{searchParams.MatColor}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.Material))
                query = query.Where(ph => ph.Material != null && EF.Functions.Like(ph.Material, $"%{searchParams.Material}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.SubMaterial))
                query = query.Where(ph => ph.SubMaterial != null && EF.Functions.Like(ph.SubMaterial, $"%{searchParams.SubMaterial}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.Supplier))
                query = query.Where(ph => ph.Supplier != null && EF.Functions.Like(ph.Supplier, $"%{searchParams.Supplier}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.Width))
                query = query.Where(ph => ph.Width != null && EF.Functions.Like(ph.Width, $"%{searchParams.Width}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.HeelHeight))
                query = query.Where(ph => ph.HeelHeight != null && EF.Functions.Like(ph.HeelHeight, $"%{searchParams.HeelHeight}%"));
            /*
            // LastNo 特殊處理
            if (!string.IsNullOrWhiteSpace(searchParams.LastNo))
            {
                query = query.Where(ph =>
                    (ph.LastNo1 != null && EF.Functions.Like(ph.LastNo1, $"%{searchParams.LastNo}%")) ||
                    (ph.LastNo2 != null && EF.Functions.Like(ph.LastNo2, $"%{searchParams.LastNo}%")) ||
                    (ph.LastNo3 != null && EF.Functions.Like(ph.LastNo3, $"%{searchParams.LastNo}%"))
                );

                query = query.Where(ph =>
                    (!string.IsNullOrEmpty(ph.LastNo1) && ph.LastNo1.Contains(searchParams.LastNo)) ||
                    (!string.IsNullOrEmpty(ph.LastNo2) && ph.LastNo2.Contains(searchParams.LastNo)) ||
                    (!string.IsNullOrEmpty(ph.LastNo3) && ph.LastNo3.Contains(searchParams.LastNo))
                );
            }*/

            // 預設排序
            return query.OrderBy(ph => ph.DevNo)
                        .ThenBy(ph => ph.DevColorDispName)
                        .ThenBy(ph => ph.Stage);
        }


        public static IQueryable<pdm_spec_headDto> QuerySpecHead(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            // 使用多表 Join 查詢來組合所需欄位
            return (from ph in _pcms_Pdm_TestContext.pdm_product_head
                    join pi in _pcms_Pdm_TestContext.pdm_product_item on ph.product_m_id equals pi.product_m_id
                    join sh in _pcms_Pdm_TestContext.pdm_spec_head on pi.product_d_id equals sh.product_d_id
                    join si in _pcms_Pdm_TestContext.pdm_spec_item on sh.spec_m_id equals si.spec_m_id
                    join pn in _pcms_Pdm_TestContext.pdm_namevalue on sh.stage equals pn.value_desc
                    where pn.group_key == "stage"
                    join pnse in _pcms_Pdm_TestContext.pdm_namevalue on ph.season equals pnse.value_desc
                    where pnse.group_key == "season"
                    select new pdm_spec_headDto
                    {
                        Year = ph.year,
                        Season = pnse.text, //使用前端傳入的「值」直接查詢key value的value
                        EntryMode = sh.entrymode,
                        Stage = pn.text, //使用前端傳入的「值」直接查詢key value的value
                        MoldNo = (ph.out_mold_no + "/" + ph.mid_mold_no + "/" + ph.etc_mold_no).Trim('/'),
                        OutMoldNo = ph.out_mold_no,
                        Shfactory = sh.factory,
                        Factory = (ph.factory1 + "," + ph.factory2 + "," + ph.factory3).Replace(",,", ","),
                        ItemNameEng = ph.item_name_eng,
                        ItemNameJpn = ph.item_name_jpn,
                        ItemNo = ph.item_no,
                        DevNo = ph.dev_no,
                        DevColorDispName = pi.dev_color_disp_name,
                        ColorNo = pi.color_no,
                        SpecMId = sh.spec_m_id,
                        Cbdlockmk = sh.cbdlockmk,
                        ProductMId = ph.product_m_id,
                        ProductDId = pi.product_d_id,
                        CustomerKbn = ph.customer_kbn,
                        Mode = ph.mode_name,
                        LastNo1 = ph.last_no1,
                        LastNo2 = ph.last_no2,
                        LastNo3 = ph.last_no3,
                        pdm_Spec_ItemDtos = new List<pdm_spec_itemDto>(), // 初始化空的 Spec_ItemDtos 列表
                    });
        }
        public static IQueryable<pdm_spec_itemDto> QuerySpecDetails(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var query = from si in _pcms_Pdm_TestContext.pdm_spec_item
                        join partsGroup in (
                            from si in _pcms_Pdm_TestContext.pdm_spec_item
                            where !string.IsNullOrWhiteSpace(si.parts)
                            group si.parts by si.act_no into g
                            select new { ActNo = g.Key, Parts = g.First() }
                        ) on si.act_no equals partsGroup.ActNo into pg
                        from parts in pg.DefaultIfEmpty()
                        select new pdm_spec_itemDto
                        {
                            SpecMId = si.spec_m_id,
                            ActNo = si.act_no,
                            SeqNo = si.seqno,
                            Parts = parts.Parts ?? si.parts, // 使用查詢層級處理 Parts
                            MoldNo = si.material,
                            MaterialNo = si.materialno,
                            Material = si.material,
                            SubMaterial = si.submaterial,
                            Standard = si.standard,
                            Supplier = si.supplier,
                            Colors = si.colors,
                            Memo = si.memo,
                            Hcha = si.hcha,
                            Sec = si.sec,
                            Width = si.width
                        };
            return query;
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
                        EntryMode = sh.entrymode,
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
            return (from st in _pcms_Pdm_TestContext.pdm_spec_standard
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


        public static IQueryable<CbdUpperDTO> CbdUpperResponse(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from si in _pcms_Pdm_TestContext.pdm_spec_item
                    select new CbdUpperDTO
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
                        CuttingLoss = "0.9433",
                        Pattern = "0",
                        UsAge1 = si.usage1,
                        UsAge2 = si.usage2,
                        Price = si.pricenttur,
                        PriceM = si.pricentmst,
                        Loss = si.materialloss,
                        Freight = si.freight,
                        CostUS = si.cost,
                        Memo = si.memo,
                        PartClass = si.partclass
                    });
        }


        public static IQueryable<CbdExpenseDTO> CbdExpenseResponse(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var allMoldData = _pcms_Pdm_TestContext.pdm_spec_moldcharge
                .Select(sm => new CbdExpenseDetails
                {
                    SpecMId = sm.spec_m_id,
                    Mold = sm.id,
                    Item = sm.item,
                    Price = sm.price,
                    Qty = sm.qty,
                    Amort = sm.amortization,
                    Years = sm.years,
                    Charge = sm.charge
                }).ToList();

            var moldChargeMap = allMoldData
                .GroupBy(sm => sm.SpecMId)
                .ToDictionary(a => a.Key, a => a.ToList());

            return (from sh in _pcms_Pdm_TestContext.pdm_spec_head
                    select new CbdExpenseDTO
                    {
                        SpecMId = sh.spec_m_id,
                        TargetPrice = sh.targetprice,
                        Forecast = sh.forecast,
                        Currency = sh.currency,
                        Final = sh.fobfinal,
                        Pht = sh.fobphoto,
                        Nego = sh.fobnego,
                        Nd2 = sh.fob2ndsample,
                        Sls = sh.fobsales,
                        St1 = sh.fob1stsample,
                        MaterialTotal = sh.materialcost,
                        SubTotal = sh.exsubtotal,
                        DirectLabor = sh.exdirectlabor,
                        FactoryOverHead = sh.exfactoryoverhead,
                        Profit = sh.exprofit,
                        Cutting = sh.cpcutting,
                        Stiching = sh.cpstiching,
                        OutsoleAssembly = sh.cpoutsoleassembly,
                        Lasting = sh.cplasting,
                        MoldAmortization = sh.exmoldamortization,
                        TotalABC = sh.extotal,
                        ExCommission = sh.excommission,
                        Percent = sh.extotal * sh.excommission / 100,
                        TotalABCD = sh.extotal * (1 + (sh.extotal * sh.excommission / 100)),
                        MoldRateCurrency = sh.mcmoldratecurency ?? "",
                        MoldRate = sh.mcmoldrate,
                        MoldYears = sh.mcmoldyears,
                        Cbdexpensedetails = moldChargeMap.ContainsKey(sh.spec_m_id) ? moldChargeMap[sh.spec_m_id] : new List<CbdExpenseDetails>()
                    });
        }

    }
}
