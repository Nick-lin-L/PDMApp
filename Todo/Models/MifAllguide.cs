using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class MifAllguide
    {
        public string GuideNo { get; set; }
        public string GuideDesc { get; set; }
        public string UpGuideNo { get; set; }
        public string FactNo { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Data3 { get; set; }
        public string Data4 { get; set; }
        public string Data5 { get; set; }
        public decimal? DataSort { get; set; }
        public string HeadMk { get; set; }
        public char? StopMk { get; set; }
    }
}
