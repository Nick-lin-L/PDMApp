using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class SchedStateD
    {
        public string SettingDId { get; set; }
        public decimal ErrorCount { get; set; }
        public decimal NextExecuteTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual SchedSettingD SettingD { get; set; }
    }
}
