using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class work_order_partmat
    {
        public string wk_pm_id { get; set; }
        public string wk_m_id { get; set; }
        public string part_no { get; set; }
        public string parts { get; set; }
        public string mat_no { get; set; }
        public string material { get; set; }
        public decimal usage { get; set; }
        public decimal qty { get; set; }
        public char del_mk { get; set; }
    }
}
