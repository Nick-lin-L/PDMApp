using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class sys_menu
    {
        public string menu_id { get; set; }
        public string menu_no { get; set; }
        public string menu_name { get; set; }
        public string menu_pid { get; set; }
        public string menu_sort { get; set; }
        public string is_parents { get; set; }
    }
}
