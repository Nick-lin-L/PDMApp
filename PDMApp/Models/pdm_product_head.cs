using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_product_head
    {
        public string product_m_id { get; set; }
        public string dev_no { get; set; }
        public string dev_sp_mark { get; set; }
        public string item_no { get; set; }
        public string customer_kbn { get; set; }
        public string year { get; set; }
        public string season { get; set; }
        public string item_type { get; set; }
        public string category_grp { get; set; }
        public string category_kbn { get; set; }
        public string devmode { get; set; }
        public string dev_marker_user { get; set; }
        public string dev_marker_width { get; set; }
        public string cud_no_moto { get; set; }
        public string status { get; set; }
        public string stage { get; set; }
        public string item_name_eng { get; set; }
        public string item_name_jpn { get; set; }
        public decimal? request_weight { get; set; }
        public decimal? real_weight { get; set; }
        public string sample_size { get; set; }
        public string design_tanto { get; set; }
        public string kaihatsu_tanto { get; set; }
        public string factory1 { get; set; }
        public string factory2 { get; set; }
        public string factory3 { get; set; }
        public string factory_upper { get; set; }
        public string last_no1 { get; set; }
        public string last_no2 { get; set; }
        public string last_no3 { get; set; }
        public string siyo_kigou { get; set; }
        public string nakajiki_code { get; set; }
        public string f_gel { get; set; }
        public string r_gel { get; set; }
        public string out_mold { get; set; }
        public string out_mold_no_moto { get; set; }
        public string out_mold_no { get; set; }
        public string mid_mold { get; set; }
        public string mid_mold_no_moto { get; set; }
        public string mid_mold_no { get; set; }
        public string etc_mold { get; set; }
        public string etc_mold_no_moto { get; set; }
        public string etc_mold_no { get; set; }
        public DateTime? ketteo_tuki { get; set; }
        public string syokyaku_yoteinen { get; set; }
        public DateTime? producted_tuki { get; set; }
        public DateTime? make_date { get; set; }
        public string make_user { get; set; }
        public DateTime? upd_date { get; set; }
        public string upd_user { get; set; }
        public decimal? upd_num { get; set; }
        public string dev_building_no { get; set; }
        public string dev_brand_no { get; set; }
        public string delete_mk { get; set; }
        public string leveli { get; set; }
        public string customer_kbn_name { get; set; }
        public string season_name { get; set; }
        public string item_type_name { get; set; }
        public string mode_name { get; set; }
        public string dev_marker_user_name { get; set; }
        public string dev_marker_width_name { get; set; }
        public string status_name { get; set; }
        public string stage_name { get; set; }
        public string factory1_name { get; set; }
        public string factory2_name { get; set; }
        public string factory3_name { get; set; }
        public string factory_upper_name { get; set; }
        public string sample_factory { get; set; }
        public string sample_factory_name { get; set; }
        public decimal? factory1_forecast { get; set; }
        public decimal? factory2_forecast { get; set; }
        public decimal? factory3_forecast { get; set; }
        public string dev_last_no { get; set; }
        public string kanzan_type { get; set; }
        public string sp_kanzan { get; set; }
        public string siyo_kigou_name { get; set; }
        public string nakajiki_code_name { get; set; }
        public string f_gel_name { get; set; }
        public string r_gel_name { get; set; }
        public string out_mold_name { get; set; }
        public string out_mold_no_biko { get; set; }
        public string mid_mold_name { get; set; }
        public string mid_mold_no_biko { get; set; }
        public string etc_mold_name { get; set; }
        public string etc_mold_no_biko { get; set; }
        public string shinsei_tanto { get; set; }
        public string cutting_die { get; set; }
        public string request1_comment { get; set; }
        public string request2_comment { get; set; }
        public string request3_comment { get; set; }
        public DateTime? saishu_date { get; set; }
        public string saishu_user { get; set; }
        public string saishu_comment { get; set; }
        public string request1_shinsei_comment { get; set; }
        public string request2_shinsei_comment { get; set; }
        public string request3_shinsei_comment { get; set; }
        public string smu_comment { get; set; }
        public string pb_analyze_report_flg { get; set; }
        public string karyu_kbn { get; set; }
        public string betsubai_flg { get; set; }
        public DateTime? entry_drop_date { get; set; }
        public string karyu_kbn_name { get; set; }
 
        //public ICollection<pdm_product_item> ProductItems { get; set; } // 一個 Product 可能有多個 ProductItem

    }
}
