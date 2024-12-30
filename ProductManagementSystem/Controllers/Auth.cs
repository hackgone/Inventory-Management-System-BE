using AllServices.AuthService;
using ApiCore.Dto;
using ApiCore.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    public class Auth : Controller
    {
        private IAuthService _authService;
        private readonly IConfiguration _configuration;
        public Auth(IAuthService authService, IConfiguration configuration) { 
            _authService = authService;
            _configuration = configuration;
        }

        [Route("signup")]
        [HttpGet]
        public async Task<IActionResult> Signup([FromBody] Login request)
        {
            await _authService.SaveUserCred(request);
            return Ok();
        }
        [Route("login")]
        [HttpGet]
        public async Task<string> Login([FromBody] Login request)
        {
            // Find user by email (ensure this method is awaited)
            var res = await _authService.FindUserByEmail(request.Email);

            if (res == null)
            {
                throw new UnauthorizedAccessException("Invalid login credentials.");
            }

            // Create claims
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        new Claim("Id", "123"), // Use actual user data
        new Claim("UserName", "123"), // Use actual user data
        new Claim("Email", "123")       // Use actual user data
    };

            // Create key and signing credentials
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create the token
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            // Serialize the token
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            // Return the token as Task<string>
            return jwtToken;
        }


    }
}
