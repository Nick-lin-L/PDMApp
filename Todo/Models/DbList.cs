using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class DbList
    {
        public string FactoryNo { get; set; }
        public string Cnname { get; set; }
        public string Region { get; set; }
        public string ServerType { get; set; }
        public string Fqdn { get; set; }
        public string DbMarktype { get; set; }
        public string DbHost { get; set; }
        public string DbPort { get; set; }
        public string DatabaseSid { get; set; }
        public string Username { get; set; }
        public string Passwd { get; set; }
        public string Remark { get; set; }
    }
}
