using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class SchedSettingD
    {
        public SchedSettingD()
        {
            SchedLogs = new HashSet<SchedLog>();
        }

        public string SettingDId { get; set; }
        public string SettingMId { get; set; }
        public decimal StartTime { get; set; }
        public string Seconds { get; set; }
        public string Minutes { get; set; }
        public string Hours { get; set; }
        public string DayOfMonth { get; set; }
        public string DayOfWeek { get; set; }
        public string Month { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual SchedSettingM SettingM { get; set; }
        public virtual SchedStateD SchedStateD { get; set; }
        public virtual ICollection<SchedLog> SchedLogs { get; set; }
    }
}
