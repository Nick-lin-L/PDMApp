using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class work_order_item
    {
        public string wk_m_id { get; set; }
        public string shoe_kind { get; set; }
        public string size_no { get; set; }
        public decimal qty { get; set; }
        public decimal? modify_user { get; set; }
        public DateTime? modify_date { get; set; }
        public string wk_d_id { get; set; }
        public string sort { get; set; }
        public char del_mk { get; set; }
        public string trans_mk { get; set; }
    }
}
