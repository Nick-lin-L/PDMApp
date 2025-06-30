using Microsoft.EntityFrameworkCore;
using PDMApp.Models;
using PDMApp.Parameters.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace PDMApp.Service.Basic
{
    public class UserManagementService : IUserManagementService
    {
        private readonly pcms_pdm_testContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public UserManagementService(pcms_pdm_testContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<pdm_users> CreateOrUpdateUserFromSSOAsync(string ssoAcct, string firstName, string lastName, string email, string pccuid, string keycloakSub, long? createdBy = null)
        {
            var normalizedSsoAcct = ssoAcct?.ToUpper();

            var existingUser = await _context.pdm_users
                .FirstOrDefaultAsync(u => u.sso_acct.ToUpper() == normalizedSsoAcct);

            if (existingUser != null)
            {
                // 更新現有使用者
                existingUser.last_login = DateTime.UtcNow;
                existingUser.updated_at = DateTime.UtcNow;
                existingUser.updated_by = createdBy;

                await _context.SaveChangesAsync();
                return existingUser;
            }
            else
            {
                // 建立新使用者
                var newUser = new pdm_users
                {
                    pccuid = decimal.TryParse(pccuid, out var pccuidValue) ? pccuidValue : 0,
                    username = $"{firstName} {lastName}".Trim(),
                    local_name = $"{firstName} {lastName}".Trim(),
                    sso_acct = normalizedSsoAcct,
                    email = email,
                    password_hash = BCrypt.Net.BCrypt.HashPassword(Guid.NewGuid().ToString()),
                    keycloak_iam_sub = keycloakSub,
                    is_sso = "Y",
                    is_active = "Y",
                    last_login = DateTime.UtcNow,
                    created_by = createdBy,
                    created_at = DateTime.UtcNow,
                    updated_by = createdBy,
                    updated_at = DateTime.UtcNow
                };

                _context.pdm_users.Add(newUser);
                await _context.SaveChangesAsync();
                return newUser;
            }
        }

        public async Task<bool> IsUserExistsBySSOAsync(string ssoAcct)
        {
            var normalizedSsoAcct = ssoAcct?.ToUpper();
            return await _context.pdm_users
                .AnyAsync(u => u.sso_acct.ToUpper() == normalizedSsoAcct);
        }

        public async Task<List<pdm_users>> BatchCreateUsersFromSSOAsync(List<UserCreateRequest> userRequests, long? createdBy = null)
        {
            var createdUsers = new List<pdm_users>();
            var currentTime = DateTime.UtcNow;

            foreach (var request in userRequests)
            {
                var normalizedSsoAcct = request.SsoAcct?.ToUpper();

                // 檢查是否已存在
                var existingUser = await _context.pdm_users
                    .FirstOrDefaultAsync(u => u.sso_acct.ToUpper() == normalizedSsoAcct);

                if (existingUser == null)
                {
                    // 建立新使用者
                    var newUser = new pdm_users
                    {
                        pccuid = decimal.TryParse(request.Pccuid, out var pccuidValue) ? pccuidValue : 0,
                        username = $"{request.FirstName} {request.LastName}".Trim(),
                        local_name = $"{request.FirstName} {request.LastName}".Trim(),
                        sso_acct = normalizedSsoAcct,
                        email = request.Email,
                        password_hash = BCrypt.Net.BCrypt.HashPassword(Guid.NewGuid().ToString()),
                        keycloak_iam_sub = request.KeycloakSub,
                        is_sso = "Y",
                        is_active = "Y",
                        last_login = currentTime,
                        created_by = createdBy,
                        created_at = currentTime,
                        updated_by = createdBy,
                        updated_at = currentTime
                    };

                    _context.pdm_users.Add(newUser);
                    createdUsers.Add(newUser);
                }
            }

            // 一次儲存所有變更
            if (createdUsers.Any())
            {
                await _context.SaveChangesAsync();
            }

            return createdUsers;
        }

        public async Task<UserInfoResponseDto> GetUserInfoFromSSOAsync(string ssoAcct)
        {
            try
            {
                // 先取得 token
                var tokenResponse = await GetAccessToken();
                if (tokenResponse == null || string.IsNullOrEmpty(tokenResponse.access_token))
                {
                    return null;
                }

                // 使用 token 查詢使用者資訊
                using var httpClient = _httpClientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.access_token);

                var normalizedSsoAcct = ssoAcct?.Trim()?.ToUpper();
                var userInfoUrl = $"https://iam.pouchen.com/api/v1/users?sso_acct={Uri.EscapeDataString(normalizedSsoAcct)}";
                var response = await httpClient.GetAsync(userInfoUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    // 先反序列化為包裝類別
                    var apiResponse = JsonSerializer.Deserialize<UserInfoApiResponse>(jsonResponse);

                    // 從 data 陣列中取得第一個使用者資訊
                    return apiResponse?.data?.FirstOrDefault();
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"查詢使用者資訊時發生錯誤: {ex.Message}");
                return null;
            }
        }

        private async Task<TokenResponseDto> GetAccessToken()
        {
            try
            {
                using var httpClient = _httpClientFactory.CreateClient();

                var tokenUrl = "https://iam.pouchen.com/auth/realms/service/protocol/openid-connect/token";
                var formData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_id", "pcms-tw-service-a9smv3k5"),
                    new KeyValuePair<string, string>("client_secret", "W0GJ7BSJzK85KkakXr0Mbc9xZRrknDvG")
                });

                var response = await httpClient.PostAsync(tokenUrl, formData);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<TokenResponseDto>(jsonResponse);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"取得Token時發生錯誤: {ex.Message}");
                return null;
            }
        }
    }
}