using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class PageOpColumn
    {
        public string PageColId { get; set; }
        public string PageUriId { get; set; }
        public string PageColUnit { get; set; }
        public string PageColCol { get; set; }
        public string PageColDesc { get; set; }
        public decimal PageColOp { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string ApName { get; set; }

        public virtual PageUri PageUri { get; set; }
    }
}
