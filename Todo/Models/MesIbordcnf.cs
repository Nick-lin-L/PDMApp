using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MesIbordcnf
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
        public string TransId { get; set; }
        public string DataBatchKey { get; set; }
        public string FileName { get; set; }
        public string Client { get; set; }
        public string SapOutboundTime { get; set; }
        public string MesSyncId { get; set; }
        public int Dataid { get; set; }
        public string CreateTime { get; set; }
        public string CreateUser { get; set; }
        public string ProcessTime { get; set; }
        public char? ProcessMk { get; set; }
        public string ProcessErrmsg { get; set; }
        public string ProcessUser { get; set; }
    }
}
