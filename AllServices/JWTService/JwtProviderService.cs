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
using Microsoft.Extensions.Configuration;

namespace AllServices.JWTService
{
    public class JwtProviderService: IJwtProvider
    {
        private readonly IConfiguration _configuration;
        public JwtProviderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetJwtToken(string Email,string UserName,string Userrole,int UserId)
        {
            
             var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("UserID", UserId.ToString()), 
                new Claim("UserName", UserName), 
                new Claim("Email", Email) ,      
                new Claim(ClaimTypes.Role,Userrole)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}
