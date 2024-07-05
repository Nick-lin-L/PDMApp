using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaMdlbl
    {
        public MetaMdlbl()
        {
            MetaMdlblParams = new HashSet<MetaMdlblParam>();
        }

        public string MetaMdlblId { get; set; }
        public string MetaMdlId { get; set; }
        public string MetaBlId { get; set; }
        public decimal Seq { get; set; }
        public string IsEnable { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MetaBl1 MetaBl { get; set; }
        public virtual MetaMdl MetaMdl { get; set; }
        public virtual ICollection<MetaMdlblParam> MetaMdlblParams { get; set; }
    }
}
