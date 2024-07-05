using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class G2fwUser
    {
        public G2fwUser()
        {
            AclGroupMgrs = new HashSet<AclGroupMgr>();
            AclGroups = new HashSet<AclGroup>();
            AclUserGroups = new HashSet<AclUserGroup>();
        }

        public string UserId { get; set; }
        public decimal UserPccuid { get; set; }
        public string UserLang { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string UserDisable { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string ImAcct { get; set; }
        public string UserTimezone { get; set; }

        public virtual ICollection<AclGroupMgr> AclGroupMgrs { get; set; }
        public virtual ICollection<AclGroup> AclGroups { get; set; }
        public virtual ICollection<AclUserGroup> AclUserGroups { get; set; }
    }
}
