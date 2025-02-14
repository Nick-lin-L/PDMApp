using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_roles
    {
        public pdm_roles()
        {
            pdm_permission_logs = new HashSet<pdm_permission_logs>();
            pdm_role_permissions = new HashSet<pdm_role_permissions>();
            pdm_user_roles = new HashSet<pdm_user_roles>();
        }

        public int role_id { get; set; }
        public string role_name { get; set; }
        public string description { get; set; }
        public string dev_factory_no { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_at { get; set; }
        public int role_level { get; set; }
        public string is_active { get; set; }

        public virtual pdm_users created_byNavigation { get; set; }
        public virtual pdm_users updated_byNavigation { get; set; }
        public virtual ICollection<pdm_permission_logs> pdm_permission_logs { get; set; }
        public virtual ICollection<pdm_role_permissions> pdm_role_permissions { get; set; }
        public virtual ICollection<pdm_user_roles> pdm_user_roles { get; set; }
    }
}
