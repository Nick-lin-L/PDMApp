using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MsgSentRecipient
    {
        public string MsgSentRecipientId { get; set; }
        public string MsgSentId { get; set; }
        public string RecipientType { get; set; }
        public string RecipientAccount { get; set; }
        public string RecipientName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MsgSent MsgSent { get; set; }
    }
}
