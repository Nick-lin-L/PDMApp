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

namespace PDMApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly OAuthConfig _config;
        private readonly string _jwtSecret;
        private readonly PdmUsersRepository _pdmUsersRepository;
        public AuthController(IOptions<OAuthConfig> config, IConfiguration configuration, PdmUsersRepository pdmUsersRepository)
        {
            _config = config.Value;
            _jwtSecret = configuration["Authentication:PCG:ClientSecret"];
            _pdmUsersRepository = pdmUsersRepository; // 初始化 Repository
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
            /*/
            var redirectUri = Url.Action("Callback", "Auth", null, Request.Scheme);
            var loginUrl = $"{_config.Authority}/protocol/openid-connect/auth?client_id={_config.ClientId}&redirect_uri={redirectUri}&response_type=code&scope=openid profile email";

            return Ok(new { loginUrl });
            //*/

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

                var userProfile = new
                {
                    UserId = user.user_id,
                    Pccuid = user.pccuid,
                    Username = user.username,
                    LocalName = user.local_name,
                    Email = user.email,
                    LastLogin = user.last_login?.ToLocalTime(), // 轉換為本地時間
                    IsActive = true // 如果能夠取得資料，代表用戶是活躍的
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
                var accessToken = await HttpContext.GetTokenAsync("access_token");

                // 如果兩個 token 都不存在
                if (string.IsNullOrEmpty(pdmToken) && string.IsNullOrEmpty(accessToken))
                {
                    return APIResponseHelper.HandleApiError<object>("401", "未登入").Result;
                }

                // 驗證 PDMToken
                if (!string.IsNullOrEmpty(pdmToken))
                {
                    try
                    {
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.UTF8.GetBytes(_jwtSecret);
                        
                        tokenHandler.ValidateToken(pdmToken, new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ClockSkew = TimeSpan.Zero,
                            ValidIssuer = "PDMAppissu",
                            ValidAudience = "testclient"
                        }, out SecurityToken validatedToken);

                        var jwtToken = (JwtSecurityToken)validatedToken;
                        
                        // 返回基本身份資訊
                        var authInfo = new
                        {
                            IsAuthenticated = true,
                            TokenType = "PDM",
                            Pccuid = jwtToken.Claims.FirstOrDefault(c => c.Type == "pccuid")?.Value,
                            Email = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value,
                            ExpiresAt = validatedToken.ValidTo.ToLocalTime()
                        };

                        return APIResponseHelper.GenerateApiResponse("OK", "已登入", authInfo).Result;
                    }
                    catch (SecurityTokenExpiredException)
                    {
                        return APIResponseHelper.HandleApiError<object>("401", "登入已過期").Result;
                    }
                    catch (Exception)
                    {
                        // PDMToken 無效，繼續檢查 SSO Token
                    }
                }

                // 檢查 SSO Token
                if (!string.IsNullOrEmpty(accessToken))
                {
                    using var httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    var userInfoEndpoint = "https://iamlab.pouchen.com/auth/realms/pcg/protocol/openid-connect/userinfo";
                    var response = await httpClient.GetAsync(userInfoEndpoint);

                    if (response.IsSuccessStatusCode)
                    {
                        var userInfo = JsonSerializer.Deserialize<UserInfo>(await response.Content.ReadAsStringAsync());
                        var authInfo = new
                        {
                            IsAuthenticated = true,
                            TokenType = "SSO",
                            Pccuid = userInfo.pccuid,
                            Email = userInfo.email
                        };

                        return APIResponseHelper.GenerateApiResponse("OK", "已登入(SSO)", authInfo).Result;
                    }
                }

                return APIResponseHelper.HandleApiError<object>("401", "登入狀態無效").Result;
            }
            catch (Exception ex)
            {
                return APIResponseHelper.HandleApiError<object>("500", $"檢查登入狀態時發生錯誤：{ex.Message}").Result;
            }
        }
        /*
        [Authorize]
        [HttpGet("login-status")]
        public async Task<IActionResult> LoginStatus() 
        {
            // 1. Check if the user is authenticated
            if (!User.Identity.IsAuthenticated)
            {
                // No valid authentication (no cookie or invalid token)
                return Unauthorized(new { authenticated = false });
            }

            // 2. User is authenticated, retrieve current access token and refresh token
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
            var expiresAtStr = await HttpContext.GetTokenAsync("expires_at");  // stored as a string if SaveTokens = true
            DateTimeOffset? expiresAt = null;
            if (!string.IsNullOrEmpty(expiresAtStr))
                expiresAt = DateTimeOffset.Parse(expiresAtStr);

            string username = User.Identity.Name ?? User.FindFirst("preferred_username")?.Value;

            // 3. Validate access token expiration
            bool tokenExpired = false;
            if (expiresAt.HasValue)
            {
                tokenExpired = DateTimeOffset.UtcNow >= expiresAt.Value;
            }
            else
            {
                // If we don't have an "expires_at", we could fall back to introspecting the token or checking JWT exp claim.
                // e.g., decode JWT and check its 'exp' claim against current time.
            }

            if (!tokenExpired)
            {
                // Access token is still valid
                return Ok(new { authenticated = true, username = username });
            }

            // 4. If access token is expired, attempt to use the refresh token
            if (!string.IsNullOrEmpty(refreshToken))
            {
                // Call Keycloak token endpoint to refresh the access token
                // (grant_type=refresh_token, using client credentials and the refresh token)
                var newTokenResponse = await KeycloakTokenService.RefreshAsync(refreshToken);
                if (newTokenResponse.IsSuccess)
                {
                    // Extract the new tokens from Keycloak's response
                    string newAccessToken = newTokenResponse.AccessToken;
                    string newRefreshToken = newTokenResponse.RefreshToken;
                    int newExpiresIn = newTokenResponse.ExpiresIn; // e.g., seconds until expiration

                    // (Optional) Update the authentication cookie with new tokens so future requests use the new access token
                    var authInfo = await HttpContext.AuthenticateAsync();
                    authInfo.Properties.UpdateTokenValue("access_token", newAccessToken);
                    authInfo.Properties.UpdateTokenValue("refresh_token", newRefreshToken);
                    var newExpiresAt = DateTimeOffset.UtcNow.AddSeconds(newExpiresIn).ToString("o");
                    authInfo.Properties.UpdateTokenValue("expires_at", newExpiresAt);
                    await HttpContext.SignInAsync(authInfo.Principal, authInfo.Properties);

                    // Return the new access token to the client (if the client needs to know it)
                    return Ok(new
                    {
                        authenticated = true,
                        username = username,
                        accessToken = newAccessToken
                    });
                }
            }

            // 5. If we cannot refresh (no refresh token or refresh token also expired/invalid)
            return Unauthorized(new
            {
                authenticated = false,
                error = "Access token expired"
            });
        }
        */

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
    }

}