using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class VersionScriptDetail
    {
        public string VersionScriptDetailId { get; set; }
        public string VersionScriptId { get; set; }
        public decimal ExecOrder { get; set; }
        public string UpgradeSql { get; set; }
        public char IsAutoGen { get; set; }
        public string CreateUser { get; set; }
        public decimal CreateTime { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual VersionScript VersionScript { get; set; }
    }
}
