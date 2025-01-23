using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_permission_logs
    {
        public int log_id { get; set; }
        public long? user_id { get; set; }
        public int? role_id { get; set; }
        public string dev_factory_no { get; set; }
        public string factory_no { get; set; }
        public string operation { get; set; }
        public string permission_detail { get; set; }
        public DateTime? created_at { get; set; }
        public string ip_address { get; set; }

        public virtual pdm_roles role { get; set; }
        public virtual pdm_users user { get; set; }
    }
}
