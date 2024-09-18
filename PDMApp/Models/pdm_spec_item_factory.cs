using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_spec_item_factory
    {
        public string spec_d_id { get; set; }
        public string spec_m_id { get; set; }
        public string data_id { get; set; }
        public int? seqno { get; set; }
        public string no { get; set; }
        public string newmaterial { get; set; }
        public string parts { get; set; }
        public string materialno { get; set; }
        public string material { get; set; }
        public string materialcomment { get; set; }
        public string submaterial { get; set; }
        public string standard { get; set; }
        public string supplier { get; set; }
        public string colors { get; set; }
        public string moldno { get; set; }
        public string hcha { get; set; }
        public string sec { get; set; }
        public string width { get; set; }
        public decimal? usage1 { get; set; }
        public decimal? usage2 { get; set; }
        public decimal? pricenttur { get; set; }
        public decimal? pricentmst { get; set; }
        public decimal? materialloss { get; set; }
        public decimal? freight { get; set; }
        public decimal? cost { get; set; }
        public string memo { get; set; }
        public string partclass { get; set; }
        public string act_no { get; set; }
        public string page_break { get; set; }
        public string factory_mold_no { get; set; }
    }
}
