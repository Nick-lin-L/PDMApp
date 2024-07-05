using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class FileMaster
    {
        public string MGuid { get; set; }
        public string RevGuid { get; set; }
        public decimal Version { get; set; }
        public string ApName { get; set; }
        public decimal FileSize { get; set; }
        public string FileName { get; set; }
        public decimal? DeleteTime { get; set; }
        public string DeleteUser { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
    }
}
