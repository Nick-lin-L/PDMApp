using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class ScCodeLast
    {
        public string ScCodeLastId { get; set; }
        public string ScPlanId { get; set; }
        public string ScCodeRef { get; set; }
        public decimal ScCodeSeq { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string UpdateUser { get; set; }
        public decimal UpdateTime { get; set; }

        public virtual ScPlan ScPlan { get; set; }
    }
}
