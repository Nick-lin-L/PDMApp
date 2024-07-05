using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class VersionTable
    {
        public string VersionTableName { get; set; }
        public decimal VersionTableExecutionOrder { get; set; }
        public string VersionTablePkName { get; set; }
        public char IsEnabled { get; set; }
        public string CreateUser { get; set; }
        public decimal CreateTime { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public char ApAllow { get; set; }
    }
}
