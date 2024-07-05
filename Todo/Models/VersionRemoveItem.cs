using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class VersionRemoveItem
    {
        public string VersionRemoveItemId { get; set; }
        public string RemoveFromTableName { get; set; }
        public string RemoveByScript { get; set; }
        public decimal? RemoveAtVersionId { get; set; }
        public string ApName { get; set; }
        public string CreateUser { get; set; }
        public decimal CreateTime { get; set; }

        public virtual Version RemoveAtVersion { get; set; }
    }
}
