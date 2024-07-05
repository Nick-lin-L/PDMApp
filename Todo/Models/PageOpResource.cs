﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class PageOpResource
    {
        public PageOpResource()
        {
            PageOpElements = new HashSet<PageOpElement>();
        }

        public string PageResId { get; set; }
        public string PageUriId { get; set; }
        public string PageResType { get; set; }
        public string PageResNo { get; set; }
        public string PageResMemo { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string ApName { get; set; }

        public virtual PageUri PageUri { get; set; }
        public virtual ICollection<PageOpElement> PageOpElements { get; set; }
    }
}
