using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class AclOpTable
    {
        public string AclTblId { get; set; }
        public string GroupPageId { get; set; }
        public string PageTblId { get; set; }
        public char AclTblA { get; set; }
        public char AclTblM { get; set; }
        public char AclTblD { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string ApName { get; set; }
    }
}
