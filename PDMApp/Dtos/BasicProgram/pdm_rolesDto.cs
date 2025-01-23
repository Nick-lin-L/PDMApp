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
        /*
        public virtual pdm_users created_byNavigation { get; set; }
        public virtual pdm_users updated_byNavigation { get; set; }
        public virtual ICollection<pdm_permission_logs> pdm_permission_logs { get; set; }
        public virtual ICollection<pdm_role_permissions> pdm_role_permissions { get; set; }
        public virtual ICollection<pdm_user_roles> pdm_user_roles { get; set; }*/
    }
}
