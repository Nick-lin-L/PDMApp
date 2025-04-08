using Microsoft.AspNetCore.Http;
using PDMApp.Utils.BasicProgram;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PDMApp.Service.Basic
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public long? UserId => TryParseLong(GetClaim("user_id"));
        public string PccUid => GetClaim("pccuid");
        public string Email => GetClaim(JwtRegisteredClaimNames.Email);
        public string Name => GetClaim("name");
        public string NameEn => GetClaim("name_en");

        private string GetClaim(string type)
        {
            return User?.FindFirst(type)?.Value;
        }

        private long? TryParseLong(string value)
        {
            return long.TryParse(value, out var result) ? result : (long?)null;
        }
    }
}