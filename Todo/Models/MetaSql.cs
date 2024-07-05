using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MetaSql
    {
        public string MetaSqlId { get; set; }
        public string MetaSqlNo { get; set; }
        public string MetaSqlType { get; set; }
        public string MetaSqlDesc { get; set; }
        public string MetaSqlDbms { get; set; }
        public string MetaSqlSql { get; set; }
        public string MetaSqlSort { get; set; }
        public string ApName { get; set; }
        public string MetaSqlName { get; set; }
        public decimal? UpdateTime { get; set; }
        public string UpdateUser { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
    }
}
