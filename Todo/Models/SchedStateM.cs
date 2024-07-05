using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class SchedStateM
    {
        public string SettingMId { get; set; }
        public char Scaned { get; set; }
        public char Pause { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual SchedSettingM SettingM { get; set; }
    }
}
