using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Dtos.PGTSPEC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
                        }).ToList()
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