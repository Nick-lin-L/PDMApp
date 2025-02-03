using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters.Basic
{
    public class PermissionsParameter
    {
#nullable enable
        //[Required]
        public string? PermissionId { get; set; }
        public string? PermissionName { get; set; }
        public string? Description { get; set; }
        //        public int PageNumber { get; set; } = 1; // 預設為第1頁
        //        public int PageSize { get; set; } = 10; // 預設每頁10筆
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }
}
