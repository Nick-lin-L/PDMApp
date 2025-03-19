using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_spec_moldcharge
    {
        public string data_id { get; set; }
        public string spec_m_id { get; set; }
        public string id { get; set; }
        public string item { get; set; }
        public decimal? price { get; set; }
        public int? qty { get; set; }
        public decimal? amortization { get; set; }
        public decimal? charge { get; set; }
        public int? years { get; set; }
    }
}
