﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_permissions
    {
        public pdm_permissions()
        {
            pdm_role_permissions = new HashSet<pdm_role_permissions>();
        }

        public int permission_id { get; set; }
        public string permission_name { get; set; }
        public string description { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_at { get; set; }

        public virtual pdm_users_new created_byNavigation { get; set; }
        public virtual pdm_users_new updated_byNavigation { get; set; }
        public virtual ICollection<pdm_role_permissions> pdm_role_permissions { get; set; }
    }
}
