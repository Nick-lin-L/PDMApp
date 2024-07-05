using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class SchedParam
    {
        public string ParamId { get; set; }
        public string SettingMId { get; set; }
        public string ParamKey { get; set; }
        public string ParamValue { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual SchedSettingM SettingM { get; set; }
    }
}
