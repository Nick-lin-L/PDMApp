using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class ScPlan
    {
        public ScPlan()
        {
            ScCodeLasts = new HashSet<ScCodeLast>();
            ScCodeRecyclings = new HashSet<ScCodeRecycling>();
            ScPlanParts = new HashSet<ScPlanPart>();
            ScSettings = new HashSet<ScSetting>();
        }

        public string ScPlanId { get; set; }
        public string ScPlanNo { get; set; }
        public string ScPlanNm { get; set; }
        public char IsRc { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string UpdateUser { get; set; }
        public decimal UpdateTime { get; set; }

        public virtual ICollection<ScCodeLast> ScCodeLasts { get; set; }
        public virtual ICollection<ScCodeRecycling> ScCodeRecyclings { get; set; }
        public virtual ICollection<ScPlanPart> ScPlanParts { get; set; }
        public virtual ICollection<ScSetting> ScSettings { get; set; }
    }
}
