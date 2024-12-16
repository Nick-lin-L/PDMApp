using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class plm_product_item
    {
        public string product_d_id { get; set; }
        public string product_m_id { get; set; }
        public string active { get; set; }
        public string attributes_active { get; set; }
        public string jump_to_merch_plan { get; set; }
        public string design_candidate { get; set; }
        public string colorway { get; set; }
        public string development_color_no { get; set; }
        public string color_code { get; set; }
        public string attributes_color_mode { get; set; }
        public string attributes_color_mode_sub_type { get; set; }
        public DateTime? modified { get; set; }
        public string modified_by { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        public string key_color { get; set; }
        public string main_color { get; set; }
        public string sub_color { get; set; }
        public string drop_reason { get; set; }
        public string moq_per_color { get; set; }
        public DateTime? add_date { get; set; }
        public DateTime? update_date { get; set; }
    }
}
