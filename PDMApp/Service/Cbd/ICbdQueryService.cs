using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PDMApp.Dtos.BasicProgram;
using PDMApp.Parameters.Cbd;

namespace PDMApp.Service.Cbd
{
    /// <summary>
    /// CBD 查詢相關服務
    /// </summary>
    public interface ICbdQueryService : IScopedService
    {
        Task<dynamic> GetCbdDataByID(string Data_m_id);
        Task<dynamic> ExcelImport(CbdQueryParameter.CbdExcel value);
        IEnumerable<Dtos.Cbd.CbdSearchDto.ExcelData> ExcelExport(CbdSearchParameter.QueryParameter value);
        IQueryable<Dtos.Cbd.CbdSearchDto.QueryDto> CbdSearch(CbdSearchParameter.QueryParameter value);
        IQueryable<Dtos.Cbd.CbdSearchDto.DetailsDto> CbdSearchDetail(Parameters.Cbd.CbdSearchParameter.QueryDetailParameter parameter);
    }
}