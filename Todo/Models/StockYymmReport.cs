using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class StockYymmReport
    {
        public string FactNo { get; set; }
        public string Yymm { get; set; }
        public string ProductNo { get; set; }
        public string PartNo { get; set; }
        public string PartNm { get; set; }
        public string ColorNo { get; set; }
        public string ColorB { get; set; }
        public string ColorNm { get; set; }
        public decimal? FirstStock { get; set; }
        public decimal? InStock { get; set; }
        public decimal? OutStock { get; set; }
        public decimal? TkStock { get; set; }
    }
}
