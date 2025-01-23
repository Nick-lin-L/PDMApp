using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_factory
    {
        public int factory_id { get; set; }
        public string dev_factory_no { get; set; }
        public string dev_factory_name { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_at { get; set; }

        public virtual pdm_users_new created_byNavigation { get; set; }
        public virtual pdm_users_new updated_byNavigation { get; set; }
    }
}
