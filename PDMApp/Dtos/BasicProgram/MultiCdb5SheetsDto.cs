using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.BasicProgram
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
#nullable enable
        public string? SpecMId { get; set; }
        public decimal? TargetPrice { get; set; }
        public int? Forecast { get; set; }
        public string? Currency { get; set; }

        public decimal? Final { get; set; }
        public decimal? Pht { get; set; }
        public decimal? Nego { get; set; }
        public decimal? Nd2 { get; set; }
        public decimal? Sls { get; set; }
        public decimal? St1 { get; set; }

        public decimal? MaterialTotal { get; set; } //A
        public decimal? SubTotal { get; set; } //B
        public decimal? DirectLabor { get; set; }
        public decimal? FactoryOverHead { get; set; }
        public decimal? Profit { get; set; }
        public decimal? Cutting { get; set; }
        public decimal? Stiching { get; set; }
        public decimal? OutsoleAssembly { get; set; }
        public decimal? Lasting { get; set; }
        public decimal? MoldAmortization { get; set; } //C
        public decimal? TotalABC { get; set; }
        public decimal? ExCommission { get; set; } //D
        public decimal? Percent { get; set; }
        public decimal? TotalABCD { get; set; }

        public string? MoldRateCurrency { get; set; }
        public decimal? MoldRate { get; set; }
        public int? MoldYears { get; set; }

        public ICollection<CbdExpenseDetails>? Cbdexpensedetails { get; set; }
    }

    public class CbdExpenseDetails
    {
        public string? SpecMId { get; set; }
        public string? Mold { get; set; }
        public string? Item { get; set; }
        public decimal? Price { get; set; }
        public int? Qty { get; set; }
        public decimal? Amort { get; set; }
        public int? Years { get; set; }
        public decimal? Charge { get; set; }
    }
}
