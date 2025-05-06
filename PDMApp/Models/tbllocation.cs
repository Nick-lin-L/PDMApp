using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class tbllocation
    {
        public string locationid { get; set; }
        public string locationname { get; set; }
        public bool? isnotvalid { get; set; }
        public string fixby { get; set; }
        public DateTime? fixdate { get; set; }
    }
}
