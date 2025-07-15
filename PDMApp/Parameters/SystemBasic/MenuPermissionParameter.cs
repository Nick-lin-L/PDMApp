using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters.SystemBasic
{
    public class MenuPermissionParameter
    {
        public int UserId { get; set; }
        public string DevFactoryNo { get; set; }
        public string LangCode { get; set; } = "zh-TW"; // default
    }
}
