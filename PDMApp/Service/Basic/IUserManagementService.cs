using PDMApp.Dtos.BasicProgram;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PDMApp.Service.Basic
{
    public interface IUserManagementService : IScopedService
    {
        // 單一使用者建立/更新（用於 AuthController）
        Task<pdm_users> CreateOrUpdateUserFromSSOAsync(string ssoAcct, string firstName, string lastName, string email, string pccuid, string keycloakSub, long? createdBy = null);

        // 檢查使用者是否存在
        Task<bool> IsUserExistsBySSOAsync(string ssoAcct);

        // 批次新增使用者（用於 AccountMaintenance）
        Task<List<pdm_users>> BatchCreateUsersFromSSOAsync(List<UserCreateRequest> userRequests, long? createdBy = null);

        // 查詢使用者資訊（從 SSO API）
        Task<UserInfoResponseDto> GetUserInfoFromSSOAsync(string ssoAcct);
    }

    public class UserCreateRequest
    {
        public string SsoAcct { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pccuid { get; set; }
        public string KeycloakSub { get; set; }
    }
}