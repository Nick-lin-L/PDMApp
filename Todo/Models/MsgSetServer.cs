using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MsgSetServer
    {
        public MsgSetServer()
        {
            MsgSetAliasDetails = new HashSet<MsgSetAliasDetail>();
            MsgTargets = new HashSet<MsgTarget>();
        }

        public string MsgServerId { get; set; }
        public string MsgType { get; set; }
        public string ServerName { get; set; }
        public string ServerUrl { get; set; }
        public string ServerPort { get; set; }
        public string ServerParams { get; set; }
        public string SenderName { get; set; }
        public string SenderAccount { get; set; }
        public string SenderPwd { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual ICollection<MsgSetAliasDetail> MsgSetAliasDetails { get; set; }
        public virtual ICollection<MsgTarget> MsgTargets { get; set; }
    }
}
