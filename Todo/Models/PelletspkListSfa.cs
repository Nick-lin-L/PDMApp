using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class PelletspkListSfa
    {
        public string Aufnr { get; set; }
        public string Plnbez { get; set; }
        public string Maktx { get; set; }
        public string Workno { get; set; }
        public string Workseq { get; set; }
        public string Workdate { get; set; }
        public string Prodbatch { get; set; }
        public string ProductType { get; set; }
        public string ProductNo { get; set; }
        public string PartNo { get; set; }
        public string ColorNo { get; set; }
        public string Materialname { get; set; }
        public string ColorNm { get; set; }
        public decimal? ErpSpkqty { get; set; }
        public string SoSize { get; set; }
        public string WoSize { get; set; }
        public decimal? Gamng { get; set; }
        public decimal? Trackout { get; set; }
        public decimal? StockIn { get; set; }
        public decimal? Stockout { get; set; }
        public decimal? Return { get; set; }
    }
}
