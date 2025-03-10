using Dtos.PGTSPEC;
using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Utils.PGTSPEC
{
    public static class PGTSPECQueryHelper
    {
        public static IQueryable<ComboDto> QueryBrand(pcms_pdm_testContext _pcms_Pdm_TestContext, DevelopmentFactoryParameter value)
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


        public static IQueryable<ComboDto> QuerySpecSource(pcms_pdm_testContext _pcms_Pdm_TestContext, DevelopmentFactoryParameter value)
        {
            var query = from n in _pcms_Pdm_TestContext.pdm_namevalue_new
                        where n.group_key == "specsource"
                        select new
                        {
                            SpecSource = n.text,
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
                Text = n.SpecSource,
                Value = n.SpecSource
            });
        }

        public static IQueryable<ComboDto> QueryStage(pcms_pdm_testContext _pcms_Pdm_TestContext, DevelopmentFactoryParameter value)
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

        public static async Task<Dictionary<string, List<DevelopmentColorNoDto>>> QueryDevelopmentColorNo(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            var query = (from pi in _pcms_Pdm_TestContext.plm_product_item
                         select new
                         {
                             ProductMId = pi.product_m_id,
                             DevelopmentColorNo = pi.development_color_no
                         }).Distinct();

            // **先執行 SQL 查詢，將結果載入記憶體**
            var rawData = await query.ToListAsync();

            // **在 C# 端執行 GroupBy**
            var groupedData = rawData
                .GroupBy(pi => pi.ProductMId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(pi => new DevelopmentColorNoDto
                    {
                        Text = pi.DevelopmentColorNo,
                        Value = pi.DevelopmentColorNo
                    }).ToList()
                );

            return groupedData;
        }


        public static IQueryable<PGTSPECHeaderDto> QuerySpecHead( pcms_pdm_testContext _pcms_Pdm_TestContext,bool latestVerOnly,PGTSPECSearchParameter value)
        {
            var baseQuery = (from ph in _pcms_Pdm_TestContext.plm_product_head
                            join pi in _pcms_Pdm_TestContext.plm_product_item on ph.product_m_id equals pi.product_m_id
                            join sh in _pcms_Pdm_TestContext.pcg_spec_head on pi.product_d_id equals sh.product_d_id
                            join si in _pcms_Pdm_TestContext.pcg_spec_item on sh.spec_m_id equals si.spec_m_id
                            join n_stage in _pcms_Pdm_TestContext.pdm_namevalue_new on sh.stage_code equals n_stage.value_desc
                            where n_stage.group_key == "stage"
                            join n_brand in _pcms_Pdm_TestContext.pdm_namevalue_new on ph.brand_no equals n_brand.value_desc
                            where n_brand.group_key == "brand"
                            select new
                            {
                                SpecMId = sh.spec_m_id, // 加入 SpecMId
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
                                UpdateUser = sh.update_user_nm
                            }).Distinct(); 

            // **WHERE 過濾條件**
            if (!string.IsNullOrWhiteSpace(value.Brand))
                baseQuery = baseQuery.Where(ph => ph.Brand == value.Brand);
            if (!string.IsNullOrWhiteSpace(value.ModelName))
                baseQuery = baseQuery.Where(ph => ph.ModelName == value.ModelName);
            if (!string.IsNullOrWhiteSpace(value.Colorway))
                baseQuery = baseQuery.Where(ph => ph.Colorway == value.Colorway);
            if (!string.IsNullOrWhiteSpace(value.DevelopmentNo))
                baseQuery = baseQuery.Where(ph => ph.DevelopmentNo == value.DevelopmentNo);
            if (!string.IsNullOrWhiteSpace(value.DevelopmentColorNo))
                baseQuery = baseQuery.Where(ph => ph.DevelopmentColorNo == value.DevelopmentColorNo);
            if (!string.IsNullOrWhiteSpace(value.Stage))
                baseQuery = baseQuery.Where(ph => ph.Stage == value.Stage);

            if (latestVerOnly)
            {
                // **先計算最大版本**
                var maxVerQuery = baseQuery
                    .GroupBy(x => new { x.DevelopmentNo, x.DevelopmentColorNo, x.Stage })
                    .Select(g => new
                    {
                        g.Key.DevelopmentNo,
                        g.Key.DevelopmentColorNo,
                        g.Key.Stage,
                        MaxVer = g.Max(x => x.Ver)
                    });

                // **篩選最新版本**
                var latestQuery = from q in baseQuery
                                  join maxVer in maxVerQuery
                                  on new { q.DevelopmentNo, q.DevelopmentColorNo, q.Stage, q.Ver }
                                  equals new { maxVer.DevelopmentNo, maxVer.DevelopmentColorNo, maxVer.Stage, Ver = maxVer.MaxVer }
                                  select q;


                return latestQuery.Select(q => new PGTSPECHeaderDto
                {
                    SpecMId = q.SpecMId,
                    Brand = q.Brand,
                    DevelopmentNo = q.DevelopmentNo,
                    DevelopmentColorNo = q.DevelopmentColorNo,
                    ColorCode = q.ColorCode,
                    Colorway = q.Colorway,
                    Stage = q.Stage,
                    ModelName = q.ModelName,
                    Ver = q.Ver,
                    CheckoutMk = q.CheckoutMk,
                    CheckoutUser = q.CheckoutUser,
                    SpecLockMk = q.SpecLockMk,
                    UpdateDate = q.UpdateDate,
                    UpdateUser = q.UpdateUser
                });
            }

            return baseQuery.Select(q => new PGTSPECHeaderDto
            {
                SpecMId = q.SpecMId,
                Brand = q.Brand,
                DevelopmentNo = q.DevelopmentNo,
                DevelopmentColorNo = q.DevelopmentColorNo,
                ColorCode = q.ColorCode,
                Colorway = q.Colorway,
                Stage = q.Stage,
                ModelName = q.ModelName,
                Ver = q.Ver,
                CheckoutMk = q.CheckoutMk,
                CheckoutUser = q.CheckoutUser,
                SpecLockMk = q.SpecLockMk,
                UpdateDate = q.UpdateDate,
                UpdateUser = q.UpdateUser
            });
        }

        public static IQueryable<SpecBasicDTO> GetSpecBasicResponse(pcms_pdm_testContext _pcms_pdm_testContext)
        {
            return (from ph in _pcms_pdm_testContext.plm_product_head
                    join pi in _pcms_pdm_testContext.plm_product_item on ph.product_m_id equals pi.product_m_id
                    join pn in _pcms_pdm_testContext.pdm_namevalue_new on ph.stage equals pn.text
                    join psh in _pcms_pdm_testContext.pcg_spec_head on pi.product_d_id equals psh.product_d_id
                    where pn.group_key == "stage"
                    select new SpecBasicDTO
                    {
                        SpecMId = psh.spec_m_id ?? "",
                        DevelopmentNo = ph.development_no ?? "",
                        ItemNo = ph.item_trading_code ?? "",            // ITEM NO
                        ModelName = ph.working_name ?? "",              // MODEL NAME
                        Factory = ph.assigned_agents ?? "",             // FACTORY
                        Season = ph.item_initial_season ?? "",          // SEASON
                        SampleSize = ph.default_size ?? "",             // SAMPLE SIZE
                        SizeRun = ph.size_run ?? "",                    // SIZE RUN
                        SizeRange = ph.size_range ?? "",                // SIZE RANGE
                        Stage = pn.text ?? "",                          // STAGE（使用 pn.text 取得描述）
                        ColorWay = pi.colorway ?? "",                   // COLOR WAY
                        ColorCode = pi.color_code ?? "",                // COLOR CODE
                        DevelopmentColorNo = pi.development_color_no ?? "",     // DEVELOPMENT COLOR NO
                        MainColor = pi.main_color ?? "",                // MAIN COLOR
                        SubColor = pi.sub_color ?? "",                  // SUB COLOR
                        ItemMode = ph.item_mode ?? "",                  // ITEM MODE
                        SubItemMode = ph.item_mode_sub_type ?? "",      // SUB ITEM MODE
                        Gender = ph.gender ?? "",                       // GENDER
                        Width = ph.width ?? "",                         // WIDTH
                        Last1 = ph.last1 ?? "",                         // LAST1
                        Last2 = ph.last2 ?? "",                         // LAST2
                        Last3 = ph.last3 ?? "",                         // LAST3
                        SizeMap = ph.sizemap ?? "",                     // SIZE MAP
                        Lasting = ph.lasting ?? "",                     // LASTING
                        HeelHeight = ph.heel_height ?? "",              // HEEL HEIGHT
                        ProductType = ph.product_line_type ?? "",       // PRODUCT TYPE
                        Category = ph.category1 ?? "",                  // CATEGORY
                        ProductionLeadTime = ph.production_lead_time ?? "" // PRODUCT LEAD TIME
                    });
        }


        public static IQueryable<SpecUpperDTO> GetSpecUpperResponse(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return from si in _pcms_Pdm_TestContext.pcg_spec_item
                   select new SpecUpperDTO
                   {
                       SpecMId = si.spec_m_id ?? "",
                       SpecDId = si.spec_d_id ?? "",
                       Sort = si.material_sort,
                       No = si.parts_no ?? "",
                       ActPartNo = si.act_part_no ?? "",
                       Type = si.material_new ?? "",
                       Parts = si.parts ?? "",
                       Detail = si.detail ?? "",
                       ProcessMk = si.process_mk ?? "",
                       MaterialNo = "", // MATERIAL NO 需要透過 MATERIAL 關聯 PDM_MATERIAL 取得
                       Material = si.material ?? "",
                       Recycle = si.recycle ?? "",
                       MaterialComment = si.mat_comment ?? "",
                       Standard = si.standard ?? "",
                       Agent = si.agent ?? "",
                       Supplier = si.supplier ?? "",
                       QuoteSupplier = si.quote_supplier ?? "",
                       Hcha = si.hcha ?? "", // HC/HA
                       Sec = si.sec ?? "",
                       Colors = si.material_color ?? "",
                       ColorComment = si.clr_comment ?? "",
                       Memo = si.memo ?? "",
                       MatGroup = si.material_group ?? ""
                   };
        }

        public static IQueryable<SpecHeadDto> GetSpecHeadResponse(pcms_pdm_testContext context)
        {
            var query = from sh in context.pcg_spec_head
                        select new SpecHeadDto
                        {
                            SpecMId = sh.spec_m_id ?? "",
                            PgtColorName = sh.pgt_color_name ?? "",
                            RefDevNo = sh.ref_dev_no ?? "",
                            MailTo = "", // TBD 欄位，先給空值
                            MailCc = "", // TBD 欄位，先給空值
                            MoldNo1 = sh.mold_no1 ?? "",
                            MoldNo2 = sh.mold_no2 ?? "",
                            MoldNo3 = sh.mold_no3 ?? "",
                            RemarksSpec = sh.remarks_spec ?? "",
                            RemarksProhibit = sh.remarks_prohibit ?? ""
                        };

            return query;
        }

        public static IQueryable<ItemSheetDTO> GetItemSheetResponse(pcms_pdm_testContext _pcms_Pdm_TestContext)
        {
            return (from ph in _pcms_Pdm_TestContext.plm_product_head
                    join pi in _pcms_Pdm_TestContext.plm_product_item on ph.product_m_id equals pi.product_m_id
                    join shf in _pcms_Pdm_TestContext.pcg_spec_head on pi.product_d_id equals shf.product_d_id
                    join sif in _pcms_Pdm_TestContext.pcg_spec_item on shf.spec_m_id equals sif.spec_m_id
                    join pn in _pcms_Pdm_TestContext.pdm_namevalue_new on ph.stage equals pn.text
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
                        ActNo = sif.act_part_no,
                        CreateTime = DateTime.Now.ToString("yyyy/MM/dd"),
                        DevNo = ph.development_no,
                        RefDevNo = shf.ref_dev_no,
                        ItemNameEng = ph.article_description,
                        ItemNo = ph.item_trading_code,
                        ColorNo = pi.color_code,
                        DevelopmentColorNo = pi.development_color_no,
                        SampleSize = ph.default_size,
                        HeelHeight = ph.heel_height,
                        ColorNameChn = shf.pgt_color_name,
                        ColorEng = pi.colorway,
                        FactoryMoldNo1 = shf.mold_no1,
                        FactoryMoldNo2 = shf.mold_no2,
                        FactoryMoldNo3 = shf.mold_no3,
                        LastNo1 = ph.last1,
                        LastNo2 = ph.last2,
                        LastNo3 = ph.last3,
                        CreateUser = shf.create_user_nm,
                        Type = sif.material_new == "*" ? "△" : sif.material_new, // 轉換邏輯
                        Parts = $"{sif.parts} {sif.detail}".Trim(), // 串接 sif.parts 和 sif.detail
                        No = sif.parts_no,
                        Material = !string.IsNullOrWhiteSpace(sif.process_mk)? $"{sif.process_mk} {(string.IsNullOrWhiteSpace(sif.material) ? sif.mat_comment : sif.material)}": (sif.material ?? sif.mat_comment), // 如果 Material 為 null，就使用 mat_comment
                        SubMaterial = sif.mat_comment,
                        Colors = !string.IsNullOrWhiteSpace(sif.clr_comment)? $"{sif.material_color} {sif.clr_comment}".Trim(): sif.material_color,
                        Standard = sif.standard,
                        Hcha = sif.hcha,
                        Sec = sif.sec,
                        Supplier = !string.IsNullOrWhiteSpace(sif.agent) && !string.IsNullOrWhiteSpace(sif.supplier)? $"{sif.agent} / {sif.supplier}": (!string.IsNullOrWhiteSpace(sif.agent) ? sif.agent : sif.supplier),
                        Seqno = sif.material_sort,
                        PartClass = sif.material_group,
                        RemarksProhibit = shf.remarks_prohibit
                    });
        }


    }
}
