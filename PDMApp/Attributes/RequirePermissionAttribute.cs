using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PDMApp.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class RequirePermissionAttribute : Attribute
    {
        public int PermissionId { get; }
        public string Action { get; }

        public RequirePermissionAttribute(int permissionId, string action)
        {
            PermissionId = permissionId;
            Action = action; // 大寫
        }
    }
}
