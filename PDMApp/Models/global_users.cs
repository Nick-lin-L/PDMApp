using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class global_users
    {
        public decimal pccuid { get; set; }
        public string sso_acct { get; set; }
        public string fact_no { get; set; }
        public string local_fact_no { get; set; }
        public string chinese_nm { get; set; }
        public string local_pnl_nm { get; set; }
        public string english_nm { get; set; }
        public string contact_mail { get; set; }
        public string sex { get; set; }
        public string lo_posi_nm { get; set; }
        public string disabled { get; set; }
        public DateTime? disabled_date { get; set; }
        public DateTime update_date { get; set; }
        public string lo_dept_nm { get; set; }
        public string tel { get; set; }
        public string leave_mk { get; set; }
        public decimal? id { get; set; }
    }
}
