using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class CbnsKindd
    {
        public string FactNo { get; set; }
        public string KindNo { get; set; }
        public string KindType { get; set; }
        public string KindTypeDesc { get; set; }
        public string DefaMk { get; set; }
        public string KindCode { get; set; }
        public decimal? CreateName { get; set; }
        public DateTime? CreateTime { get; set; }
        public decimal? ModifyName { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
