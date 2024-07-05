using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class VAclOpColumnByGroup
    {
        public string GroupId { get; set; }
        public string GroupPageId { get; set; }
        public string PageMenuId { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public decimal? ColumnPermission { get; set; }
    }
}
