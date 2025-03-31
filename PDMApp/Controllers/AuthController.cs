using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PDMApp.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using PDMApp.Models;
using PDMApp.Service;
using Microsoft.AspNetCore.Authorization;
using PDMApp.Utils;
using PDMApp.Utils.BasicProgram;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Http;

namespace PDMApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly OAuthConfig _config;
        private readonly string _jwtSecret;
        private readonly PdmUsersRepository _pdmUsersRepository;
        private readonly IMemoryCache _cache;
        private readonly IHttpClientFactory _httpClientFactory;
        public AuthController(IOptions<OAuthConfig> config, IConfiguration configuration, PdmUsersRepository pdmUsersRepository, IMemoryCache cache, IHttpClientFactory httpClientFactory)
        {
            _config = config.Value;
            _jwtSecret = configuration["Authentication:PCG:ClientSecret"];
            _pdmUsersRepository = pdmUsersRepository; // 初始化 Repository
            _cache = cache;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// 取得登入 URL，讓前端重定向至 IAM 登入頁面
        /// </summary>
        [AllowAnonymous]
        [HttpGet("login")]
        public IActionResult Login()
        {
            //*
            var authProperties = new AuthenticationProperties
            {
                //RedirectUri = _config.RedirectUri
                RedirectUri = Url.Action("Callback", "Auth", null, Request.Scheme) // 動態設定 Callback
            };
            // 傳回登入 URL，供前端重定向
            return Challenge(authProperties, OpenIdConnectDefaults.AuthenticationScheme);
        }


        /// <summary>
        /// 取得用戶詳細資訊
        /// </summary>
        [Authorize(AuthenticationSchemes = "PDMToken")]
        [HttpGet("profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            try
            {
                var currentUser = CurrentUserUtils.Get(HttpContext);
                if (currentUser?.UserId == null)
                {
                    return APIResponseHelper.HandleApiError<object>("401", "未登入或Token無效").Result;
                }

                // 從資料庫獲取完整用戶資訊
                var user = await _pdmUsersRepository.GetByPccuid(currentUser.Pccuid);
                if (user == null)
                {
                    return APIResponseHelper.HandleApiError<object>("404", "找不到用戶資料").Result;
                }

                // 獲取用戶的廠區權限
                var factories = await _pdmUsersRepository.GetUserFactories(user.user_id);

                var userProfile = new
                {
                    UserId = user.user_id,
                    Pccuid = user.pccuid,
                    LocalName = user.local_name,
                    //LastLogin = user.last_login?.ToLocalTime(), // 轉換為本地時間
                    IsActive = true, // 如果能夠取得資料，代表用戶是活躍的
                    Factories = factories // 添加廠區列表
                };

                return APIResponseHelper.GenerateApiResponse("OK", "查詢成功", userProfile).Result;
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<object>("500", $"取得用戶資料時發生錯誤：{ex.Message}").Result;
            }
        }

        /// <summary>
        /// 檢查用戶登入狀態
        /// </summary>
        [HttpGet("status")]
        public async Task<IActionResult> CheckAuthStatus()
        {
            try
            {
                var pdmToken = HttpContext.Request.Cookies["PDMToken"];

                // 2. 如果 Cookie 中沒有，則檢查 Authorization Header
                if (string.IsNullOrEmpty(pdmToken))
                {
                    var authHeader = HttpContext.Request.Headers["Authorization"].FirstOrDefault();
                    if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    {
                        pdmToken = authHeader.Substring("Bearer ".Length).Trim();
                    }
                }

                var accessTokenTask = HttpContext.GetTokenAsync("access_token");
                var accessToken = await accessTokenTask;  // 修正：等待 Task 完成並獲取結果

                if (string.IsNullOrEmpty(pdmToken) && string.IsNullOrEmpty(accessToken))
                {
                    return APIResponseHelper.HandleApiError<object>(
                        ((int)AuthenticationStatus.NotAuthenticated).ToString(),
                        "未登入").Result;
                }

                // 如果有 PDM Token，先驗證它
                if (!string.IsNullOrEmpty(pdmToken))
                {
                    var validationTask = ValidateTokenWithCache(pdmToken);
                    var (isValid, token, _) = await validationTask;

                    if (!isValid || token == null)
                    {
                        return APIResponseHelper.HandleApiError<object>(
                            ((int)AuthenticationStatus.NotAuthenticated).ToString(),
                            "未登入").Result;
                    }

                    var remainingTime = token.ValidTo - DateTime.UtcNow;

                    // 檢查 Token 是否即將過期（例如：剩餘 10 分鐘以內）
                    if (remainingTime.TotalMinutes <= 10)
                    {
                        try
                        {
                            // 從 Token 中獲取用戶信息
                            var userInfo = new UserInfo
                            {
                                family_name = token.Claims.FirstOrDefault(c => c.Type == "name")?.Value,
                                uid = token.Claims.FirstOrDefault(c => c.Type == "name_en")?.Value,
                                pccuid = token.Claims.FirstOrDefault(c => c.Type == "pccuid")?.Value,
                                sub = token.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value,
                                email = token.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value
                            };

                            // 自動更新 Token
                            var newToken = await RefreshToken(pdmToken, userInfo);

                            return APIResponseHelper.GenerateApiResponse(
                                "OK",
                                "Token 已自動更新",
                                new
                                {
                                    NewToken = newToken,
                                    ExpiresAt = DateTime.UtcNow.AddHours(1).ToLocalTime()
                                }).Result;
                        }
                        catch
                        {
                            // 如果自動更新失敗，返回即將過期的警告
                            return APIResponseHelper.GenerateApiResponse(
                                ((int)AuthenticationStatus.TokenNearExpiry).ToString(),
                                "Token 即將過期，請手動更新",
                                new
                                {
                                    RemainingMinutes = Math.Round(remainingTime.TotalMinutes, 0),
                                    ExpiresAt = token.ValidTo.ToLocalTime()
                                }).Result;
                        }
                    }

                    // Token 有效
                    return APIResponseHelper.GenerateApiResponse(
                        "OK",  // 使用 "OK" 而不是數字
                        "已登入",
                        new
                        {
                            RemainingMinutes = Math.Round(remainingTime.TotalMinutes, 0),
                            ExpiresAt = token.ValidTo.ToLocalTime()
                        }).Result;
                }

                // 檢查 SSO Token
                if (!string.IsNullOrEmpty(accessToken))
                {
                    var ssoValidationResult = await ValidateSSOToken(accessToken);
                    return APIResponseHelper.GenerateApiResponse(
                        ssoValidationResult.ErrorCode,
                        ssoValidationResult.Message,
                        ssoValidationResult.Data).Result;
                }

                return APIResponseHelper.HandleApiError<object>(
                    AuthenticationStatus.NotAuthenticated.ToString(),
                    "無有效的登入狀態").Result;
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<object>(
                    "50001",
                    $"檢查登入狀態時發生錯誤：{ex.Message}").Result;
            }
        }

        /// <summary>
        /// 登入資料回拋，交換Token、並返回用戶資料
        /// </summary>
        [AllowAnonymous]
        [HttpGet("callback")]
        //public async Task<IActionResult> Callback([FromQuery] string code, [FromQuery] string state)
        public async Task<IActionResult> Callback()
        {
            var authResult = await HttpContext.AuthenticateAsync(OpenIdConnectDefaults.AuthenticationScheme);
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");
            var expiresAtStr = await HttpContext.GetTokenAsync("expires_at");
            if (string.IsNullOrEmpty(accessToken))
            {
                return BadRequest(new { error = "Access Token not found" });
            }
            //return Ok(new { message = "Login successful", accessToken, idToken });

            // **呼叫 SSO userinfo API取得該使用者資訊**
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var userInfoEndpoint = $"{_config.Authority}/protocol/openid-connect/userinfo";
            var response = await httpClient.GetAsync(userInfoEndpoint);
            var userInfoJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(new { error = "Failed to fetch user info", details = userInfoJson });
            }

            //解析userinfo JSON
            var userInfo = JsonSerializer.Deserialize<UserInfo>(userInfoJson);

            if (string.IsNullOrWhiteSpace(userInfo.pccuid) || !decimal.TryParse(userInfo.pccuid, out decimal pccuid))
            {
                return BadRequest(new { error = "Invalid PCCUID format" });
            }
            //抓取userinfo後判斷是否有存在DB，有就update last_login，沒有就新增
            var user = await _pdmUsersRepository.GetByPccuid(pccuid);
            if (user == null)
            {
                user = new pdm_users
                {
                    pccuid = pccuid, // 這裡使用 decimal
                    username = userInfo.family_name,
                    local_name = userInfo.family_name + "(" + userInfo.uid.ToUpper() + ")",
                    sso_acct = userInfo.uid.ToUpper(),
                    email = userInfo.email,
                    password_hash = BCrypt.Net.BCrypt.HashPassword(userInfo.pccuid.ToString()), //必要時可以用BCrypt.Verify來驗證密碼,可以設定編碼強度4-14僅接受偶數，如 password_hash = BCrypt.Net.BCrypt.HashPassword(userInfo.pccuid.ToString(), workFactor: 12);
                    keycloak_iam_sub = userInfo.sub,
                    //keycloak_iam_sub = Guid.NewGuid().ToString(),
                    last_login = DateTime.UtcNow,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow
                };
                await _pdmUsersRepository.AddUser(user);
            }
            else
            {
                user.last_login = DateTime.UtcNow;
                user.updated_at = DateTime.UtcNow;
                await _pdmUsersRepository.UpdateUser(user);
            }

            // 產生後端自訂的JWT Token
            var userToken = GenerateJwtToken(userInfo, expiresAtStr, user.user_id);

            // 設定 cookie 選項
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true, // 防止 JavaScript 存取
                Secure = true,   // 若使用 HTTPS 就設定 true
                SameSite = SameSiteMode.Lax, // 根據需求調整
                Expires = DateTimeOffset.UtcNow.AddHours(1) // 與 JWT 的過期時間一致
            };

            // 將JWT寫入cookie，這裡cookie名稱可以自訂，例如"PDMToken"
            HttpContext.Response.Cookies.Append("PDMToken", userToken, cookieOptions);
            //回傳給前端
            /*
            return Ok(new
            {
                message = "Login successful",
                PDMtoken = userToken,
                userInfo
            });*/
            //return Redirect("/api/auth/close-window");轉址導向別的API
            // 回傳 HTML 給前端，並執行 window.close()

            return Content($@"
                                <!DOCTYPE html>
                                <html lang='zh'>
                                <head>
                                    <meta charset='UTF-8'>
                                </head>
                                <body>
                                    <script>
                                        window.location.replace('https://pcms-mif-test01.pouchen.com/PDM/');
                                    </script>
                                </body>
                                </html>
                                ", "text/html", System.Text.Encoding.UTF8);

        }


        /// <summary>
        /// 登出，讓前端登出並清除登入狀態
        /// </summary>
        [AllowAnonymous]
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            /*
            var idToken = await HttpContext.GetTokenAsync("id_token");
            if (string.IsNullOrEmpty(idToken))
            {
                return BadRequest(new { error = "ID Token not found" });
            }*/
            Response.Cookies.Delete("PDMToken");
            var authProperties = new AuthenticationProperties
            {
                RedirectUri = _config.PostLogoutRedirectUri
            };


            return SignOut(authProperties, CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme);

        }



        // UserInfo 類別
        public class UserInfo
        {
            public string pccuid { get; set; }
            public string sub { get; set; }
            public string uid { get; set; }             //小寫英文名 如 jack.yu
            public string employee_type { get; set; }  //"01-集團員工"
            public bool email_verified { get; set; } = false; //預設false
            public string family_name { get; set; } //中文姓名
            public string email { get; set; }  //mail
        }

        // 產生JWT Token
        private string GenerateJwtToken(UserInfo user, string expiresAtStr, long userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            if (string.IsNullOrEmpty(_jwtSecret))
            {
                throw new Exception("JWT Secret is not configured!");
            }
            var claims = new[]
            {
                new Claim("name", user.family_name.ToString()),
                new Claim("name_en", user.uid.ToString()),
                new Claim("pccuid", user.pccuid.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.sub),
                new Claim(JwtRegisteredClaimNames.Email, user.email),
                new Claim("expires_at", expiresAtStr),
                //new Claim("email_verified", user.email_verified.ToString()) // 轉成 string
                new Claim("user_id", userId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "PDMAppissu",
                audience: "testclient",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // 自訂token過期時效
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // 1. 首先定義登入狀態枚舉
        public enum AuthenticationStatus
        {
            NotAuthenticated = 40001,    // 未登入
            TokenExpired = 40002,        // Token 過期
            InvalidToken = 40003,        // Token 無效
            TokenNearExpiry = 40004,     // Token 即將過期
            Authenticated = 0        // 已登入
        }

        // 2. 建立統一的狀態處理類
        public class AuthenticationResult
        {
            public AuthenticationStatus Status { get; set; }
            public string Message { get; set; }
            public object Data { get; set; }
            public string ErrorCode => ((int)Status).ToString();
        }

        // 4. Token 驗證輔助方法
        private async Task<(bool isValid, JwtSecurityToken token, AuthenticationResult validationResult)> ValidateTokenWithCache(string token)
        {
            var cacheKey = $"token_validation_{token}";

            // 嘗試從快取中獲取
            if (_cache.TryGetValue(cacheKey, out var cachedResult))
            {
                return ((ValueTuple<bool, JwtSecurityToken, AuthenticationResult>)cachedResult);
            }

            // 執行實際驗證
            var result = ValidateToken(token);

            // 如果驗證成功，存入快取
            if (result.isValid)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                _cache.Set(cacheKey, result, cacheEntryOptions);
            }

            return result;
        }

        /// <summary>
        /// 驗證 SSO Token
        /// </summary>
        private async Task<AuthenticationResult> ValidateSSOToken(string accessToken)
        {
            try
            {
                // 使用 HttpClientFactory 而不是直接 new HttpClient
                var httpClient = _httpClientFactory.CreateClient("SSOValidation");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                // 使用 Keycloak 的 userinfo 端點驗證 token
                var userInfoEndpoint = $"{_config.Authority}/protocol/openid-connect/userinfo";
                var response = await httpClient.GetAsync(userInfoEndpoint);

                if (response.IsSuccessStatusCode)
                {
                    var userInfo = await JsonSerializer.DeserializeAsync<UserInfo>(
                        await response.Content.ReadAsStreamAsync());

                    // 檢查是否成功獲取用戶信息
                    if (userInfo != null)
                    {
                        return new AuthenticationResult
                        {
                            Status = AuthenticationStatus.Authenticated,
                            Message = "SSO 驗證成功",
                            Data = new
                            {
                                TokenType = "SSO",
                                Pccuid = userInfo.pccuid,
                                Email = userInfo.email
                            }
                        };
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return new AuthenticationResult
                    {
                        Status = AuthenticationStatus.TokenExpired,
                        Message = "SSO Token 已過期",
                        Data = null
                    };
                }

                return new AuthenticationResult
                {
                    Status = AuthenticationStatus.InvalidToken,
                    Message = "SSO Token 無效",
                    Data = null
                };
            }
            catch (HttpRequestException ex)
            {
                return new AuthenticationResult
                {
                    Status = AuthenticationStatus.InvalidToken,
                    Message = $"SSO 驗證請求失敗: {ex.Message}",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new AuthenticationResult
                {
                    Status = AuthenticationStatus.InvalidToken,
                    Message = $"SSO Token 驗證過程發生錯誤: {ex.Message}",
                    Data = null
                };
            }
        }

        // 添加 ValidateToken 方法
        private (bool isValid, JwtSecurityToken token, AuthenticationResult validationResult) ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSecret);

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = "PDMAppissu",
                    ValidAudience = "testclient"
                };

                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return (true, (JwtSecurityToken)validatedToken, null);
            }
            catch (SecurityTokenExpiredException)
            {
                return (false, null, new AuthenticationResult
                {
                    Status = AuthenticationStatus.TokenExpired,
                    Message = "Token 已過期"
                });
            }
            catch (Exception)
            {
                return (false, null, new AuthenticationResult
                {
                    Status = AuthenticationStatus.InvalidToken,
                    Message = "Token 無效"
                });
            }
        }

        // 添加 Token 更新方法
        private async Task<string> RefreshToken(string oldToken, UserInfo userInfo)
        {
            try
            {
                // 解析舊的 Token 以獲取必要信息
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(oldToken);

                // 從 Token 中獲取用戶 ID
                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "user_id");
                if (userIdClaim == null || !long.TryParse(userIdClaim.Value, out long userId))
                {
                    throw new Exception("無法從 Token 中獲取用戶 ID");
                }

                // 獲取新的過期時間
                var expiresAt = DateTime.UtcNow.AddHours(1).ToString("o");

                // 生成新的 Token
                var newToken = GenerateJwtToken(userInfo, expiresAt, userId);

                // 更新 Cookie
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Lax,
                    Expires = DateTimeOffset.UtcNow.AddHours(1)
                };
                HttpContext.Response.Cookies.Delete("PDMToken");
                HttpContext.Response.Cookies.Append("PDMToken", newToken, cookieOptions);

                return newToken;
            }
            catch (Exception ex)
            {
                throw new Exception($"更新 Token 時發生錯誤: {ex.Message}");
            }
        }

        // 可以呼叫的 更新Token的API
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenEndpoint()
        {
            try
            {
                var currentToken = HttpContext.Request.Cookies["PDMToken"];
                if (string.IsNullOrEmpty(currentToken))
                {
                    return APIResponseHelper.HandleApiError<object>(
                        ((int)AuthenticationStatus.NotAuthenticated).ToString(),
                        "未找到 Token").Result;
                }

                // 驗證當前 Token
                var (isValid, token, validationResult) = await ValidateTokenWithCache(currentToken);
                if (!isValid)
                {
                    return APIResponseHelper.HandleApiError<object>(
                        ((int)AuthenticationStatus.InvalidToken).ToString(),
                        "Token 無效").Result;
                }

                // 從 Token 中獲取用戶信息
                var userInfo = new UserInfo
                {
                    family_name = token.Claims.FirstOrDefault(c => c.Type == "name")?.Value,
                    uid = token.Claims.FirstOrDefault(c => c.Type == "name_en")?.Value,
                    pccuid = token.Claims.FirstOrDefault(c => c.Type == "pccuid")?.Value,
                    sub = token.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value,
                    email = token.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value
                };

                // 更新 Token
                var newToken = await RefreshToken(currentToken, userInfo);

                return APIResponseHelper.GenerateApiResponse(
                    "OK",
                    "Token 已更新",
                    new { token = newToken }).Result;
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<object>(
                    "50001",
                    $"更新 Token 時發生錯誤：{ex.Message}").Result;
            }
        }
    }

}