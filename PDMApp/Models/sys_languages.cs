using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class sys_languages
    {
        public int language_id { get; set; }
        public string language_code { get; set; }
        public string language_name { get; set; }
        public string is_default { get; set; }
        public string is_active { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_at { get; set; }

        public virtual pdm_users created_byNavigation { get; set; }
        public virtual pdm_users updated_byNavigation { get; set; }
    }
}
