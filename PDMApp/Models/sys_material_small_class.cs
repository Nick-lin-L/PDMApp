using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class sys_material_small_class
    {
        public string class_l_no { get; set; }
        public string class_m_no { get; set; }
        public string class_s_no { get; set; }
        public string class_name_en { get; set; }
        public string class_name_zh_tw { get; set; }
        public char is_activate { get; set; }
        public decimal? deactivate_date { get; set; }
        public decimal? create_time { get; set; }
        public decimal? create_user { get; set; }
        public decimal? modify_time { get; set; }
        public decimal? modify_user { get; set; }
    }
}
