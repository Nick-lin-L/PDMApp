using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaMdlBackup
    {
        public string MetaMdlId { get; set; }
        public string MetaMdlNo { get; set; }
        public string MetaMdlDesc { get; set; }
        public string MetaMdlPost { get; set; }
        public decimal? UpdateTime { get; set; }
        public string ApName { get; set; }
        public string MetaMdlName { get; set; }
        public string UpdateUser { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
    }
}
