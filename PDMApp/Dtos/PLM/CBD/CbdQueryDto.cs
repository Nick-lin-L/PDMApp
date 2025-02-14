using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PDMApp.Models;

namespace PDMApp.Dtos.PLM.CBD
{
#nullable enable
    public class CbdQueryDto
    {
        public class QueryDto
        {
#nullable enable
            public string? Data_m_id { set; get; }
            public string? Product_m_id { set; get; }
            public string? Product_d_id { set; get; }
            public string? Itemtrading_code { set; get; }
            public string? Development_no { set; get; }
            public string? Development_color_no { set; get; }
            public string? Stage { set; get; }
            public string? Stage_display { set; get; }
            public string? Working_name { set; get; }
            public string? Color_code { set; get; }
            public string? Colorway { set; get; }
            public string? Bom { set; get; }
            public string? Colors { set; get; }
            public int? Vssver { set; get; }
            public int? Ver { set; get; }
            public string? Cbd_update_user { set; get; }
            public string? Cbd_update_date { set; get; }
            public string? Update_user { set; get; }
            public string? Update_date { set; get; }

        }
        public class BasicDto
        {
            #region 左邊
            public string? Development_no { get; set; }
            public string? Assigned_Agents { get; set; }
            public string? Default_Size { get; set; }
            public string? Size_Range { get; set; }
            [JsonPropertyName("Designer_Candidate")]
            public string? Designer { get; set; }
            public string? Color_Code { get; set; }
            public string? Main_Color { get; set; }
            public string? Item_Trading_Code { get; set; }
            public string? Item_Mode { get; set; }
            public string? Article_Description { get; set; }
            [JsonPropertyName("Season_Forecast")]
            public int? Lp01_Season_Forecast { get; set; }
            public string? Width { get; set; }
            public string? Last2 { get; set; }
            public string? Sizemap { get; set; }
            public string? Heel_Height { get; set; }
            public string? Sampling_Factory { get; set; }
            public string? Sub_Factory { get; set; }
            [JsonPropertyName("Category")]
            public string? Category1 { get; set; }
            #endregion
            #region 右邊
            public string? Working_Name { get; set; }
            public string? Item_Initial_Season { get; set; }
            public string? Size_Run { get; set; }
            [JsonPropertyName("Stage")]
            public string? Stage { get; set; }
            public string? ColorWay { get; set; }
            [JsonPropertyName("Development_Color_No")]
            public string? Colors { get; set; }
            public string? Sub_Color { get; set; }
            public string? Global_Id { get; set; }
            public string? Item_Mode_Sub_Type { get; set; }
            public string? Gender { get; set; }
            [JsonPropertyName("Year_Forecast")]
            public int? Lp01_Yearly_Forecast { get; set; }
            public string? Last1 { get; set; }
            public string? Last3 { get; set; }
            public string? Lasting { get; set; }
            public string? Product_Line_Type { get; set; }
            public string? Main_Factory { get; set; }
            public string? Sub_Factory2 { get; set; }
            public string? Production_Lead_Time { get; set; }
            #endregion
        }
        public class CbdItemDto
        {
            public string? Data_d_id { get; set; }
            public string? Data_m_id { get; set; }
            public string? Data_id { get; set; }
            public int? Seqno { get; set; }
            public string? No { get; set; }
            public string? Newmaterial { get; set; }
            public string? Parts { get; set; }
            public string? Detail { get; set; }
            public string? Materialno { get; set; }
            public string? Process_mk { get; set; }
            public string? Material { get; set; }
            public string? Recycle { get; set; }
            public string? Mtrcomment { get; set; }
            public string? Cbdcomment { get; set; }
            public string? Standard { get; set; }
            public string? Supplier { get; set; }
            public string? Agent { get; set; }
            public string? Quotesupplier { get; set; }
            public string? Colors { get; set; }
            public string? Clrcomment { get; set; }
            public string? Moldno { get; set; }
            public string? Hcha { get; set; }
            public string? Sec { get; set; }
            public string? Width { get; set; }
            public decimal? Usage1 { get; set; }
            public decimal? Usage2 { get; set; }
            public decimal? Basicprice { get; set; }
            public decimal? Unitprice { get; set; }
            public decimal? Mtrloss { get; set; }
            public decimal? Freight { get; set; }
            public decimal? Cost { get; set; }
            public string? Memo { get; set; }
            public string? Change_mk { get; set; }
            public string? Partclass { get; set; }
            public string? Act_no { get; set; }
            public string? Act_parts { get; set; }
            public string? Factory_mold_no { get; set; }
            public string? Group_Mk { get; set; }
        }
        public class ExpenseDto
        {
            #region 黃色區
            public decimal? Targetprice { get; set; }
            public string? Forecast { get; set; }
            public string? Currency { get; set; }
            #endregion
            #region 紫色區--先不做
            [JsonPropertyName("Final")]
            public decimal? Fobfinal { get; set; }
            [JsonPropertyName("PHT")]
            public decimal? Fobphoto { get; set; }
            [JsonPropertyName("NEGO")]
            public decimal? Fobnego { get; set; }
            [JsonPropertyName("2Nd")]
            public decimal? Fob2ndSample { get; set; }
            [JsonPropertyName("Sls")]
            public decimal? FobSales { get; set; }
            [JsonPropertyName("St1")]
            public decimal? Fob1stSample { get; set; }
            #endregion
            #region EXPENSE
            [JsonPropertyName("MaterialTotal")]
            public decimal? MaterialCost { get; set; } //A
            [JsonPropertyName("SubTotal")]
            public decimal? ExSubTotal { get; set; } //B
            [JsonPropertyName("DirectLabor")]
            public decimal? ExDirectlabor { get; set; }
            [JsonPropertyName("FactoryOverHead")]
            public decimal? ExFactoryOverHead { get; set; }
            [JsonPropertyName("Profit")]
            public decimal? ExProfit { get; set; }
            [JsonPropertyName("Cutting")]
            public decimal? CpCutting { get; set; }
            [JsonPropertyName("Stiching")]
            public decimal? CpStiching { get; set; } //
            [JsonPropertyName("OutsoleAssembly")]
            public decimal? CpOutsoleAssembly { get; set; }

            [JsonPropertyName("Lasting")]
            public decimal? CpLasting { get; set; }

            [JsonPropertyName("Mold_Amortization")]
            public decimal? ExMoldAmortization { get; set; } //C
            [JsonPropertyName("TotalABC")]
            public decimal? Extotal { get; set; } //EXTOTAL
            [JsonPropertyName("ExCommission")]
            public decimal? Excommisiion { get; set; } //excommisiion

            public decimal? Percent
            {
                get
                {
                    return Extotal * Excommisiion / 100;
                }
            }
            public decimal? TotalABCD
            {
                get
                {
                    return Extotal * (1 + (Extotal * Excommisiion / 100));
                }
            }
            [JsonPropertyName("MoldRateCurrency")]
            public string? McMoldRateCurrency { get; set; } //MCMOLDRATECURENCY
            [JsonPropertyName("MoldRate")]
            public decimal? McMoldRate { get; set; } //MCMOLDRATE
            [JsonPropertyName("MoldYears")]
            public int? McMoldYears { get; set; } //MCMOLDYEARS
            #endregion
            [JsonPropertyName("MoldData")]
            public List<MoldDto> mold { get; set; } = new List<MoldDto>();

        }
        public class MoldDto
        {
            public string? Item { get; set; }
            public decimal? Price { get; set; }
            public int? Qty { get; set; }
            public decimal? Amortization { get; set; }
            public decimal? Years { get; set; }
            public decimal? Rate { get; set; }
            public decimal? UnitPrice { get; set; }
            public decimal? Cost { get; set; }
        }

        public class CbdSearch
        {
            public string? Parameter { get; set; }
        }

        public class CbdExcel
        {
            [Required]
            public String? DevNo { get; set; }
            [Required]
            public String? DevColorName { get; set; }
            [Required]
            public String? Stage { get; set; }
            [Required]
            public ExcelData? Data { get; set; }
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
            public List<plm_cbd_moldcharge>? MoldCharge { get; set; }
        }

        public class HeaderData
        {
            public string? Stage { get; set; }
            public string? Itemmode_Subtype { get; set; }
            public string? Currency { get; set; }
            public DateTime? Cbd_Update_Date { get; set; }
            public string? Size_Run { get; set; }
            public decimal? Targetprice { get; set; }
            public decimal? Finalprice { get; set; }
            public string? Sample_Size { get; set; }
            public string? Forecast { get; set; }
            public decimal? Subtotal { get; set; }
            public string? Lasting_Heelheight { get; set; }
            public string? Working_Name { get; set; }
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