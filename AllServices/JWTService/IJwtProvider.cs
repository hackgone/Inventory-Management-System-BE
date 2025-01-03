using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AllServices.JWTService
{
    public interface IJwtProvider
    {
        public Task<string> GetJwtToken(string Email, string UserName, string Userrole, int UserId);
    }
}
