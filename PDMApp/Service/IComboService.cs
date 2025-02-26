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


    }
}