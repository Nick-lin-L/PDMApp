using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_role_permission_details
    {
        public int role_permission_detail_id { get; set; }
        public int? role_id { get; set; }
        public int? permission_id { get; set; }
        public string dev_factory_no { get; set; }
        public string permission_key { get; set; }
        public string description { get; set; }
        public string is_active { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_at { get; set; }

        public virtual pdm_users created_byNavigation { get; set; }
        public virtual pdm_role_permissions permission { get; set; }
        public virtual pdm_roles role { get; set; }
        public virtual pdm_users updated_byNavigation { get; set; }
    }
}
