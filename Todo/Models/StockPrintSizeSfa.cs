using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class StockPrintSizeSfa
    {
        public string ProductNo { get; set; }
        public string ProductXh { get; set; }
        public string PartNo { get; set; }
        public string ColorNo { get; set; }
        public string SizeNo { get; set; }
        public decimal? LastStock { get; set; }
        public string Yymm { get; set; }
        public string WorkType { get; set; }
    }
}
