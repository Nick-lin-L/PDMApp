using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class TplDesign
    {
        public string TemplateDesignId { get; set; }
        public string TemplateSubTypeId { get; set; }
        public string Locale { get; set; }
        public string TemplateContent { get; set; }
        public decimal? ExpireTime { get; set; }
        public string UpdateUser { get; set; }
        public decimal UpdateTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual TplSubType TemplateSubType { get; set; }
    }
}
