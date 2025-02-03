using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.BasicProgram
{
    public class pdm_rolesDto
    {
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? Description { get; set; }
        public string? DevFactoryNo { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? RoleLevel { get; set; }
        public bool? IsActive { get; set; }
    }
}
