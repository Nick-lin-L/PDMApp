using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class PageUri
    {
        public PageUri()
        {
            PageMenus = new HashSet<PageMenu>();
            PageOpColumns = new HashSet<PageOpColumn>();
            PageOpElements = new HashSet<PageOpElement>();
            PageOpResources = new HashSet<PageOpResource>();
            PageOpTables = new HashSet<PageOpTable>();
        }

        public string PageUriId { get; set; }
        public string PageUriMdl { get; set; }
        public string PageUri1 { get; set; }
        public string PageUriNm { get; set; }
        public string PageUriMemo { get; set; }
        public char PageUriStat { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string PageUriTyp { get; set; }
        public string PageTarget { get; set; }

        public virtual ICollection<PageMenu> PageMenus { get; set; }
        public virtual ICollection<PageOpColumn> PageOpColumns { get; set; }
        public virtual ICollection<PageOpElement> PageOpElements { get; set; }
        public virtual ICollection<PageOpResource> PageOpResources { get; set; }
        public virtual ICollection<PageOpTable> PageOpTables { get; set; }
    }
}
