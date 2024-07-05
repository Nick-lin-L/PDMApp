using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class TplSubType
    {
        public TplSubType()
        {
            TplDesigns = new HashSet<TplDesign>();
        }

        public string TemplateSubTypeId { get; set; }
        public string TemplateId { get; set; }
        public string TemplateSubType { get; set; }
        public char UseTemplate { get; set; }
        public string ClassName { get; set; }
        public string TplPath { get; set; }
        public string UpdateUser { get; set; }
        public decimal UpdateTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual TplMaster Template { get; set; }
        public virtual ICollection<TplDesign> TplDesigns { get; set; }
    }
}
