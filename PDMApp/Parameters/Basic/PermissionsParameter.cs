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
        /// <summary>
        /// 角色 ID
        /// </summary>
        public string? RoleId { get; set; }
        /// <summary>
        /// 權限 ID
        /// </summary>
        public string? PermissionId { get; set; }
        /// <summary>
        /// 權限 名稱
        /// </summary>
        public string? PermissionName { get; set; }
        /// <summary>
        /// 權限作業描述
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 開發中心代號
        /// </summary>
        public string? DevFactoryNo { get; set; }
        //        public int PageNumber { get; set; } = 1; // 預設為第1頁
        //        public int PageSize { get; set; } = 10; // 預設每頁10筆
        /// <summary>
        /// 頁碼
        /// </summary>
        public PaginationParameter Pagination { get; set; } = new PaginationParameter();
    }
}
