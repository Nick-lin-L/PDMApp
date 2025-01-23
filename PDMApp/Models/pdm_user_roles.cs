using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_user_roles
    {
        public int user_role_id { get; set; }
        public long? user_id { get; set; }
        public int? role_id { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_at { get; set; }

        public virtual pdm_users created_byNavigation { get; set; }
        public virtual pdm_roles role { get; set; }
        public virtual pdm_users updated_byNavigation { get; set; }
        public virtual pdm_users user { get; set; }
    }
}
