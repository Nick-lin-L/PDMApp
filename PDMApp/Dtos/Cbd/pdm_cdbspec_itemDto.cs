using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.Cbd
{
    public class pdm_cdbspec_itemDto
    {
        #nullable enable
        //原始table也是pdm_spec_item，但因Dto欄位數量不同故重新命名
        [Required]
        public string? SpecMId { get; set; }
        public string? ActNo { get; set; }
        public int? SeqNo { get; set; }
        public string? Parts { get; set; }
        public string? MoldNo { get; set; }
        public string MaterialNo { get; set; }
        public string Material { get; set; }
        public string SubMaterial { get; set; }
        public string Standard { get; set; }
        public string Supplier { get; set; }
        public string Colors { get; set; }
        public string Memo { get; set; }
        public string Hcha { get; set; }
        public string Sec { get; set; }
        public string Width { get; set; }


        public decimal? Usage { get; set; }
        public decimal? Price { get; set; }
        public decimal? CostUS { get; set; }
    }
}
