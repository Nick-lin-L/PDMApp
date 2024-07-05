using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class VersionScript
    {
        public VersionScript()
        {
            VersionScriptDetails = new HashSet<VersionScriptDetail>();
        }

        public string VersionScriptId { get; set; }
        public decimal VersionId { get; set; }
        public decimal VersionScriptExecOrder { get; set; }
        public string VersionScriptType { get; set; }
        public char IsAutoGen { get; set; }
        public string VersionScriptDesc { get; set; }
        public string CreateUser { get; set; }
        public decimal CreateTime { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual Version Version { get; set; }
        public virtual ICollection<VersionScriptDetail> VersionScriptDetails { get; set; }
    }
}
