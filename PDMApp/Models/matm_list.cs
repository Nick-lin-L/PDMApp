using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class matm_list
    {
        public string mgt_no { get; set; }
        public string mat_no { get; set; }
        public string serp_mat_no { get; set; }
        public string scm_bclass_no { get; set; }
        public string scm_mclass_no { get; set; }
        public string scm_sclass_no { get; set; }
        public char is_locked { get; set; }
        public string sync_time { get; set; }
        public char? mk { get; set; }
    }
}
