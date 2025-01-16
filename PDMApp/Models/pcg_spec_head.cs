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
        public string entrymode { get; set; }
        public string devno { get; set; }
        public string devcolorno { get; set; }
        public string factory { get; set; }
        public string stage { get; set; }
        public int? heelheight { get; set; }
        public string lasting { get; set; }
        public int? fobfinal { get; set; }
        public int? fobnego { get; set; }
        public int? fobsales { get; set; }
        public int? fobphoto { get; set; }
        public int? fob2ndsample { get; set; }
        public int? fob1stsample { get; set; }
        public int? umsubtotal { get; set; }
        public int? smsubtotal { get; set; }
        public int? omsubtotal { get; set; }
        public int? materialcost { get; set; }
        public int? materialrate { get; set; }
        public string materialratecurrency { get; set; }
        public string currency { get; set; }
        public int? commission { get; set; }
        public int? cpcutting { get; set; }
        public int? cpoutsoleassembly { get; set; }
        public int? cpstiching { get; set; }
        public int? cplasting { get; set; }
        public int? exdirectlabor { get; set; }
        public int? exfactoryoverhead { get; set; }
        public int? exprofit { get; set; }
        public int? exsubtotal { get; set; }
        public int? exmoldamortization { get; set; }
        public int? excommission { get; set; }
        public int? extotal { get; set; }
        public int? mcmoldrate { get; set; }
        public string mcmoldratecurency { get; set; }
        public int? mcmoldyears { get; set; }
        public int? forecast { get; set; }
        public int? targetprice { get; set; }
        public string loginuser { get; set; }
        public string cbdlockmk { get; set; }
        public string create_user { get; set; }
        public DateTime? spec_update_date { get; set; }
        public string spec_update_user { get; set; }
        public string itemname1 { get; set; }
        public string itemname2 { get; set; }
        public string itemname3 { get; set; }
        public string itemname4 { get; set; }
        public string itemname5 { get; set; }
        public string itemname6 { get; set; }
        public string itemname7 { get; set; }
        public string itemname8 { get; set; }
        public string itemname9 { get; set; }
        public string itemname10 { get; set; }
        public string spec_xml_id { get; set; }
        public string cbd_xml_id { get; set; }
        public string remarks_cbd { get; set; }
        public DateTime? cbd_update_date { get; set; }
        public string cbd_update_user { get; set; }
        public string check_out_area { get; set; }

        public virtual ICollection<pcg_spec_item> pcg_spec_item { get; set; }
    }
}
