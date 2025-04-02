using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.BasicProgram
{
    public class MenuTreeDto
    {
        public int MenuId { get; set; }
        public int? ParentId { get; set; }
        public string MenuName { get; set; }
        public string MenuPath { get; set; }
        public string ComponentPath { get; set; }
        public string Icon { get; set; }
        public int SortOrder { get; set; }
        public List<MenuTreeDto> Children { get; set; } = new List<MenuTreeDto>();
    }

    public class MenuPermissionDto
    {
        public int MenuId { get; set; }
        public int? ParentId { get; set; }
        public string MenuName { get; set; }
        public string MenuPath { get; set; }
        public string ComponentPath { get; set; }
        public string Icon { get; set; }
        public int SortOrder { get; set; }
        public PermissionFlags Permissions { get; set; }
        public List<MenuPermissionDto> Children { get; set; } = new List<MenuPermissionDto>();
    }

    public class PermissionFlags
    {
        public bool CanCreate { get; set; }
        public bool CanRead { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public bool CanExport { get; set; }
        public bool CanImport { get; set; }
    }

    public class UserMenuPermissions
    {
        public List<MenuPermissionDto> Menus { get; set; }
        public string FactoryNo { get; set; }
    }
}
