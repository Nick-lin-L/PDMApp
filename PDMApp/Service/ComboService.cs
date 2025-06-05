using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Dtos.PGTSPEC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoreLinq;
using PDMApp.Models;

namespace PDMApp.Service
{
    public class ComboService : IComboService
    {
        private readonly pcms_pdm_testContext _context;
        private readonly ILogger<IComboService> _logger;

        public ComboService(pcms_pdm_testContext context, ILogger<IComboService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<object> BrandNo([Optional] string fact_no)
        {
            try
            {
                var query = from n in _context.pdm_namevalue_new
                            where n.group_key == "brand"
                            select new
                            {
                                Brand = n.text,
                                FactNo = n.fact_no,
                                ValueDesc = n.value_desc
                            };

                // 根據 FactNo 過濾
                if (!string.IsNullOrWhiteSpace(fact_no))
                {
                    query = query.Where(n => n.FactNo == fact_no);
                }

                // 排序 (根據 ValueDesc 排序)
                query = query.OrderBy(n => n.ValueDesc);
                dynamic data = await query.Select(x => new
                {
                    Text = x.Brand,
                    Value = x.Brand
                }).ToListAsync();
                // 轉換成 ComboDto
                return data;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Dictionary<string, List<DevelopmentColorNoDto>>> ColorNo()
        {

            try
            {
                var query = from pi in _context.plm_product_item
                            select new
                            {
                                ProductMId = pi.product_m_id,
                                DevelopmentColorNo = pi.development_color_no
                            };

                // **先執行 SQL 查詢，將結果載入記憶體**
                var rawData = await query.Distinct().ToListAsync();

                // **在 C# 端執行 GroupBy**
                var groupedData = rawData
                    .GroupBy(pi => pi.ProductMId)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(pi => new DevelopmentColorNoDto
                        {
                            Text = pi.DevelopmentColorNo,
                            Value = pi.DevelopmentColorNo
                        }).OrderBy(x => x.Value).ToList()
                    );

                return groupedData;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<Dictionary<string, List<DevelopmentNoDto>>> DevelopmentNo([Optional] string brand_no)
        {
            try
            {
                var query = (from ph in _context.plm_product_head
                             join n in _context.pdm_namevalue_new on ph.brand_no equals n.value_desc
                             where n.group_key == "brand"
                             select new
                             {
                                 ProductMId = ph.product_m_id,
                                 DevelopmentNo = ph.development_no,
                                 Brand = n.text
                             });
                if (!string.IsNullOrEmpty(brand_no))
                {
                    query = query.Where(n => n.Brand == brand_no);
                }
                // **先執行 SQL 查詢，將結果載入記憶體**
                var rawData = await query.Distinct().ToListAsync();

                // **在 C# 端執行 GroupBy**
                return rawData
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
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<object> ProductLineType([Optional] string fact_no)
        {
            try
            {
                var query = from ph in _context.plm_product_head
                            where (ph.factory == fact_no || string.IsNullOrWhiteSpace(fact_no)) &&
                                  !string.IsNullOrWhiteSpace(ph.product_line_type)
                            select new
                            {
                                Text = ph.product_line_type,
                                Value = ph.product_line_type,
                            };

                // **先執行 SQL 查詢，將結果載入記憶體**
                return await query.Distinct().OrderBy(x => x.Text).ToListAsync();

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<object> Material([Optional] string fact_no)
        {
            try
            {
                var query = from ci in _context.plm_cbd_item
                            where !string.IsNullOrWhiteSpace(ci.material)
                            select new
                            {
                                Text = ci.material,
                                Value = ci.material,
                            };

                // **先執行 SQL 查詢，將結果載入記憶體**
                return await query.Distinct().OrderBy(x => x.Text).ToListAsync();

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<object> Colors([Optional] string fact_no)
        {
            try
            {
                var query = from ci in _context.plm_cbd_item
                            where !string.IsNullOrWhiteSpace(ci.colors)
                            select new
                            {
                                Text = ci.colors,
                                Value = ci.colors,
                            };

                // **先執行 SQL 查詢，將結果載入記憶體**
                return await query.Distinct().OrderBy(x => x.Text).ToListAsync();

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<object> Supplier([Optional] string fact_no)
        {
            try
            {
                var query = from ci in _context.plm_cbd_item
                            where !string.IsNullOrWhiteSpace(ci.supplier)
                            select new
                            {
                                Text = ci.supplier,
                                Value = ci.supplier,
                            };


                // **先執行 SQL 查詢，將結果載入記憶體**
                return await query.Distinct().OrderBy(x => x.Text).ToListAsync();

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<object>> Stage([Optional] string DevFactoryNo)
        {
            try
            {
                var query = _context.pdm_namevalue_new.AsQueryable().Where(x => x.group_key == "stage");
                if (!string.IsNullOrEmpty(DevFactoryNo))
                {
                    query = query.Where(n => n.fact_no == DevFactoryNo);
                }
                var data = query.Select(x => new
                {
                    Text = x.text,
                    Value = x.text
                });
                return await data.OrderBy(x => x.Value).ToListAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<object> Season([Optional] string fact_no)
        {
            try
            {
                var query = from ph in _context.plm_product_head
                            join n in _context.pdm_namevalue_new
                            on new { ph.factory, ph.brand_no } equals new { factory = n.fact_no, brand_no = n.value_desc }
                            where ph.factory == fact_no && !string.IsNullOrWhiteSpace(ph.item_initial_season) && !string.IsNullOrWhiteSpace(ph.brand_no)
                            select new
                            {
                                Season = ph.item_initial_season,
                                BrandNo = n.text
                            };

                // **先執行 SQL 查詢，將結果載入記憶體**
                var rawData = await query.Distinct().ToListAsync();

                // **在 C# 端執行 GroupBy**
                return rawData
                    .GroupBy(ph => ph.BrandNo)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => new { Text = x.Season, Value = x.Season }).ToList().OrderBy(x => x.Text)
                        );
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<object> OrderStatus()
        {
            try
            {
                var query = _context.sys_namevalue.AsQueryable().Where(x => x.group_key == "wkorder_status" && x.status == "Y");
                var data = query.Select(x => new
                {
                    Text = x.text,
                    Value = x.text
                });
                return await data.OrderBy(x => x.Value).ToListAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<object> FGType(string fact_no)
        {
            try
            {
                var query = _context.pdm_namevalue_new.AsQueryable().Where(x => x.group_key == "fg_type" && x.status == "Y");
                query = query.Where(n => n.fact_no == fact_no);
                var data = query.Select(x => new
                {
                    Text = x.text,
                    Value = x.value_desc
                });
                return await data.OrderBy(x => x.Value).ToListAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
