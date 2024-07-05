using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MsgMessenger
    {
        public MsgMessenger()
        {
            MsgAttachments = new HashSet<MsgAttachment>();
            MsgSents = new HashSet<MsgSent>();
            MsgTargets = new HashSet<MsgTarget>();
        }

        public string MsgMessengerId { get; set; }
        public string TemplateAliasName { get; set; }
        public string Locale { get; set; }
        public string Charset { get; set; }
        public string Priority { get; set; }
        public string ParentId { get; set; }
        public decimal? CreateTime { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual ICollection<MsgAttachment> MsgAttachments { get; set; }
        public virtual ICollection<MsgSent> MsgSents { get; set; }
        public virtual ICollection<MsgTarget> MsgTargets { get; set; }
    }
}
