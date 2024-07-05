using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class AclUserGroup
    {
        public string UserId { get; set; }
        public string GroupId { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }

        public virtual G2fwUser User { get; set; }
    }
}
