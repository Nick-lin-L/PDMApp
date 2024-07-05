using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MifSapSoCnf
    {
        public string Timestamp { get; set; }
        public string Vbeln { get; set; }
        public string Uepos { get; set; }
        public string ZodrType { get; set; }
        public string ReqDate1 { get; set; }
        public string ReqDate2 { get; set; }
        public string ReqDate3 { get; set; }
        public string RecId { get; set; }
        public string ArchFlag { get; set; }
        public string BuildNo { get; set; }
        public string FloorNo { get; set; }
        public string CancelMk { get; set; }
        public string CreateUser { get; set; }
        public string CreateTime { get; set; }
        public string ModifyUser { get; set; }
        public string ModifyTime { get; set; }
        public string Vdatu { get; set; }
    }
}
