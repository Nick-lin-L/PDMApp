using Dtos.PGTSPEC;
using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.PGTSPEC;
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
    }
}
