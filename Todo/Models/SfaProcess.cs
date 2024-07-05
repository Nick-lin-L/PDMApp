using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class SfaProcess
    {
        public string ProductNo { get; set; }
        public string PartNo { get; set; }
        public string ColorNo { get; set; }
        public string ColorName { get; set; }
        public string Yymm { get; set; }
        public string Aufnr { get; set; }
        public string Auart { get; set; }
        public string Sosize { get; set; }
        public string Plnbez { get; set; }
        public decimal? Gamng { get; set; }
        public decimal? TrackOutqty { get; set; }
        public decimal? StockInqty { get; set; }
        public decimal? StockOutqty { get; set; }
        public decimal? StockReturnqty { get; set; }
        public decimal? StockSt1340 { get; set; }
    }
}
