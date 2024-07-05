using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class EppDevSeason
    {
        public string FactNo { get; set; }
        public string BrandNo { get; set; }
        public string TransDate { get; set; }
        public string SeasonId { get; set; }
        public string SeasonNo { get; set; }
        public decimal? SortNo { get; set; }
        public string TransMk { get; set; }
        public string ModifyUser { get; set; }
        public string ModifyTime { get; set; }
    }
}
