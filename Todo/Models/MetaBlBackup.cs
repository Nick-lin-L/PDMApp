using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaBlBackup
    {
        public string MetaBlId { get; set; }
        public string MetaBlClass { get; set; }
        public string MetaBlEvent { get; set; }
        public string MetaBlDesc { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string MetaBlType { get; set; }
        public string MetaBlTarget { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string TalendJobId { get; set; }
    }
}
