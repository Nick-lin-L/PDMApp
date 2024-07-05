using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class SchedConflictQueue
    {
        public string ConflictQueueId { get; set; }
        public string SettingMId { get; set; }
        public string Grouping { get; set; }
        public string Status { get; set; }
        public decimal InsertTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual SchedSettingM SettingM { get; set; }
    }
}
