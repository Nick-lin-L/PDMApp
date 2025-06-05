using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Dtos.PGTSPEC;

namespace PDMApp.Service
{
    public interface IComboService : IScopedService
    {
        public Task<IEnumerable<object>> Stage([Optional] string DevFactoryNo);
        public Task<Dictionary<string, List<DevelopmentNoDto>>> DevelopmentNo([Optional] string brand_no);
        public Task<Dictionary<string, List<DevelopmentColorNoDto>>> ColorNo();
        public Task<object> BrandNo([Optional] string fact_no);
        public Task<object> ProductLineType([Optional] string fact_no);
        public Task<object> Supplier([Optional] string fact_no);
        public Task<object> Colors([Optional] string fact_no);
        public Task<object> Material([Optional] string fact_no);
        public Task<object> Season([Optional] string fact_no);
        public Task<object> OrderStatus();
        public Task<object> FGType(string fact_no);


    }
}