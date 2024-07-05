using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class VersionImportLog
    {
        public string ApName { get; set; }
        public decimal? VersionId { get; set; }
        public string VersionName { get; set; }
        public decimal? VersionScriptTime { get; set; }
        public decimal? VersionScriptExecOrder { get; set; }
        public string VersionScriptType { get; set; }
        public string VersionScriptDesc { get; set; }
        public string Type { get; set; }
        public decimal? ExecuteTime { get; set; }
        public string ExecuteIpAddress { get; set; }
        public string ExecuteOsUser { get; set; }
        public string ExecuteSessionUser { get; set; }
        public string Memo { get; set; }
    }
}
