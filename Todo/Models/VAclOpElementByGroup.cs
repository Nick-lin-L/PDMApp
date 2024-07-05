using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class VAclOpElementByGroup
    {
        public string GroupId { get; set; }
        public string GroupPageId { get; set; }
        public string PageMenuId { get; set; }
        public string PageEleIdentify { get; set; }
        public decimal? ElementLimit { get; set; }
        public string ElementResourceUri { get; set; }
    }
}
