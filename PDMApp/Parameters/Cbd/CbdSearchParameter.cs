#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters.Cbd
{
    public class CbdSearchParameter
    {
        public class InitialParameter
        {
            public string? DevFactoryNo { get; set; }
        }
        public class QueryParameter
        {
            public string? DevFactoryNo { get; set; }
            public string? Brand { get; set; }
            public string? ProductLineType { get; set; }
            public string? Stage { get; set; }
            public string? ItemNo { get; set; }
            public string? DevelopmentNo { get; set; }
            public string? ColorCode { get; set; }
            public string? Parts { get; set; }
            public string? Material { get; set; }
            public string? MaterialColor { get; set; }
            public string? Supplier { get; set; }
            public string? WorkingName { get; set; }
            public string? Last { get; set; }
            public PaginationParameter Pagination { get; set; } = new PaginationParameter();
        }
    }
}