using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters.Spec
{
    public class SpecMIdParameter
    {
        #nullable enable
        [Required]
        public string? SpecMId { get; set; }

        public int PageNumber { get; set; } = 1; // 預設為第1頁
        public int PageSize { get; set; } = 10; // 預設每頁10筆
    }
}
