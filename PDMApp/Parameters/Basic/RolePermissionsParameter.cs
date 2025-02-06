using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters.Basic
{
    public class RolePermissionsParameter
    {
        public string? RoleId { get; set; } // 角色 ID（新增時為 null）
        public string? RoleName { get; set; } // 角色名稱
        public string? Description { get; set; } // 角色描述
        public string? DevFactoryNo { get; set; } // 開發工廠編號
        public bool? IsActive { get; set; } // 是否生效
        public string? UpdatedBy { get; set; } // 更新者 ID
        public List<PermissionRequest> Permissions { get; set; } // 權限列表
    }

    public class PermissionRequest
    {
        public int PermissionId { get; set; } // 權限 ID
        public bool IsActive { get; set; } // 是否啟用
        public bool CreateP { get; set; } // 新增權限
        public bool ReadP { get; set; } // 讀取權限
        public bool UpdateP { get; set; } // 更新權限
        public bool DeleteP { get; set; } // 刪除權限
        public bool ExportP { get; set; } // 匯出權限
        public bool ImportP { get; set; } // 匯入權限
        public string DevFactoryNo { get; set; } // 開發工廠編號
    }
}
