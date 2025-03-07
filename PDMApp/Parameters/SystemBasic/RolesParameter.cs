using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters.Basic
{
    public class RolesParameter
    {
        #nullable enable
        //[Required]
        public string? RoleName { get; set; }
        public string? Description { get; set; }
        public string? DevFactoryNo { get; set; }
        public string? IsActive { get; set; }
        //        public int PageNumber { get; set; } = 1; // 預設為第1頁
        //        public int PageSize { get; set; } = 10; // 預設每頁10筆
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }
}
