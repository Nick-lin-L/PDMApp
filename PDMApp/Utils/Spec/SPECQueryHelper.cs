using Dtos.SPEC;
using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.SPEC;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Utils.SPEC
{
    public static class SPECQueryHelper
    {
        public static IQueryable<SPECHeaderDto> QuerySpecHead(pcms_pdm_testContext _pcms_Pdm_TestContext, SPECSearchParameter value)
        {
            var baseQuery = (from ph in _pcms_Pdm_TestContext.plm_product_head
                             join pi in _pcms_Pdm_TestContext.plm_product_item on ph.product_m_id equals pi.product_m_id
                             join sh in _pcms_Pdm_TestContext.pcg_spec_head on pi.product_d_id equals sh.product_d_id
                             join si in _pcms_Pdm_TestContext.pcg_spec_item on sh.spec_m_id equals si.spec_m_id
                             join n_stage in _pcms_Pdm_TestContext.pdm_namevalue_new on sh.stage_code equals n_stage.value_desc
                             where n_stage.group_key == "stage"
                             select new
                             {
                                 EntryMode = ph.product_line_type,
                                 Season = ph.season,
                                 ItemNo = ph.item_trading_code,
                                 DevelopmentNo = ph.development_no,
                                 ColorCode = pi.color_code,
                                 DevelopmentColorNo = pi.development_color_no,
                                 Stage = n_stage.text,
                                 LastNo = ph.last1,
                                 PartName = si.parts,
                                 Material = si.material,
                                 MaterialColor = si.material_color,
                                 Supplier = si.supplier,
                                 HeelHeight = ph.heel_height,
                                 Ver = sh.ver,
                                 SpecMId = sh.spec_m_id,
                                 SampleFactory = ph.sampling_factory,
                                 Colorway = pi.colorway
                             }).Distinct();

            // **WHERE 過濾條件**
            if (!string.IsNullOrWhiteSpace(value.EntryMode))
                baseQuery = baseQuery.Where(ph => ph.EntryMode == value.EntryMode);
            if (!string.IsNullOrWhiteSpace(value.Season))
                baseQuery = baseQuery.Where(ph => ph.Season == value.Season);
            if (!string.IsNullOrWhiteSpace(value.ItemNo))
                baseQuery = baseQuery.Where(ph => ph.ItemNo == value.ItemNo);
            if (!string.IsNullOrWhiteSpace(value.DevelopmentNo))
                baseQuery = baseQuery.Where(ph => ph.DevelopmentNo == value.DevelopmentNo);
            if (!string.IsNullOrWhiteSpace(value.ColorCode))
                baseQuery = baseQuery.Where(ph => ph.ColorCode == value.ColorCode);
            if (!string.IsNullOrWhiteSpace(value.DevelopmentColorNo))
                baseQuery = baseQuery.Where(ph => ph.DevelopmentColorNo == value.DevelopmentColorNo);
            if (!string.IsNullOrWhiteSpace(value.Stage))
                baseQuery = baseQuery.Where(ph => ph.Stage == value.Stage);
            if (!string.IsNullOrWhiteSpace(value.LastNo))
                baseQuery = baseQuery.Where(ph => ph.LastNo == value.LastNo);
            if (!string.IsNullOrWhiteSpace(value.PartName))
                baseQuery = baseQuery.Where(ph => ph.PartName == value.PartName);
            if (!string.IsNullOrWhiteSpace(value.Material))
                baseQuery = baseQuery.Where(ph => ph.Material == value.Material);
            if (!string.IsNullOrWhiteSpace(value.MaterialColor))
                baseQuery = baseQuery.Where(ph => ph.MaterialColor == value.MaterialColor);
            if (!string.IsNullOrWhiteSpace(value.Supplier))
                baseQuery = baseQuery.Where(ph => ph.Supplier == value.Supplier);
            if (!string.IsNullOrWhiteSpace(value.HeelHeight))
                baseQuery = baseQuery.Where(ph => ph.HeelHeight == value.HeelHeight);
         
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

            return latestQuery.Select(q => new SPECHeaderDto
            {
                SpecMId = q.SpecMId,
                Stage = q.Stage,
                SampleFactory = q.SampleFactory,
                DevelopmentNo = q.DevelopmentNo,
                ItemNo = q.ItemNo,
                Season = q.Season,
                DevelopmentColorNo = q.DevelopmentColorNo,
                ColorCode = q.ColorCode,
                Colorway = q.Colorway,
                Last = q.LastNo
            });
        }

        public static IQueryable<SPECDetailDto> QuerySpecDetail(pcms_pdm_testContext _pcms_Pdm_TestContext, SPECDetailSearchParameter value)
        {
            var baseQuery = from si in _pcms_Pdm_TestContext.pcg_spec_item
                            where si.spec_m_id == value.SpecMId
                            orderby si.material_group, si.material_sort
                            select new SPECDetailDto
                            {
                                Sort = si.material_sort,
                                PartsNo = si.parts_no,
                                Parts = si.parts,
                                Detail = si.detail,
                                MaterialNew = si.material_new,
                                ProcessMk = si.process_mk,
                                Material = si.material,
                                MatComment = si.mat_comment,
                                Agent = si.agent,
                                Standard = si.standard,
                                Supplier = si.supplier,
                                MatColor = si.material_color,
                                ColorComment = si.clr_comment,
                                Memo = si.memo
                            };

            return baseQuery;
        }

        public static IQueryable<SPECExportDto> QuerySpecExport(pcms_pdm_testContext _pcms_Pdm_TestContext, SPECExportSearchParameter value)
        {
            var query = from ph in _pcms_Pdm_TestContext.plm_product_head
                        join pi in _pcms_Pdm_TestContext.plm_product_item on ph.product_m_id equals pi.product_m_id
                        join sh in _pcms_Pdm_TestContext.pcg_spec_head on pi.product_d_id equals sh.product_d_id
                        join si in _pcms_Pdm_TestContext.pcg_spec_item on sh.spec_m_id equals si.spec_m_id
                        join n_stage in _pcms_Pdm_TestContext.pdm_namevalue_new on sh.stage_code equals n_stage.value_desc
                        where n_stage.group_key == "stage"
                        where sh.spec_m_id == value.SpecMId
                        orderby si.material_group, si.material_sort 
                        select new SPECExportDto
                        {
                            Season = ph.season,
                            Stage = n_stage.text,
                            SampleFactory = ph.sampling_factory,
                            ItemNo = ph.item_trading_code,
                            DevelopmentNo = ph.development_no,
                            ColorCode = pi.color_code,
                            Colorway = pi.colorway,
                            Last = ph.last1,
                            ArticleDescription = ph.article_description,
                            PartsNo = si.parts_no,
                            Parts = si.parts,
                            Detail = si.detail,
                            ProcessMk = si.process_mk,
                            Material = si.material,
                            MatComment = si.mat_comment,
                            Agent = si.agent,
                            Standard = si.standard,
                            Supplier = si.supplier,
                            MaterialColor = si.material_color,
                            ColorComment = si.clr_comment,
                            Memo = si.memo,
                            HCHA = si.hcha,
                            Sec = si.sec
                        };
            
            return query;
        }


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

        public static IQueryable<ComboDto> QueryEntryMode(pcms_pdm_testContext _pcms_Pdm_TestContext, DevelopmentFactoryParameter value)
        {
            var query = from ph in _pcms_Pdm_TestContext.plm_product_head
                        select new
                        {
                            EntryMode = ph.product_line_type,
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
            query = query.Where(ph => !string.IsNullOrEmpty(ph.EntryMode));

            // 排序 (按照 EntryMode 排序)
            query = query.OrderBy(ph => ph.EntryMode);

            // 轉換成 ComboDto
            return query.Select(ph => new ComboDto
            {
                Text = ph.EntryMode,
                Value = ph.EntryMode
            });
        }

        public static IQueryable<ComboDto> QuerySeason(pcms_pdm_testContext _pcms_Pdm_TestContext, DevelopmentFactoryParameter value)
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
                .OrderBy(pi => pi.DevelopmentColorNo)
                .GroupBy(pi => pi.ProductMId)
                .ToDictionary(
                    g => g.Key,
                    g => g
                        .Where(pi => !string.IsNullOrWhiteSpace(pi.DevelopmentColorNo)) // 過濾空值
                        .Select(pi => new DevelopmentColorNoDto
                        {
                            Text = pi.DevelopmentColorNo,
                            Value = pi.DevelopmentColorNo
                        })
                        .ToList()
                );

            return groupedData;
        }

    }
}
