using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class SchedLog
    {
        public string LogId { get; set; }
        public string SettingMId { get; set; }
        public string SettingDId { get; set; }
        public string LogType { get; set; }
        public decimal ExecuteTime { get; set; }
        public char Success { get; set; }
        public string Message { get; set; }
        public string Remark { get; set; }
        public decimal? CompleteTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual SchedSettingD SettingD { get; set; }
    }
}
