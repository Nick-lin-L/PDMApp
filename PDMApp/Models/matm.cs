using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class matm
    {
        public string mat_id { get; set; }
        public string fact_no { get; set; }
        public string serp_mat_no { get; set; }
        public string mat_no { get; set; }
        public string cust_no { get; set; }
        public string mat_nm { get; set; }
        public string mat_full_nm { get; set; }
        public string color_no { get; set; }
        public string color_nm { get; set; }
        public string scm_bclass_no { get; set; }
        public string scm_mclass_no { get; set; }
        public string scm_sclass_no { get; set; }
        public string matnr { get; set; }
        public string uom { get; set; }
        public string standard { get; set; }
        public string mtart { get; set; }
        public string attyp { get; set; }
        public string memo { get; set; }
        public char? locked { get; set; }
        public string order_stauts { get; set; }
        public string status { get; set; }
        public string stop_date { get; set; }
        public string trans_id { get; set; }
        public string trans_msg { get; set; }
        public char? trans_pro_mk { get; set; }
        public string sync_time { get; set; }
        public DateTime? create_tm { get; set; }
        public DateTime? modify_tm { get; set; }
        public string modify_user { get; set; }
    }
}
