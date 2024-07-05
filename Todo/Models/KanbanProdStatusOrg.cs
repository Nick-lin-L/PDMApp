using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class KanbanProdStatusOrg
    {
        public string FactNo { get; set; }
        public string BuildNo { get; set; }
        public string ProdArea { get; set; }
        public string ProdStep { get; set; }
        public string ProdDate { get; set; }
        public decimal? ExpQty { get; set; }
        public decimal? CaQty { get; set; }
        public decimal? CaTodayQty { get; set; }
        public decimal? VacancyQty { get; set; }
    }
}
