using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class LogRequestBody
    {
        public string LogMId { get; set; }
        public string RequestBody { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual LogMaster LogM { get; set; }
    }
}
