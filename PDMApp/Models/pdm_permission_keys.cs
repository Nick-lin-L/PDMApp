using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_permission_keys
    {
        public pdm_permission_keys()
        {
            pdm_role_permission_details = new HashSet<pdm_role_permission_details>();
        }

        public int permission_key_id { get; set; }
        public int permission_id { get; set; }
        public string permission_key { get; set; }
        public string description { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_at { get; set; }

        public virtual pdm_users created_byNavigation { get; set; }
        public virtual pdm_permissions permission { get; set; }
        public virtual pdm_users updated_byNavigation { get; set; }
        public virtual ICollection<pdm_role_permission_details> pdm_role_permission_details { get; set; }
    }
}
