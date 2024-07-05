using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class ErrorCode
    {
        public ErrorCode()
        {
            ErrorMsgs = new HashSet<ErrorMsg>();
        }

        public string ErrorCodeId { get; set; }
        public string ApName { get; set; }
        public string ModuleType { get; set; }
        public string Code { get; set; }
        public string Msg { get; set; }
        public string Solution { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual ICollection<ErrorMsg> ErrorMsgs { get; set; }
    }
}
