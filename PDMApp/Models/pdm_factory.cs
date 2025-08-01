﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_factory
    {
        public pdm_factory()
        {
            pdm_roles = new HashSet<pdm_roles>();
        }

        public int factory_id { get; set; }
        public string dev_factory_no { get; set; }
        public string dev_factory_name { get; set; }
        public string factory_no { get; set; }
        public string factory_name { get; set; }
        public string factory_name_en { get; set; }
        public string factory_abbr { get; set; }
        public string factory_abbr_en { get; set; }
        public string area_no { get; set; }
        public string country { get; set; }
        public string bu { get; set; }
        public string bu_no { get; set; }
        public string pca_no { get; set; }
        public string custom_region_no { get; set; }
        public string company_no { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_at { get; set; }

        public virtual pdm_users created_byNavigation { get; set; }
        public virtual pdm_users updated_byNavigation { get; set; }
        public virtual ICollection<pdm_roles> pdm_roles { get; set; }
    }
}
