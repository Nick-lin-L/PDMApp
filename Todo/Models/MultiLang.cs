using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MultiLang
    {
        public string MultiLangId { get; set; }
        public string LangId { get; set; }
        public string LocaleName { get; set; }
        public string LocaleValue { get; set; }
        public string UpdateUser { get; set; }
        public decimal UpdateTime { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string ApName { get; set; }
        public char NeedTrans { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
    }
}
