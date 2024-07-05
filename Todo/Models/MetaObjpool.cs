using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaObjpool
    {
        public string MetaObjpoolClass { get; set; }
        public string MetaObjpoolCondition { get; set; }
        public decimal MetaObjpoolMax { get; set; }
        public decimal MetaObjpoolIdlemin { get; set; }
        public decimal MetaObjpoolChksec { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
    }
}
