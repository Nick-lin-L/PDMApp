using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class plm_cbd_moldcharge
    {
        public string data_d_id { get; set; }
        public string data_m_id { get; set; }
        public string id { get; set; }
        public string item { get; set; }
        public decimal? price { get; set; }
        public decimal? qty { get; set; }
        public decimal? amortization { get; set; }
        public decimal? charge { get; set; }
        public decimal? years { get; set; }
        public decimal? rate { get; set; }
        public decimal? unitprice { get; set; }
        public decimal? cost { get; set; }
    }
}
