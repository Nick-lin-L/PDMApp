using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class BaseSetting
    {
        public string BaseSettingsId { get; set; }
        public string ModuleType { get; set; }
        public string ApName { get; set; }
        public string ValueType { get; set; }
        public char Editable { get; set; }
        public string Editor { get; set; }
        public string ParamKey { get; set; }
        public string ParamValue { get; set; }
        public string Description { get; set; }
        public string ValueList { get; set; }
        public string ValueDescription { get; set; }
        public string AdvSetUrl { get; set; }
        public decimal Sort { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
    }
}
