using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class PageOpElement
    {
        public string PageEleId { get; set; }
        public string PageUriId { get; set; }
        public string PageEleIdentify { get; set; }
        public string PageEleDesc { get; set; }
        public string PageResId { get; set; }
        public decimal PageEleOp { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string ApName { get; set; }

        public virtual PageOpResource PageRes { get; set; }
        public virtual PageUri PageUri { get; set; }
    }
}
