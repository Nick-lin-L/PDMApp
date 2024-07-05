using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class ScCatCtrl
    {
        public ScCatCtrl()
        {
            ScSettings = new HashSet<ScSetting>();
        }

        public string CatCtrlId { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string CatNo { get; set; }
        public string CatNm { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string UpdateUser { get; set; }
        public decimal UpdateTime { get; set; }

        public virtual ICollection<ScSetting> ScSettings { get; set; }
    }
}
