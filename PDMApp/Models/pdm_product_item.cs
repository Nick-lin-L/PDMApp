using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_product_item
    {
        public string product_d_id { get; set; }
        public string product_m_id { get; set; }
        public decimal? iroseqno { get; set; }
        public string dev_color_no { get; set; }
        public string dev_color_disp_name { get; set; }
        public string color_name_eng { get; set; }
        public string color_name_jpn { get; set; }
        public string upper_sozai_code { get; set; }
        public string sole_sozai_code { get; set; }
        public string hqn_no { get; set; }
        public string tsurifuda_code { get; set; }
        public decimal? offer_fob { get; set; }
        public string size_run { get; set; }
        public string drop_flg { get; set; }
        public string color_no { get; set; }
        public string upper_sozai_code_name { get; set; }
        public string sole_sozai_code_name { get; set; }
        public string hqn_no_name { get; set; }
        public string tsurifuda_code_name { get; set; }
        public string conf_request { get; set; }
        public string conf_request_flg { get; set; }
        public DateTime? conf_date { get; set; }
        public string conf_sample_no { get; set; }
        public string conf_model_no { get; set; }
        public string conf_color_no { get; set; }
        public string conf_size { get; set; }
        public string conf_last { get; set; }
        public string conf_mold { get; set; }
        public string conf_remarks { get; set; }
        public string conf_sample_flg { get; set; }
        public string col_revise_flg { get; set; }
        public string request1_uketsuke { get; set; }
        public string request2_uketsuke { get; set; }
        public string request3_uketsuke { get; set; }
        public string hs_code { get; set; }
        public string hs_code_name { get; set; }

        // 外鍵與導航屬性
        //public pdm_product_head ProductHead { get; set; }
        //public ICollection<pdm_spec_head> SpecHeads { get; set; }

    }
}
