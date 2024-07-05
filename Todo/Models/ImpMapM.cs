using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class ImpMapM
    {
        public ImpMapM()
        {
            ImpMapDs = new HashSet<ImpMapD>();
        }

        public string ImpMapMId { get; set; }
        public string AliasName { get; set; }
        public string MetaMdlNo { get; set; }
        public string ConnAlias { get; set; }
        public char HasHeader { get; set; }
        public char FailHandle { get; set; }
        public string ImpType { get; set; }
        public string Description { get; set; }
        public string ApName { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual ICollection<ImpMapD> ImpMapDs { get; set; }
    }
}
