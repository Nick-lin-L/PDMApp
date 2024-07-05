using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class SchedSettingM
    {
        public SchedSettingM()
        {
            SchedConflictJobs = new HashSet<SchedConflictJob>();
            SchedConflictQueues = new HashSet<SchedConflictQueue>();
            SchedParams = new HashSet<SchedParam>();
            SchedSettingDs = new HashSet<SchedSettingD>();
        }

        public string SettingMId { get; set; }
        public string ApName { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public string ExecutionMode { get; set; }
        public char Retry { get; set; }
        public decimal? RetryInterval { get; set; }
        public char? DelayByErrcnt { get; set; }
        public char? Deployable { get; set; }
        public string JobGroup { get; set; }
        public char Effective { get; set; }
        public string UpdateUser { get; set; }
        public decimal UpdateTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual SchedStateM SchedStateM { get; set; }
        public virtual ICollection<SchedConflictJob> SchedConflictJobs { get; set; }
        public virtual ICollection<SchedConflictQueue> SchedConflictQueues { get; set; }
        public virtual ICollection<SchedParam> SchedParams { get; set; }
        public virtual ICollection<SchedSettingD> SchedSettingDs { get; set; }
    }
}
