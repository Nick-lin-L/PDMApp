using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class TplMaster
    {
        public TplMaster()
        {
            TplSampleData = new HashSet<TplSampleDatum>();
            TplSubTypes = new HashSet<TplSubType>();
        }

        public string TemplateId { get; set; }
        public string ApName { get; set; }
        public string TemplateAliasName { get; set; }
        public string TemplateType { get; set; }
        public string JsonSampleData { get; set; }
        public string MetaMdlId { get; set; }
        public string MasterId { get; set; }
        public string UpdateUser { get; set; }
        public decimal UpdateTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MetaMdl MetaMdl { get; set; }
        public virtual ICollection<TplSampleDatum> TplSampleData { get; set; }
        public virtual ICollection<TplSubType> TplSubTypes { get; set; }
    }
}
