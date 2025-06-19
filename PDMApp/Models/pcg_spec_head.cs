using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pcg_spec_head
    {
        public pcg_spec_head()
        {
            pcg_spec_item = new HashSet<pcg_spec_item>();
        }

        public string spec_m_id { get; set; }
        public string product_d_id { get; set; }
        public string lan { get; set; }
        public string stage_code { get; set; }
        public int? ver { get; set; }
        public string checkoutmk { get; set; }
        public string checkoutuser { get; set; }
        public string speclockmk { get; set; }
        public string create_mode { get; set; }
        public string translockmk { get; set; }
        public string pgt_color_name { get; set; }
        public string ref_dev_no { get; set; }
        public string mold_no1 { get; set; }
        public string mold_no2 { get; set; }
        public string mold_no3 { get; set; }
        public string remarks_spec { get; set; }
        public string remarks_prohibit { get; set; }
        public string spec_pic_id { get; set; }
        public string ref_bill_id { get; set; }
        public DateTime? create_date { get; set; }
        public string create_user_id { get; set; }
        public string create_user_nm { get; set; }
        public DateTime? update_date { get; set; }
        public string update_user_id { get; set; }
        public string update_user_nm { get; set; }
        public string filename { get; set; }
        public int? vssver { get; set; }
        public string mail_to { get; set; }
        public string mail_cc { get; set; }

        public virtual ICollection<pcg_spec_item> pcg_spec_item { get; set; }
    }
}
