using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Dtos.BasicProgram
{
    public class pdm_permissionsDto
    {
        public int? PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
