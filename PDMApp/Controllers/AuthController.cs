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
using System.Threading.Tasks;

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
            var authProperties = new AuthenticationProperties
            {
                RedirectUri = _config.RedirectUri
            };

            // 傳回登入 URL，供前端重定向
            return Challenge(authProperties, OpenIdConnectDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// 取得目前登入的用戶資訊 (含Token) 
        /// </summary>
        [HttpGet("me")]
        public async Task<IActionResult> GetUserInfo()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");

            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { error = "No valid token found" });
            }

            return Ok(new
            {
                User = HttpContext.User.Identity.Name,
                AccessToken = accessToken,
                IdToken = idToken
            });
        }

        /// <summary>
        /// 登入資料回拋，交換Token、並返回用戶資料
        /// </summary>
        [HttpGet("callback")]
        public async Task<IActionResult> Callback()
        {
            // 驗證結果
            var authResult = await HttpContext.AuthenticateAsync(OpenIdConnectDefaults.AuthenticationScheme);

            if (!authResult.Succeeded)
            {
                return Unauthorized(new { error = "Authentication failed" });
            }

            // 取得 Token
            var accessToken = authResult.Properties.GetTokenValue("access_token");
            var idToken = authResult.Properties.GetTokenValue("id_token");
            Console.WriteLine($"AccessToken: {accessToken}");
            Console.WriteLine($"IdToken: {idToken}");
            // 回傳 Token 給前端
            return Ok(new
            {
                AccessToken = accessToken,
                IdToken = idToken
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
    }

}