#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PDMApp.Models;
using PDMApp.Utils.Converters;

namespace PDMApp.Parameters.Cbd
{
    //[ModelBinder(BinderType = typeof(FlexibleDtoModelBinder))]
    public class CbdQueryParameter
    {
        public class QueryData
        {
            [Required] public string? DataMId { get; set; }
        }
        public class CbdQuery
        {
            [JsonPropertyName("DevelopmentNo")] public string? development_no { set; get; }
            [JsonPropertyName("DevelopmentColorNo")] public string? development_color_no { set; get; }
            [JsonPropertyName("WorkingName")] public string? working_name { set; get; }
            [JsonPropertyName("Stage")] public string? stage { set; get; }
            [JsonPropertyName("Colorway")] public string? colorway { set; get; }
            [JsonPropertyName("ItemTradingCode")] public string? itemtrading_code { set; get; }
            [JsonPropertyName("ColorCode")] public string? color_code { set; get; }
            [JsonPropertyName("BrandNo")] public string? BrandNo { set; get; }
            public PaginationParameter Pagination { get; set; } = new PaginationParameter();
        }

        public class CbdExcel
        {
            [Required] public string? DevFactoryNo { get; set; }
            [Required] public string? DevelopmentNo { get; set; }
            [Required] public string? DevelopmentColorNo { get; set; }
            [Required] public string? Stage { get; set; }
            [Required] public ExcelData? Data { get; set; }
        }

        public class ExcelData
        {
            [Required]
            public HeaderData? Header { get; set; }
            [Required]
            public List<cbd_item>? Upper { get; set; }
            [Required]
            public List<cbd_item>? Sole { get; set; }
            [Required]
            public List<cbd_item>? Other { get; set; }
            [Required]
            public List<moldcharge>? MoldCharge { get; set; }
        }

        public class HeaderData
        {
            //DecimalToStringForSerializationJsonConverter
            public string? Stage { get; set; }
            [JsonPropertyName("ItemModeSubType")] public string? Itemmode_Subtype { get; set; }
            public string? Currency { get; set; }
            [JsonPropertyName("CbdUpdateDate")] public DateTime? Cbd_Update_Date { get; set; }
            [JsonPropertyName("SizeRun")] public string? Size_Run { get; set; }
            [JsonPropertyName("TargetPrice")] public decimal? Targetprice { get; set; }
            [JsonPropertyName("FinalPrice")] public decimal? Finalprice { get; set; }
            [JsonPropertyName("SampleSize")] public string? Sample_Size { get; set; }
            public string? Forecast { get; set; }
            public decimal? Subtotal { get; set; }
            [JsonPropertyName("LastingHeelheight")] public string? Lasting_Heelheight { get; set; }
            [JsonPropertyName("WorkingName")] public string? Working_Name { get; set; }
            public decimal? Exsubtotal { get; set; }
            public decimal? Totalcost { get; set; }
            public string? Bom { get; set; }
            public decimal? Exmoldamortization { get; set; }
            public decimal? Commisiion { get; set; }
            public string? Colors { get; set; }
            public decimal? Exdirectlabor { get; set; }
            public decimal? Excommisiion { get; set; }
            public string? Factory { get; set; }
            public decimal? Exfactoryoverhead { get; set; }
            public decimal? Extotal { get; set; }
            public decimal? Materialcost { get; set; }
            public decimal? Exprofit { get; set; }
            public decimal? Cpcutting { get; set; }
            public decimal? Cpstiching { get; set; }
            public decimal? Cpoutsoleassembly { get; set; }
            public decimal? Cplasting { get; set; }
            public decimal? Umsubtotal { get; set; }
            public decimal? Smsubtotal { get; set; }
            public decimal? Omsubtotal { get; set; }
            public string? Cbd_remarks { get; set; }
        }

        public class cbd_item
        {
            public string? No { get; set; }
            public string? Parts { get; set; }
            public string? Detail { get; set; }
            public string? Material { get; set; }
            public string? Recycle { get; set; }
            public string? Process_mk { get; set; }
            public string? Mtrcomment { get; set; }
            public string? Cbdcomment { get; set; }
            public string? Hcha { get; set; }
            public string? Sec { get; set; }
            public string? Colors { get; set; }
            public string? Clrcomment { get; set; }
            public string? Supplier { get; set; }
            public string? Agent { get; set; }
            public string? Quotesupplier { get; set; }
            public string? Standard { get; set; }
            public string? Width { get; set; }
            public decimal? Usage1 { get; set; }
            public decimal? Usage2 { get; set; }
            public decimal? Basicprice { get; set; }
            public decimal? Unitprice { get; set; }
            public decimal? Mtrloss { get; set; }
            public decimal? Freight { get; set; }
            public decimal? Cost { get; set; }
        }

        public class moldcharge
        {
            public string? Item { get; set; }
            public decimal? Price { get; set; }
            public decimal? Amortization { get; set; }
            public int? Qty { get; set; }
            public decimal? Years { get; set; }
            public decimal? Rate { get; set; }
            public decimal? Unitprice { get; set; }
            public decimal? Cost { get; set; }
        }

    }


}