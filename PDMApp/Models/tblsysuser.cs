using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class tblsysuser
    {
        public string userid { get; set; }
        public string username { get; set; }
        public string deptcode { get; set; }
        public bool? isnotvalid { get; set; }
        public DateTime? fixdate { get; set; }
        public string fixby { get; set; }
    }
}
