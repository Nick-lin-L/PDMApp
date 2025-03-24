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
}
