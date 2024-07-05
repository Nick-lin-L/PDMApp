using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaObjblParam
    {
        public string MetaObjblParamId { get; set; }
        public string MetaObjblId { get; set; }
        public string ParamKey { get; set; }
        public string ParamValue { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MetaObjbl MetaObjbl { get; set; }
    }
}
