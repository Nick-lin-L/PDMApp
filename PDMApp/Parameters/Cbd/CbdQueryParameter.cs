using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters.Cbd
{
    public class CbdQueryParameter
    {
        public string? development_no { set; get; }
        public string? working_name { set; get; }
        public string? stage { set; get; }
        public string? colorway { set; get; }
        public string? colors { set; get; }
        public string? itemtrading_code { set; get; }
        public string? color_code { set; get; }
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }
}