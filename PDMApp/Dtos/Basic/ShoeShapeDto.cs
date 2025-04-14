using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.Basic
{
    public class ShoeShapeDto
    {
        public string? ProductMId { get; set; }
        public string? DevelopmentNo { get; set; }
        public string? ItemNo { get; set; }
        public string? Season { get; set; }
        public string? Stage { get; set; }
        public string? ValueDesc { get; set; } // stage內存
        public string? Text { get; set; }      // stage外顯
        public string? WorkingName { get; set; }
        public string? Factory { get; set; }
        public string? Gender { get; set; }
        public string? SampleSize { get; set; }
        public string? Width { get; set; }
        public string? Last1 { get; set; }
        public string? Last2 { get; set; }
        public string? Last3 { get; set; }
        public string? SizeRange { get; set; }
        public string? SizeRun { get; set; }
        public DateTime? LastUpdate { get; set; }

        //子檔查詢結果
        public string? Active { get; set; }
        public string? DevelopmentColorNo { get; set; }
        public string? ColorCode { get; set; }
        public string? Colorway { get; set; }
        public string? MainColor { get; set; }
        public string? SubColor { get; set; }
    }
}
