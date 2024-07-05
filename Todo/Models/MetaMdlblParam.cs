using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaMdlblParam
    {
        public string MetaMdlblParamId { get; set; }
        public string MetaMdlblId { get; set; }
        public string ParamKey { get; set; }
        public string ParamValue { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MetaMdlbl MetaMdlbl { get; set; }
    }
}
