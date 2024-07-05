using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class PcagKanbanShoeFact
    {
        public string FactNo { get; set; }
        public string FactNameZh { get; set; }
        public string FactNameEng { get; set; }
        public string Pph { get; set; }
        public string Rft { get; set; }
        public DateTime CrateDate { get; set; }
        public string ModifyDate { get; set; }
    }
}
