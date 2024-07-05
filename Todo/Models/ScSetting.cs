using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class ScSetting
    {
        public string ScSettingId { get; set; }
        public string TargetTblNm { get; set; }
        public string TargetColNm { get; set; }
        public string CatCtrlId { get; set; }
        public string ScFct { get; set; }
        public string ScPlanId { get; set; }
        public string CatTblNm { get; set; }
        public string CatColNm { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string UpdateUser { get; set; }
        public decimal UpdateTime { get; set; }

        public virtual ScCatCtrl CatCtrl { get; set; }
        public virtual ScPlan ScPlan { get; set; }
    }
}
