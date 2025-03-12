using System;
using System.Collections.Generic;

#nullable disable

namespace PDMApp.Models
{
    public partial class pdm_users
    {
        public pdm_users()
        {
            pdm_factorycreated_byNavigation = new HashSet<pdm_factory>();
            pdm_factoryupdated_byNavigation = new HashSet<pdm_factory>();
            pdm_permission_logs = new HashSet<pdm_permission_logs>();
            pdm_permissionscreated_byNavigation = new HashSet<pdm_permissions>();
            pdm_permissionsupdated_byNavigation = new HashSet<pdm_permissions>();
            pdm_role_permission_detailscreated_byNavigation = new HashSet<pdm_role_permission_details>();
            pdm_role_permission_detailsupdated_byNavigation = new HashSet<pdm_role_permission_details>();
            pdm_role_permissionscreated_byNavigation = new HashSet<pdm_role_permissions>();
            pdm_role_permissionsupdated_byNavigation = new HashSet<pdm_role_permissions>();
            pdm_rolescreated_byNavigation = new HashSet<pdm_roles>();
            pdm_rolesupdated_byNavigation = new HashSet<pdm_roles>();
            pdm_user_rolescreated_byNavigation = new HashSet<pdm_user_roles>();
            pdm_user_rolesupdated_byNavigation = new HashSet<pdm_user_roles>();
            pdm_user_rolesuser = new HashSet<pdm_user_roles>();
        }

        public long user_id { get; set; }
        public decimal? pccuid { get; set; }
        public string username { get; set; }
        public string local_name { get; set; }
        public string sso_acct { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public string is_sso { get; set; }
        public string is_active { get; set; }
        public DateTime? last_login { get; set; }
        public long? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public long? updated_by { get; set; }
        public DateTime? updated_at { get; set; }
        public string keycloak_iam_sub { get; set; }

        public virtual ICollection<pdm_factory> pdm_factorycreated_byNavigation { get; set; }
        public virtual ICollection<pdm_factory> pdm_factoryupdated_byNavigation { get; set; }
        public virtual ICollection<pdm_permission_logs> pdm_permission_logs { get; set; }
        public virtual ICollection<pdm_permissions> pdm_permissionscreated_byNavigation { get; set; }
        public virtual ICollection<pdm_permissions> pdm_permissionsupdated_byNavigation { get; set; }
        public virtual ICollection<pdm_role_permission_details> pdm_role_permission_detailscreated_byNavigation { get; set; }
        public virtual ICollection<pdm_role_permission_details> pdm_role_permission_detailsupdated_byNavigation { get; set; }
        public virtual ICollection<pdm_role_permissions> pdm_role_permissionscreated_byNavigation { get; set; }
        public virtual ICollection<pdm_role_permissions> pdm_role_permissionsupdated_byNavigation { get; set; }
        public virtual ICollection<pdm_roles> pdm_rolescreated_byNavigation { get; set; }
        public virtual ICollection<pdm_roles> pdm_rolesupdated_byNavigation { get; set; }
        public virtual ICollection<pdm_user_roles> pdm_user_rolescreated_byNavigation { get; set; }
        public virtual ICollection<pdm_user_roles> pdm_user_rolesupdated_byNavigation { get; set; }
        public virtual ICollection<pdm_user_roles> pdm_user_rolesuser { get; set; }
    }
}
