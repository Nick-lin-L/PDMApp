using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class dms_ebom_color
    {
        public decimal ID { get; set; }
        public decimal? EBOM_SPEC_ID { get; set; }
        public string TREATMENT { get; set; }
        public string INSTRUCTION { get; set; }
        public string COLOR_NAME { get; set; }
        public string COLOR_CODE { get; set; }
        public string USER_NO { get; set; }
        public string MODIFY_DT { get; set; }
        public decimal? ARTIC_ID { get; set; }
        public string MTRL_SUPPLIER { get; set; }
        public string MTRL_FULL_NAME { get; set; }
        public string SUPPLIER_FAC { get; set; }
        public string MTRL_ID { get; set; }
        public string CHG_REASON { get; set; }
        public string CHG_MEMO { get; set; }
        public string UOM { get; set; }
        public decimal? YIELD { get; set; }
        public string IM_NO { get; set; }
        public string PRE_MAT_NO { get; set; }
        public string MTRL_NOTE { get; set; }
        public string OTHERS_NO { get; set; }
        public string REC_MK { get; set; }
        public DateTime? REC_DATE { get; set; }
        public string SPEC_M_ID { get; set; }
        public string SPEC_D_ID { get; set; }
    }
}
