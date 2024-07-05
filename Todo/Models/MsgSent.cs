using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MsgSent
    {
        public MsgSent()
        {
            MsgSentRecipients = new HashSet<MsgSentRecipient>();
        }

        public string MsgSentId { get; set; }
        public string MsgTargetId { get; set; }
        public string MsgMessengerId { get; set; }
        public string SentStatus { get; set; }
        public string ResponseMsgId { get; set; }
        public decimal ErrorCount { get; set; }
        public string ErrorReason { get; set; }
        public decimal? NextExecuteTime { get; set; }
        public decimal? AppointmentTime { get; set; }
        public decimal? ExecuteTime { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MsgMessenger MsgMessenger { get; set; }
        public virtual MsgTarget MsgTarget { get; set; }
        public virtual ICollection<MsgSentRecipient> MsgSentRecipients { get; set; }
    }
}
