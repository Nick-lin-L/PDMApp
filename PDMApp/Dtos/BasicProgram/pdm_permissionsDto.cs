using PDMApp.Models;
using PDMApp.Utils.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PDMApp.Dtos.BasicProgram
{
    public class pdm_permissionsDto
    {
        public int? PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
        public int? FrontEndId { get; set; }
        public string IsActive { get; set; }
        public string? CreatedBy { get; set; }
        [JsonConverter(typeof(DateTimeConverterHms))]
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        [JsonConverter(typeof(DateTimeConverterHms))]
        public DateTime? UpdatedAt { get; set; }

        //以下是role_permissions表資料
        public int RolePermissionId { get; set; }
        public int? RoleId { get; set; }
        //public int? PermissionId { get; set; }
        public string DevFactoryNo { get; set; }
        public string? Createp { get; set; }
        public string? Readp { get; set; }
        public string? Updatep { get; set; }
        public string? Deletep { get; set; }
        public string? Exportp { get; set; }
        public string? Importp { get; set; }
        public string? Permission1 { get; set; }
        public string? Permission2 { get; set; }
        public string? Permission3 { get; set; }
        public string? Permission4 { get; set; }
        //public Dictionary<string, string> PermissionDetails { get; set; } = new Dictionary<string, string>();
    }

    public class pdm_permissionsInitDto
    {
        public int? PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
        public int? FrontEndId { get; set; }

        //以下是role_permissions表資料
        //public int RolePermissionId { get; set; }
        public string? IsActive { get; set; }
        public string? Createp { get; set; }
        public string? Readp { get; set; }
        public string? Updatep { get; set; }
        public string? Deletep { get; set; }
        public string? Exportp { get; set; }
        public string? Importp { get; set; }
        public string? Permission1 { get; set; }
        public string? Permission2 { get; set; }
        public string? Permission3 { get; set; }
        public string? Permission4 { get; set; }
        //public Dictionary<string, string> PermissionDetails { get; set; } = new Dictionary<string, string>();
    }

    public class pdm_role_permission_detailsDto
    {
        public int RolePermissionDetailId { get; set; }  // 對應 pdm_role_permission_details 的主鍵
        public int RoleId { get; set; }
        public int PermissionId { get; set; }  // 對應 pdm_permissions 的主鍵
        public int PermissionKeyId { get; set; }  // 對應 pdm_permission_key 的主鍵
        public string Description { get; set; }  // 權限pdm_permissions描述
        public string? PermissionKey { get; set; }  // 權限細節名稱（如 TXT_import, PDF_import）
        public string DescriptionD { get; set; }  // 權限細節pdm_permission_details描述
        public string DevFactoryNoD { get; set; }  // 開發工廠編號
        public string? IsActiveD { get; set; }  // 是否啟用
        //public string? CreatedBy { get; set; }
        //[JsonConverter(typeof(DateTimeConverterHms))]
        //public DateTime? CreatedAt { get; set; }
        //public string? UpdatedBy { get; set; }
        //[JsonConverter(typeof(DateTimeConverterHms))]
        //public DateTime? UpdatedAt { get; set; }
    }

    public class pdm_role_permission_detailsInitDto
    {
        //public int RolePermissionDetailId { get; set; }  // 對應 pdm_role_permission_details 的主鍵
        public int PermissionId { get; set; }  // 對應 pdm_permissions 的主鍵
        public string PermissionName { get; set; }    // pdm_permissions作業名稱
        public string Description { get; set; }      // pdm_permissions作業描述
        public string? PermissionKey { get; set; }  // 權限細節名稱（如 TXT_import, PDF_import）
        public int? PermissionKeyId { get; set; }  // 權限細節名ID
        public string DescriptionD { get; set; }  // 權限細節描述
        public string? IsActiveD { get; set; }  // 是否啟用
    }
}
