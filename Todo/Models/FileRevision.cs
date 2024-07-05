using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class FileRevision
    {
        public string RevGuid { get; set; }
        public string MGuid { get; set; }
        public decimal Version { get; set; }
        public string RootPath { get; set; }
        public string ApPath { get; set; }
        public string FileStorePath { get; set; }
        public decimal FileSize { get; set; }
        public string FileName { get; set; }
        public char IsZiped { get; set; }
        public string CreateUser { get; set; }
        public decimal? CreateTime { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
    }
}
