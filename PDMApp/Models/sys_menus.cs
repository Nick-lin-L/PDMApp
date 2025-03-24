using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class sys_menus
    {
        public sys_menus()
        {
            Inverseparent = new HashSet<sys_menus>();
            sys_menu_i18n = new HashSet<sys_menu_i18n>();
        }

        public int menu_id { get; set; }
        public int? parent_id { get; set; }
        public string menu_code { get; set; }
        public string menu_name { get; set; }
        public string menu_path { get; set; }
        public string component_path { get; set; }
        public string menu_icon { get; set; }
        public string menu_type { get; set; }
        public string permission_key { get; set; }
        public int? sort_order { get; set; }
        public string is_visible { get; set; }
        public string is_active { get; set; }
        public string dev_factory_no { get; set; }
        public string description { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_at { get; set; }

        public virtual pdm_users created_byNavigation { get; set; }
        public virtual sys_menus parent { get; set; }
        public virtual pdm_users updated_byNavigation { get; set; }
        public virtual ICollection<sys_menus> Inverseparent { get; set; }
        public virtual ICollection<sys_menu_i18n> sys_menu_i18n { get; set; }
    }
}
