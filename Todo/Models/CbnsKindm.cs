using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class CbnsKindm
    {
        public string FactNo { get; set; }
        public string KindNo { get; set; }
        public string KindCnm { get; set; }
        public string KindEnm { get; set; }
        public string StartMk { get; set; }
        public decimal? CreateName { get; set; }
        public DateTime? CreateTime { get; set; }
        public decimal? ModifyName { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
