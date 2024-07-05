using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class KanbanDefectQtyO
    {
        public string FactNo { get; set; }
        public string BuildNo { get; set; }
        public string ProdArea { get; set; }
        public string ProdStep { get; set; }
        public string ProdGroupno { get; set; }
        public string ProdDate { get; set; }
        public string ProdGroupdec { get; set; }
        public string DefectNo { get; set; }
        public string DefectDesc { get; set; }
        public decimal? VacancyQtyG { get; set; }
        public decimal? VacancyQtyB { get; set; }
        public decimal? DefectRateG { get; set; }
    }
}
