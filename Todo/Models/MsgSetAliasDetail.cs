using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MsgSetAliasDetail
    {
        public string MsgAliasId { get; set; }
        public string MsgServerId { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MsgSetAlias MsgAlias { get; set; }
        public virtual MsgSetServer MsgServer { get; set; }
    }
}
