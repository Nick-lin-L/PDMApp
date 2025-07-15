using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pl_main
    {
        public string wk_m_id { get; set; }
        public string pl_main_id { get; set; }
        public string pl_order_no { get; set; }
        public string dept { get; set; }
        public string pl_reason { get; set; }
        public string note { get; set; }
        public string trans_id { get; set; }
        public string serp_pl_no { get; set; }
        public DateTime? modify_time { get; set; }
    }
}
