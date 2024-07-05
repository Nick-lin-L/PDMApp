using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MifSoleQcOther
    {
        public string FactNo { get; set; }
        public string Date { get; set; }
        public string Item { get; set; }
        public string Shift { get; set; }
        public string Resourcegroup { get; set; }
        public string Resource { get; set; }
        public string QcCode { get; set; }
        public string Matnr { get; set; }
        public decimal Qty { get; set; }
        public decimal? CreateName { get; set; }
        public DateTime? CreateTime { get; set; }
        public decimal? ModifyName { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
