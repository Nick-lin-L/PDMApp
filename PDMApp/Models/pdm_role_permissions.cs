using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_role_permissions
    {
        public int role_permission_id { get; set; }
        public int? role_id { get; set; }
        public int? permission_id { get; set; }
        public string dev_factory_no { get; set; }
        public string is_active { get; set; }
        public string createp { get; set; }
        public string readp { get; set; }
        public string updatep { get; set; }
        public string deletep { get; set; }
        public string exportp { get; set; }
        public string importp { get; set; }
        public string permission1 { get; set; }
        public string permission2 { get; set; }
        public string permission3 { get; set; }
        public string permission4 { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_at { get; set; }

        public virtual pdm_users created_byNavigation { get; set; }
        public virtual pdm_permissions permission { get; set; }
        public virtual pdm_roles role { get; set; }
        public virtual pdm_users updated_byNavigation { get; set; }
    }
}
