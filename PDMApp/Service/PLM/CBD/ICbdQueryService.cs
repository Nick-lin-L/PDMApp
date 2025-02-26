using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Parameters.PLM.CBD;

namespace PDMApp.Service.PLM.CBD
{
    /// <summary>
    /// PLM CBD 查詢相關服務
    /// </summary>
    public interface ICbdQueryService : IScopedService
    {
        Task<dynamic> GetCbdDataByID(string Data_m_id);
        Task<dynamic> ExcelImport(CbdQueryParameter.CbdExcel value);
    }
}