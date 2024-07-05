using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class ExportFileLog
    {
        public string Pccuid { get; set; }
        public string ExportMk { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string FileName { get; set; }
        public string Uuid { get; set; }
    }
}
