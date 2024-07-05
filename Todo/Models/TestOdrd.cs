using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class TestOdrd
    {
        public string OdrNo { get; set; }
        public string SizeNo { get; set; }
        public decimal? Qty { get; set; }
        public decimal? CreateName { get; set; }
        public DateTime? CreateTime { get; set; }
        public decimal? ModifyName { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
