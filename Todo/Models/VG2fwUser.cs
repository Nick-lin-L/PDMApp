using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class VG2fwUser
    {
        public decimal? Pccuid { get; set; }
        public string UserId { get; set; }
        public string UserLang { get; set; }
        public string UserDisable { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string ImAcct { get; set; }
        public string UserTimezone { get; set; }
        public string SsoAcct { get; set; }
        public string FactNo { get; set; }
        public string LocalFactNo { get; set; }
        public string ChineseNm { get; set; }
        public string LocalPnlNm { get; set; }
        public string EnglishNm { get; set; }
        public string Sex { get; set; }
        public string LoPosiNm { get; set; }
        public DateTime? DisabledDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ContactMail { get; set; }
    }
}
