using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class TalendJob
    {
        public TalendJob()
        {
            MetaBl1s = new HashSet<MetaBl1>();
        }

        public string TalendJobId { get; set; }
        public string TalendJobName { get; set; }
        public string TalendJobClass { get; set; }
        public string TalendJobTarget { get; set; }
        public string TalendJobDesc { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }

        public virtual ICollection<MetaBl1> MetaBl1s { get; set; }
    }
}
