using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDMApp.Service.Basic
{
    public interface ICurrentUserPermissionService
    {
        /// <summary>
        /// 檢查目前登入使用者是否具有某個指定權限（CRUD 或擴充操作）
        /// </summary>
        /// <param name="PermissionId">權限編碼</param>
        /// <param name="action">動作，如：CREATE、EXPORT</param>
        /// <returns></returns>
        Task<bool> HasPermissionAsync(int permissionId, string action);

        /// <summary>
        /// 檢查目前登入使用者是否具有某個指定擴充權限
        /// </summary>
        /// <param name="permissionId">權限編碼</param>
        /// <param name="permissionKey">擴充權限鍵值</param>
        /// <returns></returns>
        Task<bool> HasExtendedPermissionAsync(int permissionId, string permissionKey);

        /// <summary>
        /// 獲取目前登入使用者的所有擴充權限
        /// </summary>
        /// <param name="permissionId">權限編碼</param>
        /// <returns>擴充權限字典，key為權限鍵值，value為是否啟用</returns>
        Task<Dictionary<string, bool>> GetExtendedPermissionsAsync(int permissionId);
    }
}
