using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class VAclOpTableByGroup
    {
        public string GroupId { get; set; }
        public string GroupPageId { get; set; }
        public string PageMenuId { get; set; }
        public string DatamodelName { get; set; }
        public string TableName { get; set; }
        public string TablePermissionA { get; set; }
        public string TablePermissionM { get; set; }
        public string TablePermissionD { get; set; }
    }
}
