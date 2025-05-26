using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters.SPEC
{
    public class CustomerSpecsSearchParameter
    {
#nullable enable
        //[Required]
        //public string? SpecMId { get; set; }
        public string? Season { get; set; }
        public string? WorkingName { get; set; }
        public string? DevelopmentNo { get; set; }
        public string? Colorway { get; set; }
        public string? LastUpdate { get; set; }
        public string? LoginFactory { get; set; }
        public string? Stage { get; set; }

        //        public int PageNumber { get; set; } = 1; // 預設為第1頁
        //        public int PageSize { get; set; } = 10; // 預設每頁10筆
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }
}
