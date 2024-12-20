using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_user_group
    {
        public string user_id { get; set; }
        public string group_id { get; set; }
        public char is_allow_deploy { get; set; }
        public char is_pass_deploy { get; set; }
        public char is_allow_modify { get; set; }
        public string update_user { get; set; }
        public decimal? update_time { get; set; }
        public int? tenant_id { get; set; }

        public virtual pdm_users user { get; set; }
    }
}
