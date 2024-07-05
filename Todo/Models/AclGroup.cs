using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class AclGroup
    {
        public string GroupId { get; set; }
        public string GroupPid { get; set; }
        public string GroupNo { get; set; }
        public string GroupNm { get; set; }
        public string GroupNtyp { get; set; }
        public char GroupEnd { get; set; }
        public decimal GroupLvl { get; set; }
        public char GroupStat { get; set; }
        public string GroupNoa { get; set; }
        public string GroupIda { get; set; }
        public string GroupNma { get; set; }
        public string GroupMemo { get; set; }
        public string GroupOwner { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string GroupTyp { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string ConnAlias { get; set; }
        public string CreateUser { get; set; }

        public virtual G2fwUser CreateUserNavigation { get; set; }
    }
}
