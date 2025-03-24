using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class sys_menu_i18n
    {
        public int menu_i18n_id { get; set; }
        public int menu_id { get; set; }
        public string language_code { get; set; }
        public string menu_name { get; set; }
        public string description { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_at { get; set; }

        public virtual pdm_users created_byNavigation { get; set; }
        public virtual sys_menus menu { get; set; }
        public virtual pdm_users updated_byNavigation { get; set; }
    }
}
