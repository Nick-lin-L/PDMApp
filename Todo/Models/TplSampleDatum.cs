using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class TplSampleDatum
    {
        public string SampleDataId { get; set; }
        public string TemplateId { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public char IsDetail { get; set; }
        public string MetaFieldId { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }

        public virtual MetaField MetaField { get; set; }
        public virtual TplMaster Template { get; set; }
    }
}
