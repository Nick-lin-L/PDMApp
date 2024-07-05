using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class LogDetail
    {
        public string LogDId { get; set; }
        public string LogMId { get; set; }
        public string ThreadName { get; set; }
        public string LoggerName { get; set; }
        public string BundleName { get; set; }
        public string BundleVersion { get; set; }
        public string LogLevel { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public decimal? LogTime { get; set; }
        public decimal? ScanTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public decimal Sort { get; set; }

        public virtual LogMaster LogM { get; set; }
    }
}
