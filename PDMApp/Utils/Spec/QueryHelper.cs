﻿using Microsoft.EntityFrameworkCore;
using PDMApp.Dtos;
using PDMApp.Dtos.Basic;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Dtos.SPEC;
using PDMApp.Models;
using PDMApp.Parameters.ALink;
using PDMApp.Parameters.Basic;
using PDMApp.Parameters.SPEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Utils
{
    public static class QueryHelper
    {
        public static IQueryable<pdm_spec_headDto> QuerySpecHead2(pcms_pdm_testContext _pcms_Pdm_TestContext, SpecSearchParameter searchParams)
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
                            Factory1 = ph.factory1,
                            Factory2 = ph.factory2,
                            Factory3 = ph.factory3,
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
                            HeelHeight = sh.heelheight.ToString(),
                            //以下為SpecItem的欄位
                            Material = si.material,
                            SubMaterial = si.submaterial,
                            Supplier = si.supplier,
                            Width = si.width,
                            PartNo = si.act_no,
                            PartName = si.parts,
                            MatColor = si.colors
                        };

            // 精確匹配條件
            if (!string.IsNullOrWhiteSpace(searchParams.SpecMId))
                query = query.Where(ph => ph.SpecMId == searchParams.SpecMId);
            if (!string.IsNullOrWhiteSpace(searchParams.Factory))
            {
                string inputFactory = searchParams.Factory.Trim();
                query = query.Where(ph =>
                    ph.Factory1 == inputFactory ||
                    ph.Factory2 == inputFactory ||
                    ph.Factory3 == inputFactory
                );
            }
            if (!string.IsNullOrWhiteSpace(searchParams.EntryMode))
                query = query.Where(ph => ph.EntryMode == searchParams.EntryMode);
            if (!string.IsNullOrWhiteSpace(searchParams.Season))
                query = query.Where(ph => ph.Season == searchParams.Season);
            if (!string.IsNullOrWhiteSpace(searchParams.Year))
            {
                var years = searchParams.Year.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(y => y.Trim())
                                           .ToArray();
                query = query.Where(ph => years.Contains(ph.Year));
            }
            if (!string.IsNullOrWhiteSpace(searchParams.Stage))
                query = query.Where(ph => ph.Stage == searchParams.Stage);
            if (!string.IsNullOrWhiteSpace(searchParams.CustomerKbn))
                query = query.Where(ph => ph.CustomerKbn == searchParams.CustomerKbn);
            if (!string.IsNullOrWhiteSpace(searchParams.ModeName))
                query = query.Where(ph => ph.Mode == searchParams.ModeName);

            // 模糊匹配條件
            if (!string.IsNullOrWhiteSpace(searchParams.ItemNo))
                query = query.Where(ph => EF.Functions.Like(ph.ItemNo ?? "", $"%{searchParams.ItemNo}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.ColorNo))
                query = query.Where(ph => EF.Functions.Like(ph.ColorNo ?? "", $"%{searchParams.ColorNo}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.DevNo))
                query = query.Where(ph => EF.Functions.Like(ph.DevNo ?? "", $"%{searchParams.DevNo}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.Devcolorno))
                query = query.Where(ph => EF.Functions.Like(ph.DevColorDispName ?? "", $"%{searchParams.Devcolorno}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.OutMoldNo))
                query = query.Where(ph => EF.Functions.Like(ph.OutMoldNo ?? "", $"%{searchParams.OutMoldNo}%"));

            // LastNo 特殊處理
            if (!string.IsNullOrWhiteSpace(searchParams.LastNo))
            {
                query = query.Where(ph =>
                    EF.Functions.Like(ph.LastNo1 ?? "", $"%{searchParams.LastNo}%") ||
                    EF.Functions.Like(ph.LastNo2 ?? "", $"%{searchParams.LastNo}%") ||
                    EF.Functions.Like(ph.LastNo3 ?? "", $"%{searchParams.LastNo}%")
                );
            }

            if (!string.IsNullOrWhiteSpace(searchParams.ItemNameENG))
                query = query.Where(ph => EF.Functions.Like(ph.ItemNameEng ?? "", $"%{searchParams.ItemNameENG}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.ItemNameJPN))
                query = query.Where(ph => EF.Functions.Like(ph.ItemNameJpn ?? "", $"%{searchParams.ItemNameJPN}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.HeelHeight))
                query = query.Where(ph => EF.Functions.Like(ph.HeelHeight ?? "", $"%{searchParams.HeelHeight}%"));

            //if (!string.IsNullOrWhiteSpace(searchParams.PartNo))
            //    query = query.Where(ph => EF.Functions.Like(ph.PartNo ?? "", $"%{searchParams.PartNo}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.PartName))
                query = query.Where(ph => EF.Functions.Like(ph.PartName ?? "", $"%{searchParams.PartName}%"));

            // 加入子檔條件判斷
            if (!string.IsNullOrWhiteSpace(searchParams.PartNo))
                query = query.Where(ph => EF.Functions.Like(ph.PartNo ?? "", $"%{searchParams.PartNo}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.PartName))
                query = query.Where(ph => EF.Functions.Like(ph.PartName ?? "", $"%{searchParams.PartName}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.MatColor))
                query = query.Where(ph => EF.Functions.Like(ph.MatColor ?? "", $"%{searchParams.MatColor}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.Material))
                query = query.Where(ph => EF.Functions.Like(ph.Material ?? "", $"%{searchParams.Material}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.SubMaterial))
                query = query.Where(ph => EF.Functions.Like(ph.SubMaterial ?? "", $"%{searchParams.SubMaterial}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.Supplier))
                query = query.Where(ph => EF.Functions.Like(ph.Supplier ?? "", $"%{searchParams.Supplier}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.Width))
                query = query.Where(ph => EF.Functions.Like(ph.Width ?? "", $"%{searchParams.Width}%"));

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
                        /*
                        PartName = si.parts,
                        PartNo = si.act_no,
                        MatColor = si.colors,
                        Material = si.material,
                        SubMaterial = si.submaterial,
                        Supplier = si.supplier,
                        Width = si.width,
                        */
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
                        HeelHeight = sh.heelheight.ToString(),
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

        public static IQueryable<ShoeShapeDto> QueryShoeShapeHead(pcms_pdm_testContext _pcms_Pdm_TestContext, ShoeShapeParameter searchParams)
        {
            // 基礎查詢
            var query = from ph in _pcms_Pdm_TestContext.plm_product_head
                        join pi in _pcms_Pdm_TestContext.plm_product_item on ph.product_m_id equals pi.product_m_id
                        join pn in _pcms_Pdm_TestContext.pdm_namevalue on ph.stage equals pn.text
                        where pn.group_key == "stage"
                        select new ShoeShapeDto
                        {
                            ProductMId = ph.product_m_id,
                            DevelopmentNo = ph.development_no,
                            //DevelopmentColorNo = pi.development_color_no,
                            ItemNo = ph.item_trading_code,
                            Season = ph.season,
                            Stage = pn.text,
                            WorkingName = ph.working_name,
                            Factory = ph.assigned_agents,
                            Gender = ph.gender,
                            SampleSize = ph.default_size,
                            Width = ph.width,
                            Last1 = ph.last1,
                            Last2 = ph.last2,
                            Last3 = ph.last3,
                            SizeRange = ph.size_range,
                            SizeRun = ph.size_run,
                            LastUpdate = ph.update_date,
                            //Colorway = pi.colorway
                        };

            // 精確匹配條件
            if (!string.IsNullOrWhiteSpace(searchParams.ProductMId))
                query = query.Where(ph => ph.ProductMId == searchParams.ProductMId);

            // 模糊匹配條件
            if (!string.IsNullOrWhiteSpace(searchParams.Season))
                query = query.Where(ph => EF.Functions.Like(ph.Season ?? "", $"%{searchParams.Season}%"));

            if (!string.IsNullOrWhiteSpace(searchParams.WorkingName))
                query = query.Where(ph => EF.Functions.Like(ph.WorkingName ?? "", $"%{searchParams.WorkingName}%"));

            if (!string.IsNullOrWhiteSpace(searchParams.DevelopmentNo))
                query = query.Where(ph => EF.Functions.Like(ph.DevelopmentNo ?? "", $"%{searchParams.DevelopmentNo}%"));

            // 處理 LastUpdate 條件
            var today = DateTime.Today;
            if (searchParams.LastUpdate.HasValue)
            {
                // 如果有輸入 LastUpdate，使用輸入的值
                var lastUpdateDate = DateTime.Today.AddDays(-searchParams.LastUpdate.Value);
                query = query.Where(ph => ph.LastUpdate >= lastUpdateDate && ph.LastUpdate < today.AddDays(1));
            }
            else
            {
                // 如果沒有輸入 LastUpdate，預設查詢當天的資料
                query = query.Where(ph => ph.LastUpdate >= today && ph.LastUpdate < today.AddDays(1));
            }

            // 預設排序
            return query.OrderBy(ph => ph.DevelopmentNo);
        }

        public static IQueryable<ShoeShapeDetailsDto> QueryShoeShapeDetails(pcms_pdm_testContext _pcms_Pdm_TestContext, ShoeShapeDetailParameter searchParams)
        {
            // 基礎查詢
            var query = from ph in _pcms_Pdm_TestContext.plm_product_head
                        join pi in _pcms_Pdm_TestContext.plm_product_item on ph.product_m_id equals pi.product_m_id
                        join pn in _pcms_Pdm_TestContext.pdm_namevalue on ph.stage equals pn.text
                        where pn.group_key == "stage"
                        select new ShoeShapeDetailsDto
                        {
                            ProductMId = ph.product_m_id,
                            Active = pi.active,
                            DevelopmentColorNo = pi.development_color_no,
                            ColorCode = pi.color_code,
                            Colorway = pi.colorway,
                            MainColor = pi.main_color,
                            SubColor = pi.sub_color
                        };
            // 精確匹配條件
            if (!string.IsNullOrWhiteSpace(searchParams.ProductMId))
                query = query.Where(ph => ph.ProductMId == searchParams.ProductMId);

            // 加入子檔條件判斷
            if (!string.IsNullOrWhiteSpace(searchParams.Colorway))
                query = query.Where(pi => EF.Functions.Like(pi.Colorway ?? "", $"%{searchParams.Colorway}%"));

            // 預設排序
            return query.OrderBy(pi => pi.DevelopmentColorNo);
        }

        /// <summary>
        /// ShoeShape Initial，一次查詢所有資料後回傳
        /// </summary>
        /// <param name="_pcms_Pdm_TestContext"></param>
        /// <returns>廠別下拉、權限表、特殊權限表</returns>
        public static async Task<Dictionary<string, object>> QueryInitial(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            // 廠別下拉
            var factoryQuery = from Pf in _pcms_Pdm_TestContext.pdm_factory
                               select new pdm_DropDownDto
                               {
                                   Id = Pf.factory_id,
                                   Value = Pf.dev_factory_no,
                                   Text = Pf.dev_factory_no
                               };
            // 查詢權限清單
            var permissionsQuery = from Pp in _pcms_Pdm_TestContext.pdm_permissions
                                   select new pdm_permissionsInitDto
                                   {
                                       PermissionId = Pp.permission_id,
                                       PermissionName = Pp.permission_name,
                                       Description = Pp.description,
                                       FrontEndId = Pp.frontend_id,
                                       IsActive = Pp.is_active ?? "Y",
                                       // 預設權限設定為 "Y"
                                       Createp = "Y",
                                       Readp = "Y",
                                       Updatep = "Y",
                                       Deletep = "Y",
                                       Exportp = "Y",
                                       Importp = "Y",
                                       Permission1 = "Y",
                                       Permission2 = "Y",
                                       Permission3 = "Y",
                                       Permission4 = "Y"
                                   };

            var permissions = await permissionsQuery
                .OrderBy(p => p.PermissionId)
                .ToListAsync();

            // 查詢權限清單details
            var detailsQuery = from Pp in _pcms_Pdm_TestContext.pdm_permissions
                               join Ppk in _pcms_Pdm_TestContext.pdm_permission_keys
                                   on Pp.permission_id equals Ppk.permission_id
                               select new pdm_role_permission_detailsInitDto
                               {
                                   PermissionId = Pp.permission_id,
                                   PermissionName = Pp.permission_name,
                                   Description = Pp.description,
                                   PermissionKey = Ppk.permission_key,
                                   PermissionKeyId = Ppk.permission_key_id,
                                   DescriptionD = Ppk.description,
                                   IsActiveD = "Y"  // 預設為未啟用
                               };

            var permissionDetails = await detailsQuery
                .OrderBy(d => d.PermissionId)
                .ToListAsync();

            // 將查詢結果包裝成 Dictionary
            return new Dictionary<string, object>
            {
                { "Factory", factoryQuery },
                { "Permissions", permissions },
                { "PermissionDetails", permissionDetails }
            };
        }
        
        public static async Task<Dictionary<string, object>> QueryCustomerInit(pcms_pdm_testContext _pcms_Pdm_TestContext, CustomerInitialParameter value)
        {
            // Brand下拉
            var rawQuery = await (from n in _pcms_Pdm_TestContext.pdm_namevalue_new
                                  where n.group_key == "brand"
                                  select new
                                  {
                                      ValueDesc = n.value_desc,
                                      Text = n.text
                                  }).ToListAsync();

            var BrandQuery = rawQuery.Select(n => new pdm_DropDownDto
            {
                Id = int.TryParse(n.ValueDesc, out var parsedId) ? parsedId : 0,
                Value = n.Text,
                Text = n.Text
            }).ToList();

            // Development No
            var permissionsQuery = from Pp in _pcms_Pdm_TestContext.pdm_permissions
                                   select new pdm_permissionsInitDto
                                   {
                                       PermissionId = Pp.permission_id,
                                       PermissionName = Pp.permission_name,
                                       Description = Pp.description,
                                       FrontEndId = Pp.frontend_id,
                                       IsActive = Pp.is_active ?? "Y",
                                       // 預設權限設定為 "Y"
                                       Createp = "Y",
                                       Readp = "Y",
                                       Updatep = "Y",
                                       Deletep = "Y",
                                       Exportp = "Y",
                                       Importp = "Y",
                                       Permission1 = "Y",
                                       Permission2 = "Y",
                                       Permission3 = "Y",
                                       Permission4 = "Y"
                                   };

            var permissions = await permissionsQuery
                .OrderBy(p => p.PermissionId)
                .ToListAsync();

            // 查詢權限清單details
            var detailsQuery = from Pp in _pcms_Pdm_TestContext.pdm_permissions
                               join Ppk in _pcms_Pdm_TestContext.pdm_permission_keys
                                   on Pp.permission_id equals Ppk.permission_id
                               select new pdm_role_permission_detailsInitDto
                               {
                                   PermissionId = Pp.permission_id,
                                   PermissionName = Pp.permission_name,
                                   Description = Pp.description,
                                   PermissionKey = Ppk.permission_key,
                                   PermissionKeyId = Ppk.permission_key_id,
                                   DescriptionD = Ppk.description,
                                   IsActiveD = "Y"  // 預設為未啟用
                               };

            var permissionDetails = await detailsQuery
                .OrderBy(d => d.PermissionId)
                .ToListAsync();

            // 將查詢結果包裝成 Dictionary
            return new Dictionary<string, object>
            {
                { "Brand", BrandQuery },
                { "Permissions", permissions },
                { "PermissionDetails", permissionDetails }
            };
        }
        

        /// <summary>
        /// 查詢客戶下拉
        /// </summary>
        /// <param name="_pcms_Pdm_TestContext"></param>
        /// <returns></returns>
        public static IQueryable<ComboDto> QueryBrand(pcms_pdm_testContext _pcms_Pdm_TestContext, CustomerInitialParameter value)
        {
            var query = from n in _pcms_Pdm_TestContext.pdm_namevalue_new
                        where n.group_key == "brand"
                        select new
                        {
                            Brand = n.text,
                            FactNo = n.fact_no,
                            ValueDesc = n.value_desc 
                        };

            // 根據 FactNo 過濾
            if (!string.IsNullOrWhiteSpace(value.DevFactoryNo))
            {
                query = query.Where(n => n.FactNo == value.DevFactoryNo);
            }

            // 排序 (根據 ValueDesc 排序)
            query = query.OrderBy(n => n.ValueDesc);

            // 轉換成 ComboDto
            return query.Select(n => new ComboDto
            {
                Text = n.Brand,
                Value = n.Brand
            });
        }

        public static IQueryable<ComboDto> QueryStage(pcms_pdm_testContext _pcms_Pdm_TestContext, CustomerInitialParameter value)
        {
            var query = from n in _pcms_Pdm_TestContext.pdm_namevalue_new
                        where n.group_key == "stage"
                        select new
                        {
                            Stage = n.text,
                            FactNo = n.fact_no,
                            ValueDesc = n.value_desc
                        };

            if (!string.IsNullOrWhiteSpace(value.DevFactoryNo))
            {
                query = query.Where(n => n.FactNo == value.DevFactoryNo);
            }

            query = query.OrderBy(n => n.ValueDesc);

            // 轉換成 ComboDto
            return query.Select(n => new ComboDto
            {
                Text = n.Stage,
                Value = n.Stage
            });
        }


        public static async Task<Dictionary<string, List<DevelopmentNoDto>>> QueryDevelopmentNo(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var query = (from ph in _pcms_Pdm_TestContext.plm_product_head
                         join n in _pcms_Pdm_TestContext.pdm_namevalue_new on ph.brand_no equals n.value_desc
                         where n.group_key == "brand"
                         select new
                         {
                             ProductMId = ph.product_m_id,
                             DevelopmentNo = ph.development_no,
                             Brand = n.text
                         }).Distinct();

            // **先執行 SQL 查詢，將結果載入記憶體**
            var rawData = await query.ToListAsync();

            // **在 C# 端執行 GroupBy**
            var groupedData = rawData
                .GroupBy(ph => ph.Brand)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(ph => new DevelopmentNoDto
                    {
                        ProductMId = ph.ProductMId,
                        Text = ph.DevelopmentNo,
                        Value = ph.DevelopmentNo
                    }).ToList()
                );

            return groupedData;
        }

        public static async Task<Dictionary<string, List<DevelopmentNoDto>>> QueryDevelopmentColorNo(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var query = (from pi in _pcms_Pdm_TestContext.plm_product_item
                         select new
                         {
                             ProductMId = pi.product_m_id,
                             DevelopmentColorNo = pi.development_color_no
                         }).Distinct();

            // **先執行 SQL 查詢，將結果載入記憶體**
            var rawData = await query.ToListAsync();

            // **在 C# 端執行 GroupBy 並過濾空值**
            var groupedData = rawData
                .OrderBy(pi => pi.DevelopmentColorNo)
                .GroupBy(pi => pi.ProductMId)
                .ToDictionary(
                    g => g.Key,
                    g => g
                        .Where(pi => !string.IsNullOrWhiteSpace(pi.DevelopmentColorNo)) // 過濾空值
                        .Select(pi => new DevelopmentNoDto
                        {
                            Text = pi.DevelopmentColorNo,
                            Value = pi.DevelopmentColorNo
                        })
                        .ToList()
                );

            return groupedData;
        }

        public static IQueryable<ComboDto> QuerySeason(pcms_pdm_testContext _pcms_Pdm_TestContext, CustomerInitialParameter value)
        {
            var query = from ph in _pcms_Pdm_TestContext.plm_product_head
                        select new
                        {
                            Season = ph.season,
                            FactNo = ph.factory
                        };

            // 根據 FactNo 過濾
            if (!string.IsNullOrWhiteSpace(value.DevFactoryNo))
            {
                query = query.Where(ph => ph.FactNo == value.DevFactoryNo);
            }

            // 去除重複值
            query = query.Distinct();

            // 排除空值
            query = query.Where(ph => !string.IsNullOrEmpty(ph.Season));

            // 排序 (按照 Season 排序)
            query = query.OrderBy(ph => ph.Season);

            // 轉換成 ComboDto
            return query.Select(ph => new ComboDto
            {
                Text = ph.Season,
                Value = ph.Season
            });
        }


        public static IQueryable<CustomerSearchDto> QueryCustomer(pcms_pdm_testContext _pcms_Pdm_TestContext, CustomerSpecsSearchParameter searchParams)
        {
            // 基礎查詢
            var query = from ph in _pcms_Pdm_TestContext.plm_product_head
                        join pi in _pcms_Pdm_TestContext.plm_product_item on ph.product_m_id equals pi.product_m_id
                        join sh in _pcms_Pdm_TestContext.plm_spec_head on ph.development_no equals sh.development_no
                        join pn in _pcms_Pdm_TestContext.pdm_namevalue_new on ph.stage_code equals pn.value_desc
                        where pn.group_key == "stage" && (string.IsNullOrEmpty(searchParams.LoginFactory) || pn.fact_no == searchParams.LoginFactory)
                        select new CustomerSearchDto
                        {
                            Season = ph.season,
                            WorkingName = ph.working_name,
                            DevelopmentNo = ph.development_no,
                            DevelopmentColor = sh.development_color,
                            Stage = pn.text,
                            ColorCode = sh.colorcode,
                            Colorway = sh.colorway,
                            CreateDate = sh.create_date,
                            CreateUser = sh.create_user,
                            UpdateDate = sh.update_date,
                            UpdateUser = sh.update_user,
                            LastUpdate = sh.update_date ?? sh.create_date,
                            LoginFactory = pn.fact_no
                        };

            // 精確匹配條件
            //if (!string.IsNullOrWhiteSpace(searchParams.ProductMId))
            //    query = query.Where(ph => ph.ProductMId == searchParams.ProductMId);

            // 模糊匹配條件
            if (!string.IsNullOrWhiteSpace(searchParams.Season))
                query = query.Where(ph => EF.Functions.Like(ph.Season ?? "", $"%{searchParams.Season}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.WorkingName))
                query = query.Where(ph => EF.Functions.Like(ph.WorkingName ?? "", $"%{searchParams.WorkingName}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.DevelopmentNo))
                query = query.Where(ph => EF.Functions.Like(ph.DevelopmentNo ?? "", $"%{searchParams.DevelopmentNo}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.Colorway))
                query = query.Where(ph => EF.Functions.Like(ph.Colorway ?? "", $"%{searchParams.Colorway}%"));
            if (!string.IsNullOrWhiteSpace(searchParams.Stage))
                query = query.Where(ph => EF.Functions.Like(ph.Stage ?? "", $"%{searchParams.Stage}%"));

            // 處理 LastUpdate 條件
            var today = DateTime.Today;
            var days = !string.IsNullOrWhiteSpace(searchParams.LastUpdate) &&
                       int.TryParse(searchParams.LastUpdate, out int parsedDays)
                       ? parsedDays
                       : 30;
            var lastUpdateDate = today.AddDays(-days);
            query = query.Where(ph =>
                (ph.UpdateDate >= lastUpdateDate && ph.UpdateDate < today.AddDays(1)) ||
                (ph.UpdateDate == null && ph.CreateDate >= lastUpdateDate && ph.CreateDate < today.AddDays(1))
            );

            // 預設排序
            return query.Distinct().OrderBy(ph => ph.DevelopmentNo);

        }
    }
}
