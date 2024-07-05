using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class Soleprod
    {
        public string Facility { get; set; }
        public string Stepid { get; set; }
        public string Createby { get; set; }
        public string Workno { get; set; }
        public string Workseq { get; set; }
        public string Aufnr { get; set; }
        public string Productkind { get; set; }
        public string Vbeln { get; set; }
        public string Posnr { get; set; }
        public string Prodbatch { get; set; }
        public string Wosize { get; set; }
        public decimal? Primaryquantity { get; set; }
    }
}
