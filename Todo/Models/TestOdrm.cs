using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class TestOdrm
    {
        public string OdrNo { get; set; }
        public string Yymm { get; set; }
        public string ArticNo { get; set; }
        public string BrandNo { get; set; }
        public string CustOdr { get; set; }
        public decimal? TotalQty { get; set; }
        public decimal? CreateName { get; set; }
        public DateTime? CreateTime { get; set; }
        public decimal? ModifyName { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
