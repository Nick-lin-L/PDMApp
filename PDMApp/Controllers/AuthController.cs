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
using Bartata.NET.WebForm;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace PDMApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly OAuthConfig _config;

        public AuthController(IOptions<OAuthConfig> config)
        {
            _config = config.Value;
        }

        /// <summary>
        /// 取得登入 URL，讓前端重定向至 IAM 登入頁面
        /// </summary>
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
        /// 取得目前登入的用戶資訊 (含Token) 
        /// </summary>
        [HttpGet("me")]
        public async Task<IActionResult> GetUserInfo()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { error = "User not authenticated" });
            }

            // 從當前 HttpContext 取得 `access_token`
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { error = "Access Token not found" });
            }

            // 1?? 呼叫 IAM 的 `userinfo` API
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var userInfoEndpoint = "https://iamlab.pouchen.com/auth/realms/pcg/protocol/openid-connect/userinfo";
            var response = await httpClient.GetAsync(userInfoEndpoint);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(new { error = "Failed to fetch user info", details = responseBody });
            }

            // 解析 userinfo API 的回應，回傳給前端
            return Ok(new { message = "User Info Retrieved", data = responseBody });
        }

        [HttpGet("me-info")]
        public IActionResult GetUserInfo2()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok(new
                {
                    Username = User.Identity.Name,
                    Email = User.Claims.FirstOrDefault(c => c.Type == "email")?.Value,
                    AccessToken = HttpContext.GetTokenAsync("access_token").Result,
                    IdToken = HttpContext.GetTokenAsync("id_token").Result
                });
            }
            return Unauthorized(new { error = "User not authenticated" });
        }



        /// <summary>
        /// 登入資料回拋，交換Token、並返回用戶資料
        /// </summary>
        [HttpGet("callback")]
        //public async Task<IActionResult> Callback()
        public async Task<IActionResult> Callback([FromQuery] string code, [FromQuery] string state)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");

            if (string.IsNullOrEmpty(accessToken))
            {
                return BadRequest(new { error = "Access Token not found" });
            }
            //return Ok(new { message = "Login successful", accessToken, idToken });

            // **呼叫 SSO `userinfo` API 取得使用者資訊**
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var userInfoEndpoint = $"{_config.Authority}/protocol/openid-connect/userinfo";
            var response = await httpClient.GetAsync(userInfoEndpoint);
            var userInfoJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(new { error = "Failed to fetch user info", details = userInfoJson });
            }

            //var userInfo = JsonSerializer.Deserialize<Dictionary<string, object>>(userInfoJson);
            //解析 userinfo
            var userInfo = JsonSerializer.Deserialize<UserInfo>(userInfoJson);

            //產生後端 JWT Token
            var userToken = GenerateJwtToken(userInfo);

            //回傳給前端
            return Ok(new
            {
                message = "Login successful",
                token = userToken,
                userInfo
            });
        }

        /// <summary>
        /// 登出，讓前端登出並清除登入狀態
        /// </summary>
        [HttpGet("logout")]
        public IActionResult Logout()
        {
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
            public string uid { get; set; }
            public string employee_type { get; set; }
            public bool email_verified { get; set; }
            public string family_name { get; set; }
            public string email { get; set; }
            
        }

        // 產生JWT Token
        private static string GenerateJwtToken(UserInfo user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TZfdvTadlOOVA7YKZ0ngKkT0rOm9AJqD"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("pccuid", user.pccuid),
                new Claim(JwtRegisteredClaimNames.Sub, user.sub),
                new Claim(JwtRegisteredClaimNames.Email, user.email),
                new Claim("email_verified", user.email_verified.ToString()) // 轉成 string
            };

            var token = new JwtSecurityToken(
                issuer: "your-api",
                audience: "your-client",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}