using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MifSysAuthority
    {
        public string CodeNo { get; set; }
        public decimal UserId { get; set; }
        public string FactNo { get; set; }
        public DateTime? CreateTime { get; set; }
        public decimal? CreateName { get; set; }
        public DateTime? ModifyTime { get; set; }
        public decimal? ModifyName { get; set; }
    }
}
