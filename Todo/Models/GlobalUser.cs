using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class GlobalUser
    {
        public decimal Pccuid { get; set; }
        public string SsoAcct { get; set; }
        public string FactNo { get; set; }
        public string LocalFactNo { get; set; }
        public string ChineseNm { get; set; }
        public string LocalPnlNm { get; set; }
        public string EnglishNm { get; set; }
        public string ContactMail { get; set; }
        public string Sex { get; set; }
        public string LoPosiNm { get; set; }
        public string Disabled { get; set; }
        public DateTime? DisabledDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string LoDeptNm { get; set; }
        public string Tel { get; set; }
        public string LeaveMk { get; set; }
        public decimal? Id { get; set; }
    }
}
