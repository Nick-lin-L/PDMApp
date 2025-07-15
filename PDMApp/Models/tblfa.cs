using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class tblfa
    {
        public string facode { get; set; }
        public string faname { get; set; }
        public string faspec { get; set; }
        public string catego { get; set; }
        public short? fatype { get; set; }
        public int? buydate { get; set; }
        public string supplierid { get; set; }
        public int? qty { get; set; }
        public string unit { get; set; }
        public string recorder { get; set; }
        public string deptcode { get; set; }
        public short? status { get; set; }
        public string mainnote { get; set; }
        public DateTime? fixdate { get; set; }
        public string fixby { get; set; }
    }
}
