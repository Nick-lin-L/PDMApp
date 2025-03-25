using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace PDMApp.Utils.BasicProgram
{
    public class CurrentUser
    {
        public long? Pccuid { get; set; }
        public long? UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
    }

    public static class CurrentUserUtils
    {
        public static CurrentUser Get(HttpContext httpContext)
        {
            if (httpContext == null || httpContext.User == null)
                return null;

            var claims = httpContext.User.Claims;

            long.TryParse(claims.FirstOrDefault(c => c.Type == "pccuid")?.Value, out var pccuid);
            long.TryParse(claims.FirstOrDefault(c => c.Type == "user_id")?.Value, out var userId);
            var email = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value;
            var name = claims.FirstOrDefault(c => c.Type == "name")?.Value;
            var nameen = claims.FirstOrDefault(c => c.Type == "name_en")?.Value;

            return new CurrentUser
            {
                Pccuid = pccuid != 0 ? pccuid : (long?)null,
                UserId = userId != 0 ? userId : (long?)null,
                Email = email,
                Name = name,
                NameEn = nameen
            };
        }
    }
}
