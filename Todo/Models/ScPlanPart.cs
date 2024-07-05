using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class ScPlanPart
    {
        public string ScPartId { get; set; }
        public string ScPlanId { get; set; }
        public decimal ScPartSeq { get; set; }
        public string ScPartType { get; set; }
        public string ScPartContent { get; set; }
        public string ScPartLength { get; set; }
        public string ScPartCond { get; set; }
        public string ScMemo { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string UpdateUser { get; set; }
        public decimal UpdateTime { get; set; }

        public virtual ScPlan ScPlan { get; set; }
    }
}
