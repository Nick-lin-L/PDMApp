using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_group
    {
        public string group_id { get; set; }
        public string group_pid { get; set; }
        public string group_no { get; set; }
        public string group_nm { get; set; }
        public string group_ntyp { get; set; }
        public char group_end { get; set; }
        public decimal group_lvl { get; set; }
        public char group_stat { get; set; }
        public string group_noa { get; set; }
        public string group_ida { get; set; }
        public string group_nma { get; set; }
        public string group_memo { get; set; }
        public string group_owner { get; set; }
        public string update_user { get; set; }
        public decimal? update_time { get; set; }
        public string group_typ { get; set; }
        public string ap_name { get; set; }
        public char is_allow_deploy { get; set; }
        public char is_pass_deploy { get; set; }
        public char is_allow_modify { get; set; }
        public string conn_alias { get; set; }
        public string create_user { get; set; }

        public virtual pdm_users create_userNavigation { get; set; }
    }
}
