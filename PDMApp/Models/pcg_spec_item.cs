using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pcg_spec_item
    {
        public string spec_d_id { get; set; }
        public string spec_m_id { get; set; }
        public int? material_sort { get; set; }
        public string material_group { get; set; }
        public string parts_no { get; set; }
        public string material_new { get; set; }
        public string parts { get; set; }
        public string detail { get; set; }
        public string mat_type { get; set; }
        public string process_mk { get; set; }
        public string material { get; set; }
        public string mat_comment { get; set; }
        public string standard { get; set; }
        public string agent { get; set; }
        public string supplier { get; set; }
        public string quote_supplier { get; set; }
        public string hcha { get; set; }
        public string sec { get; set; }
        public string material_color { get; set; }
        public string clr_comment { get; set; }
        public string translate_lock_mk { get; set; }
        public string part_mk { get; set; }
        public string act_part_no { get; set; }
        public string ref_bill_id { get; set; }
        public string translate_rule { get; set; }
        public DateTime? add_date { get; set; }
        public DateTime? update_date { get; set; }
        public string memo { get; set; }
        public string mtrtype { get; set; }
        public string mtrbase { get; set; }
        public string processing { get; set; }
        public string effect { get; set; }
        public string releasepaper { get; set; }
        public string basecolor { get; set; }
        public string recycle { get; set; }

        public virtual pcg_spec_head spec_m { get; set; }
    }
}
