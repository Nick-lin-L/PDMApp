using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class sampleshoeflow_err_list
    {
        public string fact_no { get; set; }
        public string order_no { get; set; }
        public string err_msg { get; set; }
        public string sync_time { get; set; }
        public char? mk { get; set; }
    }
}
