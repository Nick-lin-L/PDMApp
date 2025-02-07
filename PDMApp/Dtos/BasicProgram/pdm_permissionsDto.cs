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
        public bool? IsActive { get; set; }
        public bool? Createp { get; set; }
        public bool? Readp { get; set; }
        public bool? Updatep { get; set; }
        public bool? Deletep { get; set; }
        public bool? Exportp { get; set; }
        public bool? Importp { get; set; }
        public bool? Permission1 { get; set; }
        public bool? Permission2 { get; set; }
        public bool? Permission3 { get; set; }
        public bool? Permission4 { get; set; }
    }
}
