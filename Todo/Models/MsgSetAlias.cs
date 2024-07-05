using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MsgSetAlias
    {
        public MsgSetAlias()
        {
            MsgSetAliasDetails = new HashSet<MsgSetAliasDetail>();
        }

        public string MsgAliasId { get; set; }
        public string AliasName { get; set; }
        public string ApName { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual ICollection<MsgSetAliasDetail> MsgSetAliasDetails { get; set; }
    }
}
