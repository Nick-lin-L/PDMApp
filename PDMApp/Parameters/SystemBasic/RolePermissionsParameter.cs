﻿using Newtonsoft.Json;
using PDMApp.Utils.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Parameters.Basic
{
    public class RolePermissionsParameter
    {
        //[JsonConverter(typeof(IntConverterStr))]
        public string? RoleId { get; set; } // 角色 ID（新增時為 null）
        public string? RoleName { get; set; } // 角色名稱
        public string? Description { get; set; } // 角色描述
        public string? DevFactoryNo { get; set; } // 開發工廠編號
        public string? IsActive { get; set; } // 是否生效
        public long? UpdatedBy { get; set; } // 更新者 ID
        public List<PermissionRequest> Permissions { get; set; } // 權限列表
        public List<PermissionDetails> PermissionDetails { get; set; } // 擴充權限列表(details)
    }

    public class PermissionRequest
    {
        public int? PermissionId { get; set; } // 權限 ID
        public string IsActive { get; set; } // 是否啟用
        public string CreateP { get; set; } // 新增權限
        public string ReadP { get; set; } // 讀取權限
        public string UpdateP { get; set; } // 更新權限
        public string DeleteP { get; set; } // 刪除權限
        public string ExportP { get; set; } // 匯出權限
        public string ImportP { get; set; } // 匯入權限
        public string Permission1 { get; set; } // 預備權限1
        public string Permission2 { get; set; } // 預備權限2
        public string Permission3 { get; set; } // 預備權限3
        public string Permission4 { get; set; } // 預備權限4
    }

    public class PermissionDetails
    {
        public int RolePermissionDetailsId { get; set; } // 權限Detail ID
        public int PermissionId { get; set; } // 權限 ID
        public string PermissionKey { get; set; } // 權限名稱
        public int PermissionKeyId { get; set; } // 擴充權限Detail作業 ID
        public string DescriptionD { get; set; } // 權限Detail描述 ID
        public string IsActiveD { get; set; } // 是否啟用
    }

    public class PermissionCheckParameter
    {
        public string DevFactoryNo { get; set; }
        public int FrontendId { get; set; }
    }
}
