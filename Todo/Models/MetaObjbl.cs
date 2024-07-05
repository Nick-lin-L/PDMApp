using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaObjbl
    {
        public MetaObjbl()
        {
            MetaObjblParams = new HashSet<MetaObjblParam>();
        }

        public string MetaObjblId { get; set; }
        public string MetaMdlobjId { get; set; }
        public string MetaBlId { get; set; }
        public decimal Seq { get; set; }
        public string IsEnable { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MetaBl1 MetaBl { get; set; }
        public virtual MetaMdlobj MetaMdlobj { get; set; }
        public virtual ICollection<MetaObjblParam> MetaObjblParams { get; set; }
    }
}
