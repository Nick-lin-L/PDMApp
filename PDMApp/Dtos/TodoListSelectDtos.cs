using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Controllers.Dots
{
    public class TodoListSelectDtos
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
