using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class tbldept
    {
        public string deptcode { get; set; }
        public string deptsname { get; set; }
        public string deptname { get; set; }
        public string note { get; set; }
        public DateTime fixdate { get; set; }
        public string fixby { get; set; }
        public bool isnotvalid { get; set; }
    }
}
