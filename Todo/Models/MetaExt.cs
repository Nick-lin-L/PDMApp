using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaExt
    {
        public MetaExt()
        {
            MetaExtfields = new HashSet<MetaExtfield>();
        }

        public string MetaExtId { get; set; }
        public string MetaExtName { get; set; }
        public string MetaExtType { get; set; }
        public string MetaObjId { get; set; }
        public string RefMetaObjId { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MetaObj MetaObj { get; set; }
        public virtual MetaObj RefMetaObj { get; set; }
        public virtual ICollection<MetaExtfield> MetaExtfields { get; set; }
    }
}
