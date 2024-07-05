using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaObjbl1
    {
        public string MetaObjblId { get; set; }
        public string MetaMdlobjId { get; set; }
        public string MetaBlId { get; set; }
        public decimal Seq { get; set; }
        public string IsEnable { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
    }
}
