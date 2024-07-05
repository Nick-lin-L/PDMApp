using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MsgTarget
    {
        public MsgTarget()
        {
            MsgRecipients = new HashSet<MsgRecipient>();
            MsgSents = new HashSet<MsgSent>();
        }

        public string MsgTargetId { get; set; }
        public string MsgMessengerId { get; set; }
        public string MsgServerId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string ContentJson { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MsgMessenger MsgMessenger { get; set; }
        public virtual MsgSetServer MsgServer { get; set; }
        public virtual ICollection<MsgRecipient> MsgRecipients { get; set; }
        public virtual ICollection<MsgSent> MsgSents { get; set; }
    }
}
