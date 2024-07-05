using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class AclGroupPage
    {
        public string GroupPageId { get; set; }
        public string GroupId { get; set; }
        public string PageMenuId { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string ApName { get; set; }
    }
}
