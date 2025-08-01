using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PDMApp.Models;

namespace PDMApp.Service.ProductionOrder
{
    public interface IArtnoPoService : IScopedService
    {
        public Task<IQueryable<Dtos.ProductionOrder.ArtPoDto.QueryDto>> Search(Parameters.ProductionOrder.ArtPoParameter.QueryParameter parameter);
        public Task<List<Dtos.ProductionOrder.ArtPoDto.QueryDetailDto>> SearchDetail(Parameters.ProductionOrder.ArtPoParameter.QueryDetailParameter parameter);
        public Task<Dtos.ProductionOrder.ArtPoDto.QueryDto> CreateMainData(Parameters.ProductionOrder.ArtPoParameter.MainDataParameter parameter);
        public Task<Dtos.ProductionOrder.ArtPoDto.QueryDto> UpdateMainData(Parameters.ProductionOrder.ArtPoParameter.MainDataParameter parameter);
        public Task<List<Dtos.ProductionOrder.ArtPoDto.QueryDetailDto>> CreateDetailData(Parameters.ProductionOrder.ArtPoParameter.DetailDataParameter parameter);
        public Task<List<Dtos.ProductionOrder.ArtPoDto.QueryDetailDto>> UpdateDetailData(Parameters.ProductionOrder.ArtPoParameter.DetailDataParameter parameter);
        public Task<List<Dtos.ProductionOrder.ArtPoDto.QueryDetailDto>> DeleteDetailData(Parameters.ProductionOrder.ArtPoParameter.DetailDataParameter parameter);
        public Task<List<Dtos.ProductionOrder.ArtPoDto.QueryDto>> ProcessPo(List<Parameters.ProductionOrder.ArtPoParameter.ProcessParameter> parameter);
        public Task<object> SubmitToSerp(List<Parameters.ProductionOrder.ArtPoParameter.SubmitParameter> parameters);
        public Task<List<Dtos.ProductionOrder.ArtPoDto.ExcelDto>> ExportData(List<Parameters.ProductionOrder.ArtPoParameter.SubmitParameter> parameters);
        public Task<object> GetSeason(string DevFactoryNo);
        public Task<object> GetShoeKind(string DevFactoryNo);
        public Task<IEnumerable<pdm_namevalue_new>> GetNameValueByKey(string fact_no, string key);
        public Task<Dtos.ProductionOrder.ArtPoDto.QueryDto> GetDataById(string DevFactoryNo, string wk_m_id);
        public Task<Dtos.ProductionOrder.ArtPoDto.QueryDto> GetDisplayDataById(string DevFactoryNo, string wk_m_id);
        public Task<List<Dtos.ProductionOrder.ArtPoDto.QueryPickerDto>> QueryPicker(Parameters.ProductionOrder.ArtPoParameter.QueryPickerParameter parameter);
        public Task<List<Dtos.ProductionOrder.ArtPoDto.QueryDetailDto>> GetDetailById(string Id);
        public Task<List<Dtos.ProductionOrder.ArtPoDto.QueryDetailDto>> GetDisplayDetailById(string Id);
    }
}