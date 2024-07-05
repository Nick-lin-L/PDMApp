using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaObj
    {
        public MetaObj()
        {
            MetaExtMetaObjs = new HashSet<MetaExt>();
            MetaExtRefMetaObjs = new HashSet<MetaExt>();
            MetaFields = new HashSet<MetaField>();
        }

        public string MetaObjId { get; set; }
        public string MetaObjName { get; set; }
        public string MetaObjTab { get; set; }
        public string MetaObjComment { get; set; }
        public string MetaObjLevel { get; set; }
        public string MetaObjType { get; set; }
        public string MetaObjAudit { get; set; }
        public decimal? UpdateTime { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual ICollection<MetaExt> MetaExtMetaObjs { get; set; }
        public virtual ICollection<MetaExt> MetaExtRefMetaObjs { get; set; }
        public virtual ICollection<MetaField> MetaFields { get; set; }
    }
}
