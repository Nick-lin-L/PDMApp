using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class ImpMapD
    {
        public string ImpMapDId { get; set; }
        public string ImpMapMId { get; set; }
        public string MetaMdlobjObj { get; set; }
        public string MetaFieldName { get; set; }
        public string ImpTitle { get; set; }
        public decimal? ImpIdx { get; set; }
        public string ImpRuleType { get; set; }
        public string ImpRule { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual ImpMapM ImpMapM { get; set; }
    }
}
