using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PDMApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SSOLoginController : ControllerBase
    {
        // GET: api/<SSOLoginController>
        [HttpGet("login")]
        public IActionResult Login(string returnUrl= "/")
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectDefaults.AuthenticationScheme);

        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            return SignOut(new AuthenticationProperties { RedirectUri = "/" }, CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme);

        }

        // POST api/<SSOLoginController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SSOLoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SSOLoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
