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
    }
}
