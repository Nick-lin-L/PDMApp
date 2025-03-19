using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class plm_spec_head
    {
        public string product_d_id { get; set; }
        public string spec_m_id { get; set; }
        public string development_no { get; set; }
        public string stage_code { get; set; }
        public string stage { get; set; }
        public string colorway { get; set; }
        public string development_color { get; set; }
        public string colorcode { get; set; }
        public DateTime? create_date { get; set; }
        public string create_user { get; set; }
        public DateTime? update_date { get; set; }
        public string update_user { get; set; }
    }
}
