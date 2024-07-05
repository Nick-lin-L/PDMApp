using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MifSysSlistcol
    {
        public string ColCode { get; set; }
        public string ColValue { get; set; }
        public string ColCname { get; set; }
        public string ColEname { get; set; }
        public decimal? ValueOrder { get; set; }
        public string ExtraData { get; set; }
        public string CreateNm { get; set; }
        public string ModifyNm { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string ExCol1 { get; set; }
        public string ExCol2 { get; set; }
        public string FlgUser { get; set; }
        public string Oldvalue { get; set; }
    }
}
