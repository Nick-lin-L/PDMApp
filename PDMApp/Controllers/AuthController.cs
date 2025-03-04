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
                //RedirectUri = _config.RedirectUri
                RedirectUri = Url.Action("Callback", "Auth", null, Request.Scheme) // 動態設定 Callback
            };

            // 傳回登入 URL，供前端重定向
            return Challenge(authProperties, OpenIdConnectDefaults.AuthenticationScheme);
        }


        /// <summary>
        /// 登入資料回拋，交換Token、並返回用戶資料 OIDC
        /// </summary>
        /*
        [HttpGet("signin-oidc")]
        public IActionResult SigninOidc()
        {
            var authProperties = new AuthenticationProperties
            {
                RedirectUri = _config.RedirectUri
            };

            // 傳回登入 URL，供前端重定向
            return Challenge(authProperties, OpenIdConnectDefaults.AuthenticationScheme);
        }*/


        /// <summary>
        /// 登入資料回拋，交換Token、並返回用戶資料
        /// </summary>
        [HttpGet("callback")]
        //public async Task<IActionResult> Callback()
        public async Task<IActionResult> Callback([FromQuery] string state)
        {
            var uuid = Request.Query["uid"];    
            var code = Request.Query["code"];
            var State = Request.Query["state"];
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = await HttpContext.GetTokenAsync("id_token");

            if (string.IsNullOrEmpty(accessToken))
            {
                return BadRequest(new { error = "Authorization accessToken is missing" });
            }

            var tokenEndpoint = $"{_config.Authority}/protocol/openid-connect/token";
            //https://iamlab.pouchen.com/auth/realms/pcg/protocol/openid-connect/userinfo 使用者帳戶資訊API
            var clientId = _config.ClientId;
            var clientSecret = _config.ClientSecret;
            var redirectUri = _config.RedirectUri;

            using var httpClient = new HttpClient();
            var requestBody = new FormUrlEncodedContent(new Dictionary<string, string>
                            {
                                { "grant_type", "authorization_code" },
                                { "client_id", clientId },
                                { "client_secret", clientSecret },
                                { "code", code },
                                { "redirect_uri", redirectUri }
                            });

            var response = await httpClient.PostAsync(tokenEndpoint, requestBody);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(new { error = "Failed to exchange code for access token", details = responseContent });
            }

            return Ok(new { message = "Login successful", tokens = responseContent });
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