using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class Workm
    {
        public string Facility { get; set; }
        public string Workno { get; set; }
        public string Workseq { get; set; }
        public string Aufnr { get; set; }
        public string Workdate { get; set; }
        public string Shift { get; set; }
        public string Plnbez { get; set; }
        public string Wosize { get; set; }
        public decimal? Gamng { get; set; }
        public decimal? CreateName { get; set; }
        public DateTime? CreateTime { get; set; }
        public decimal? ModifyName { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
