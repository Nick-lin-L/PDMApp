#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.Cbd
{
    public class CbdSearchDto
    {
        public class ExcelData
        {
            public string? Season { get; set; }
            public string? Stage { get; set; }
            public string? Factory { get; set; }
            public string? WorkingName { get; set; }
            public string? ItemTradingCode { get; set; }
            public string? DevelopmentNo { get; set; }
            public string? DevelopmentColorNo { get; set; }
            public string? ColorCode { get; set; }
            public string? No { get; set; }
            public string? Parts { get; set; }
            public string? Detail { get; set; }
            public string? ProcessMk { get; set; }
            public string? Material { get; set; }
            public string? MtrComment { get; set; }
            public string? Standard { get; set; }
            public string? Supplier { get; set; }
            public string? Colors { get; set; }
            public string? CbdComment { get; set; }
            public string? Memo { get; set; }
            public string? HcHa { get; set; }
            public string? Sec { get; set; }
            public string? Width { get; set; }
            public decimal? Usage { get; set; }
            public decimal? Price { get; set; }
            public decimal? Cost { get; set; }
        }

        public class QueryDto
        {
            public string? Stage { get; set; }
            public string? Season { get; set; }
            public string? DevelopmentNo { get; set; }
            public string? WorkingName { get; set; }
            public string? ColorCode { get; set; }
            public string? ColorWay { get; set; }
            public string? Last { get; set; }
            public string? DataMId { get; set; }
            public string? DevelopmentColorNo { get; set; }
        }

        public class DetailsDto
        {
            public string? PartNo { get; set; }
            public string? Parts { get; set; }
            public string? MoldNo { get; set; }
            public string? ProcessMk { get; set; }
            public string? Material { get; set; }
            public string? Recycle { get; set; }
            public string? MtrComment { get; set; }
            public string? CbdComment { get; set; }
            public string? Standard { get; set; }
            public string? Supplier { get; set; }
            public string? Colors { get; set; }
            public string? Memo { get; set; }
            public string? ClrComment { get; set; }
            public string? HcHa { get; set; }
            public string? Sec { get; set; }
            public string? Width { get; set; }
            public decimal? Usage1 { get; set; }
            public decimal? Usage2 { get; set; }
            public decimal? UnitPrice { get; set; }
            public decimal? Cost { get; set; }
            public string? DataMId { get; set; }
        }
    }
}