using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters.SPEC
{
    public class CustomerSpesSearchParameter
    {
#nullable enable
        [Required]
        public string? SpecMId { get; set; }
        public string? PartNo { get; set; }
        public string? PartName { get; set; }
        public string? MatColor { get; set; }
        public string? Material { get; set; }
        public string? SubMaterial { get; set; }
        public string? Supplier { get; set; }
        public string? Width { get; set; }

        //        public int PageNumber { get; set; } = 1; // 預設為第1頁
        //        public int PageSize { get; set; } = 10; // 預設每頁10筆
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }
}
