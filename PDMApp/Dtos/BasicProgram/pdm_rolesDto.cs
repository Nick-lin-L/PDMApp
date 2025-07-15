using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PDMApp.Utils.Converters;

namespace PDMApp.Dtos.BasicProgram
{
    public class pdm_rolesDto
    {
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? Description { get; set; }
        public string? DevFactoryNo { get; set; }
        //public string? CreatedBy { get; set; }
        //[JsonConverter(typeof(DateTimeConverterHms))]
        //public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        [JsonConverter(typeof(DateTimeConverterHms))]
        public DateTime? UpdatedAt { get; set; }
        public int? RoleLevel { get; set; }
        public string? IsActive { get; set; }
    }
}
