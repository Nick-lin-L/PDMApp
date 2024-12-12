using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.Cbd
{
    public class MultiCdb5SheetsDto
    {
        public IEnumerable<SpecBasicDTO> BasicData { get; set; }
        public IEnumerable<CbdUpperDTO> UpperData { get; set; }
        public IEnumerable<CbdUpperDTO> SoleData { get; set; }
        public IEnumerable<CbdUpperDTO> OtherData { get; set; }
        public IEnumerable<CbdExpenseDTO> ExpenseData { get; set; }
    }

    public class CbdUpperDTO
    {
        public string SpecDId { get; set; }
        public string SpecMId { get; set; }
        public string No { get; set; }
        public string Type { get; set; }      //Newmaterial
        public string Parts { get; set; }
        public string MoldNo { get; set; }
        public string FactoryMoldNo { get; set; }
        public string MaterialNo { get; set; }
        public string Material { get; set; }
        public string SubMaterial { get; set; }
        public string Standard { get; set; }
        public string Supplier { get; set; }
        public string Hcha { get; set; }
        public string Sec { get; set; }
        public string Colors { get; set; }
        public string DataId { get; set; }
        public int? SeqNo { get; set; } //seq
        public string ActNo { get; set; }
        public string Width { get; set; }

        public string CuttingLoss { get; set; }
        public string Pattern { get; set; }
        public decimal? UsAge1 { get; set; } //除
        public decimal? UsAge2 { get; set; } //乘
        public decimal? Price { get; set; }
        public decimal? PriceM { get; set; }
        public decimal? Loss { get; set; } //percent
        public decimal? Freight { get; set; } //percent
        public decimal? CostUS { get; set; }

        public string Memo { get; set; }
        public string PartClass { get; set; }
    }

    public class CbdExpenseDTO
    {
        public string? SpecMId { get; set; }
        public string TargetPrice { get; set; }
        public string Forecast { get; set; }
        public string Currency{ get; set; }

        public string Final { get; set; }
        public string Pht { get; set; }
        public string Nego { get; set; }
        public string ND2 { get; set; }
        public string Sls { get; set; }
        public string ST1 { get; set; }

        public string MaterialTotal { get; set; } //A
        public string SubTotal { get; set; } //B
        public string DirectLabor { get; set; }
        public string FactoryOverHead { get; set; }
        public string Profit { get; set; }
        public string Cutting { get; set; }
        public string Stiching { get; set; }
        public string OutsoleAssembly { get; set; }
        public string Lasting { get; set; }
        public string MoldAmortization { get; set; } //C
        public string TotalABC { get; set; }
        public string ExCommission { get; set; } //D
        public string Percent { get; set; }
        public string TotalABCD { get; set; }

        public string MoldRateCurrency { get; set; }
        public string MoldRate { get; set; }
        public string MoldYears { get; set; }

        public string Mold { get; set; }
        public string Item { get; set; }
        public string Price { get; set; }
        public string Qty { get; set; }
        public string Amort { get; set; }
        public string Years { get; set; }
        public string Charge { get; set; }
    }
}
