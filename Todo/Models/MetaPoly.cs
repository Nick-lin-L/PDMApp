using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaPoly
    {
        public string MetaPolyDeclareclass { get; set; }
        public string MetaPolyCondition { get; set; }
        public string MetaPolyCreateclass { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
    }
}
