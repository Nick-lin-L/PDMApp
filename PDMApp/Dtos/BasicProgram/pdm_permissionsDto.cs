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
    }
}
