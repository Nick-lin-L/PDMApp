using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_history_denamic_signflow
    {
        public int id { get; set; }
        public string user_id { get; set; }
        public string bill_class_id { get; set; }
        public string signflow_cn { get; set; }
        public string signflow_detail { get; set; }
        public string is_default { get; set; }
        public string sub_bill_class { get; set; }
        public string status { get; set; }
        public string group_key { get; set; }
    }
}
