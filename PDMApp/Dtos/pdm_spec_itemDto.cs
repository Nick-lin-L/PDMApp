using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos
{
    public class pdm_spec_itemDto
    {
        public string? ActNo { get; set; }
        public int? Seqno { get; set; }
        public string? Parts { get; set; }
        public string? Moldno { get; set; }
        public string Materialno { get; set; }
        public string Material { get; set; }
        public string Submaterial { get; set; }
        public string Standard { get; set; }
        public string Supplier { get; set; }
        public string Colors { get; set; }
        public string Memo { get; set; }
        public string Hcha { get; set; }
        public string Sec { get; set; }
        public string Width { get; set; }
    }
}
