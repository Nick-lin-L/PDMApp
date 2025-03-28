﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_user_fact
    {
        public int user_fact_id { get; set; }
        public long user_id { get; set; }
        public string factory_no { get; set; }
        public bool? is_active { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_at { get; set; }

        public virtual pdm_users_new created_byNavigation { get; set; }
        public virtual pdm_users_new updated_byNavigation { get; set; }
        public virtual pdm_users_new user { get; set; }
    }
}
