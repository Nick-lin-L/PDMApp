using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaExtfield
    {
        public string MetaExtId { get; set; }
        public string MetaFieldId { get; set; }
        public string RefMetaFieldId { get; set; }
        public decimal MetaExtfieldSeq { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MetaExt MetaExt { get; set; }
        public virtual MetaField MetaField { get; set; }
        public virtual MetaField RefMetaField { get; set; }
    }
}
