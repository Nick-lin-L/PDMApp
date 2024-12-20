using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_users
    {
        public pdm_users()
        {
            pdm_group = new HashSet<pdm_group>();
            pdm_group_mgr = new HashSet<pdm_group_mgr>();
            pdm_user_group = new HashSet<pdm_user_group>();
        }

        public string user_id { get; set; }
        public decimal user_pccuid { get; set; }
        public string user_lang { get; set; }
        public string update_user { get; set; }
        public decimal? update_time { get; set; }
        public string user_disable { get; set; }
        public char is_allow_deploy { get; set; }
        public char is_pass_deploy { get; set; }
        public char is_allow_modify { get; set; }
        public string im_acct { get; set; }
        public string user_timezone { get; set; }
        public decimal? last_logintime { get; set; }
        public int? tenant_id { get; set; }

        public virtual ICollection<pdm_group> pdm_group { get; set; }
        public virtual ICollection<pdm_group_mgr> pdm_group_mgr { get; set; }
        public virtual ICollection<pdm_user_group> pdm_user_group { get; set; }
    }
}
