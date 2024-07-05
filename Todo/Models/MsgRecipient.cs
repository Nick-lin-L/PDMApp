using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MsgRecipient
    {
        public string MsgRecipientId { get; set; }
        public string MsgTargetId { get; set; }
        public string RecipientType { get; set; }
        public string RecipientAccount { get; set; }
        public string RecipientName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MsgTarget MsgTarget { get; set; }
    }
}
