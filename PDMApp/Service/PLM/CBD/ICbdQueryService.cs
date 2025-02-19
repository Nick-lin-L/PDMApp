using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PDMApp.Dtos.BasicProgram;

namespace PDMApp.Service.PLM.CBD
{
    /// <summary>
    /// PLM CBD 查詢相關服務
    /// </summary>
    public interface ICbdQueryService : IScopedService
    {
        public Task<IEnumerable<object>> DropDown(string key);
        public Task<IEnumerable<object>> DropDown(string key, string parameter);
        public Task<IEnumerable<object>> Stage();
        public Task<IEnumerable<object>> Color_no();
        public Task<IEnumerable<object>> Dev_no();
        public Task<IEnumerable<object>> Stage(string parameter);
        public Task<IEnumerable<object>> Color_no(string parameter);
        public Task<IEnumerable<object>> Dev_no(string parameter);
    }
}