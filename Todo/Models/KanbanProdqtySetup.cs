using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class KanbanProdqtySetup
    {
        public string FactNo { get; set; }
        public string FactDesc { get; set; }
        public string BuildNo { get; set; }
        public string BuildDesc { get; set; }
        public string ProdArea { get; set; }
        public string ProdAreaDesc { get; set; }
        public string ProdStep { get; set; }
        public string ProdStepDesc { get; set; }
        public string ProdGroupno { get; set; }
        public string ProdGroupdesc { get; set; }
        public string FactPcgMes { get; set; }
        public string PreProdDate { get; set; }
        public decimal? StandardQtySd { get; set; }
        public decimal? TargetQty { get; set; }
        public string Chartemp1 { get; set; }
        public string Chartemp2 { get; set; }
        public string Chartemp3 { get; set; }
        public string Chartemp4 { get; set; }
        public string Chartemp5 { get; set; }
        public decimal? Numtemp1 { get; set; }
        public decimal? Numtemp2 { get; set; }
        public decimal? Numtemp3 { get; set; }
        public decimal? Numtemp4 { get; set; }
        public decimal? Numtemp5 { get; set; }
    }
}
