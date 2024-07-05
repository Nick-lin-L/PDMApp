using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MsgAttachment
    {
        public string MsgAttachmentId { get; set; }
        public string MsgMessengerId { get; set; }
        public string AttachName { get; set; }
        public byte[] AttachContent { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MsgMessenger MsgMessenger { get; set; }
    }
}
