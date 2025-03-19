using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class plm_cbd_item
    {
        public string data_d_id { get; set; }
        public string data_m_id { get; set; }
        public string data_id { get; set; }
        public int? seqno { get; set; }
        public string no { get; set; }
        public string newmaterial { get; set; }
        public string parts { get; set; }
        public string detail { get; set; }
        public string materialno { get; set; }
        public string material { get; set; }
        public string mtrtype { get; set; }
        public string mtrbase { get; set; }
        public string processing { get; set; }
        public string effect { get; set; }
        public string releasepaper { get; set; }
        public string basecolor { get; set; }
        public string process_mk { get; set; }
        public string mtrcomment { get; set; }
        public string cbdcomment { get; set; }
        public string standard { get; set; }
        public string supplier { get; set; }
        public string agent { get; set; }
        public string quotesupplier { get; set; }
        public string colors { get; set; }
        public string clrcomment { get; set; }
        public string moldno { get; set; }
        public string hcha { get; set; }
        public string sec { get; set; }
        public string width { get; set; }
        public decimal? usage1 { get; set; }
        public decimal? usage2 { get; set; }
        public decimal? basicprice { get; set; }
        public decimal? unitprice { get; set; }
        public decimal? mtrloss { get; set; }
        public decimal? freight { get; set; }
        public decimal? cost { get; set; }
        public string memo { get; set; }
        public string change_mk { get; set; }
        public string partclass { get; set; }
        public string act_no { get; set; }
        public string act_parts { get; set; }
        public string factory_mold_no { get; set; }
        public string group_mk { get; set; }
        public string recycle { get; set; }
    }
}
