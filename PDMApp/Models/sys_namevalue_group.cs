using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class sys_namevalue_group
    {
        public decimal pkid { get; set; }
        public string group_key { get; set; }
        public string type { get; set; }
        public string group_name { get; set; }
        public string modify_user { get; set; }
        public DateTime? modify_time { get; set; }
    }
}
