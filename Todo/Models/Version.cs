using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class Version
    {
        public Version()
        {
            VersionRemoveItems = new HashSet<VersionRemoveItem>();
            VersionScripts = new HashSet<VersionScript>();
        }

        public decimal VersionId { get; set; }
        public string VersionName { get; set; }
        public string VersionDesc { get; set; }
        public decimal? VersionScriptTime { get; set; }
        public string VersionScriptZipFileId { get; set; }
        public char IsLocked { get; set; }
        public string CreateUser { get; set; }
        public decimal CreateTime { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual ICollection<VersionRemoveItem> VersionRemoveItems { get; set; }
        public virtual ICollection<VersionScript> VersionScripts { get; set; }
    }
}
