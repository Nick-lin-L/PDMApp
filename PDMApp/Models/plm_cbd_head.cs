using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class plm_cbd_head
    {
        public string data_m_id { get; set; }
        public string product_d_id { get; set; }
        public string stage { get; set; }
        public string bom { get; set; }
        public string colors { get; set; }
        public string currency { get; set; }
        public decimal? targetprice { get; set; }
        public decimal? finalprice { get; set; }
        public string forecast { get; set; }
        public string factory { get; set; }
        public decimal? materialcost { get; set; }
        public decimal? umsubtotal { get; set; }
        public decimal? smsubtotal { get; set; }
        public decimal? omsubtotal { get; set; }
        public decimal? exsubtotal { get; set; }
        public decimal? exdirectlabor { get; set; }
        public decimal? cpcutting { get; set; }
        public decimal? cpstiching { get; set; }
        public decimal? cpoutsoleassembly { get; set; }
        public decimal? cplasting { get; set; }
        public decimal? exmoldamortization { get; set; }
        public decimal? exfactoryoverhead { get; set; }
        public decimal? exprofit { get; set; }
        public decimal? totalcost { get; set; }
        public decimal? commisiion { get; set; }
        public decimal? excommisiion { get; set; }
        public decimal? extotal { get; set; }
        public string spec_remarks { get; set; }
        public string cbd_remarks { get; set; }
        public string loginuser { get; set; }
        public int? ver { get; set; }
        public int? vssver { get; set; }
        public string checkoutmk { get; set; }
        public string checkoutuser { get; set; }
        public DateTime? spec_update_date { get; set; }
        public string spec_update_user { get; set; }
        public string speclockmk { get; set; }
        public string cbdlockmk { get; set; }
        public DateTime? cbd_update_date { get; set; }
        public string cbd_update_user { get; set; }
        public DateTime? create_date { get; set; }
        public string create_user { get; set; }
        public DateTime? update_date { get; set; }
        public string update_user { get; set; }
    }
}
