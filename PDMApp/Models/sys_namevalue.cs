using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class sys_namevalue
    {
        public string pkid { get; set; }
        public string data_no { get; set; }
        public string text { get; set; }
        public string text_en { get; set; }
        public string group_key { get; set; }
        public string status { get; set; }
        public string modify_user { get; set; }
        public DateTime? modify_time { get; set; }
    }
}
