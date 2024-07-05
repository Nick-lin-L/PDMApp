using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class Ibpart
    {
        public string BrandId { get; set; }
        public string Component { get; set; }
        public string NameZf { get; set; }
        public string NameEn { get; set; }
        public char? Deactive { get; set; }
        public string Timestamp { get; set; }
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
