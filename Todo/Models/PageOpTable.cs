using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class PageOpTable
    {
        public string PageTblId { get; set; }
        public string PageUriId { get; set; }
        public string PageTblUnit { get; set; }
        public string PageTblDesc { get; set; }
        public char PageTblA { get; set; }
        public char PageTblM { get; set; }
        public char PageTblD { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string ApName { get; set; }

        public virtual PageUri PageUri { get; set; }
    }
}
