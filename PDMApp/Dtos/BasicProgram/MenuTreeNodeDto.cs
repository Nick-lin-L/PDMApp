using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.BasicProgram
{
    public class MenuTreeNodeDto
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuPath { get; set; }
        public string ComponentPath { get; set; }
        public string MenuIcon { get; set; }
        public string MenuType { get; set; }
        public string PermissionKey { get; set; }
        public int? SortOrder { get; set; }
        public int? ParentId { get; set; }
        public int? MFrontendId { get; set; }
        public List<MenuTreeNodeDto> Children { get; set; } = new(); // 遞迴用
    }
}
