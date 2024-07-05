using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class KanbanProdrateDaystatus
    {
        public string FactNo { get; set; }
        public string BuildNo { get; set; }
        public string ProdArea { get; set; }
        public string ProdStep { get; set; }
        public string ProdGroupno { get; set; }
        public string ProdGroupdesc { get; set; }
        public string ProdDate { get; set; }
        public decimal? TargetQty { get; set; }
        public decimal? ActualQty { get; set; }
        public decimal? CaRate { get; set; }
        public decimal? Wip { get; set; }
        public decimal? ProdOther01Rate { get; set; }
        public decimal? Prod07Rate { get; set; }
        public decimal? Prod08Rate { get; set; }
        public decimal? Prod09Rate { get; set; }
        public decimal? Prod10Rate { get; set; }
        public decimal? Prod11Rate { get; set; }
        public decimal? Prod12Rate { get; set; }
        public decimal? Prod13Rate { get; set; }
        public decimal? Prod14Rate { get; set; }
        public decimal? Prod15Rate { get; set; }
        public decimal? Prod16Rate { get; set; }
        public decimal? Prod17Rate { get; set; }
        public decimal? Prod18Rate { get; set; }
        public decimal? ProdOther02Rate { get; set; }
    }
}
