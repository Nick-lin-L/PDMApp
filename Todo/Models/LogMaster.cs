using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class LogMaster
    {
        public string LogMId { get; set; }
        public string ServerIp { get; set; }
        public string ApName { get; set; }
        public string Action { get; set; }
        public string UserId { get; set; }
        public string PccUid { get; set; }
        public string UserAccount { get; set; }
        public string UserName { get; set; }
        public string RemoteAddr { get; set; }
        public string UserIp { get; set; }
        public string UserAgent { get; set; }
        public string ThreadName { get; set; }
        public string SessionId { get; set; }
        public string HttpMethod { get; set; }
        public string RequestBody { get; set; }
        public decimal? TakeTime { get; set; }
        public char HasError { get; set; }
        public char IsMasterMissing { get; set; }
        public string FwVersion { get; set; }
        public decimal? StartTime { get; set; }
        public decimal? EndTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual LogRequestBody LogRequestBody { get; set; }
    }
}
