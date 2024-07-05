using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MdaMatCawn
    {
        public MdaMatCawn()
        {
            MifMesShoeprods = new HashSet<MifMesShoeprod>();
        }

        public string Matnr { get; set; }
        public string Zzdvpcd { get; set; }
        public string Zzdvptyp { get; set; }
        public string Zzdvpst { get; set; }
        public string ZzdvpstCode { get; set; }
        public string Zzdgdif { get; set; }
        public string Zzmdnam { get; set; }
        public string Zzmdmark { get; set; }
        public string Zzpartno { get; set; }
        public string Zzstylcode { get; set; }
        public string Zzcolorcode { get; set; }
        public string Zzatcolr { get; set; }
        public string Zzptncd { get; set; }
        public string Zzoutsolmod { get; set; }
        public string Zzmidsolmod { get; set; }
        public string Zzgendr { get; set; }
        public string Zzspclnote { get; set; }
        public string Zzlstcod { get; set; }
        public string Zzwidth { get; set; }
        public string Zzsizemap { get; set; }
        public string Zzsmplsize { get; set; }
        public string Zzodrszrg { get; set; }
        public string ZzmatnrPcnt { get; set; }
        public string Zzuprmatnr { get; set; }
        public string Zzoutsolmat { get; set; }
        public string ZgscmL { get; set; }
        public string ZgscmM { get; set; }
        public string ZgscmS { get; set; }
        public string Zthick { get; set; }
        public string Zvenprod { get; set; }
        public string Zpattern { get; set; }
        public string Zwide { get; set; }
        public string Zbackin { get; set; }
        public string Zmuticolor { get; set; }
        public string Zeffect { get; set; }
        public string Zcolor { get; set; }
        public string Zprocmd { get; set; }
        public string Zmoredtl { get; set; }
        public string ZleatherH { get; set; }
        public string Zoilcont { get; set; }
        public string Zdthinfo { get; set; }
        public string Zcloth2s { get; set; }
        public string Zsegm { get; set; }
        public string Zpartname { get; set; }
        public string Zmatnrpcnt { get; set; }
        public string Zdanny { get; set; }
        public string Zann { get; set; }
        public string Zpound { get; set; }
        public string Zmoldno { get; set; }
        public string Zhard { get; set; }
        public string Zplstmtrl { get; set; }
        public string Zqty { get; set; }
        public string Zdensity { get; set; }
        public string Zweight { get; set; }
        public string Zvdname { get; set; }
        public string Zpack { get; set; }
        public string Zsize { get; set; }
        public string Zcbfile { get; set; }
        public string Zlastno { get; set; }
        public string Zstybmn { get; set; }
        public string Zdyeing { get; set; }
        public string Zsegrang { get; set; }
        public string Zorg { get; set; }
        public string Zlength { get; set; }
        public string Zshoelen { get; set; }
        public string Zshoeno { get; set; }
        public string Zbraname { get; set; }
        public string Zwovenno { get; set; }
        public string Zmatnrpd { get; set; }
        public string Zplst { get; set; }
        public string Zl1narr { get; set; }
        public string Zl2narr { get; set; }
        public string Zl3narr { get; set; }
        public string Zl4narr { get; set; }
        public string Zl5narr { get; set; }
        public string Zl6narr { get; set; }
        public string Zhammng { get; set; }
        public string Zmodel { get; set; }
        public string Zneedles { get; set; }
        public string Znop { get; set; }
        public string Zpackcont { get; set; }
        public string Znature { get; set; }
        public string Zmatnr { get; set; }
        public string UpdateTime { get; set; }
        public string Zzfactstylecode { get; set; }
        public string Zzheelheight { get; set; }
        public string Zzformulanumber { get; set; }
        public string Zzspecialnote2 { get; set; }
        public string Zzspecialnote3 { get; set; }

        public virtual ICollection<MifMesShoeprod> MifMesShoeprods { get; set; }
    }
}
