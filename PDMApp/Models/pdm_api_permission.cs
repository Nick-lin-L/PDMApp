using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_api_permission
    {
        public int? permission_id { get; set; }
        public string permission_name { get; set; }
        public string update_user { get; set; }
        public DateTime? update_time { get; set; }
    }
}
