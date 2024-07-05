using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MifToslog
    {
        public int Logid { get; set; }
        public DateTime? Logtime { get; set; }
        public string Jobname { get; set; }
        public string Factno { get; set; }
        public string Configcontent { get; set; }
        public string Action { get; set; }
        public string Exemk { get; set; }
        public string Exemsg { get; set; }
    }
}
