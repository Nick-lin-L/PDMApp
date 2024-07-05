using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MifMesShoeprod
    {
        public string Facility { get; set; }
        public string Stepname { get; set; }
        public string Action { get; set; }
        public string Materialn { get; set; }
        public string Productno { get; set; }
        public string Producttype { get; set; }
        public string Workno { get; set; }
        public string Arbpl { get; set; }
        public string Werks { get; set; }
        public string Opgroup { get; set; }
        public string Lindid { get; set; }
        public string Resourceg { get; set; }
        public string Resource { get; set; }
        public string Auart { get; set; }
        public char? Rcode { get; set; }
        public string Plnbez { get; set; }
        public string Vbeln { get; set; }
        public string Posnr { get; set; }
        public string Prodbatch { get; set; }
        public string Sizeno { get; set; }
        public decimal? Leftqty { get; set; }
        public decimal? Rightqty { get; set; }
        public string Primaryunits { get; set; }
        public decimal? Primaryquantity { get; set; }
        public string Zzmdmar { get; set; }
        public string Zzstylco { get; set; }
        public string Zzoutsol { get; set; }
        public string Zzmidsol { get; set; }
        public string Createon { get; set; }
        public string Brand { get; set; }
        public string Zzfactstylecode { get; set; }
        public string Buildno { get; set; }
        public string Floor { get; set; }

        public virtual MdaMatCawn PlnbezNavigation { get; set; }
    }
}
