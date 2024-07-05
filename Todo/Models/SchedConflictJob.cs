using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class SchedConflictJob
    {
        public string ConflictJobId { get; set; }
        public string SettingMId { get; set; }
        public string Grouping { get; set; }
        public decimal Priority { get; set; }
        public string UpdateUser { get; set; }
        public decimal UpdateTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual SchedSettingM SettingM { get; set; }
    }
}
