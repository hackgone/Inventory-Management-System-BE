using AllServices.AuthService;
using ApiCore.Dto;
using ApiCore.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AllServices.JWTService;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private readonly IConfiguration _configuration;
        private IJwtProvider _jwtProvider;
        public AuthController(IAuthService authService, IConfiguration configuration,IJwtProvider jwtProvider) { 
            _authService = authService;
            _configuration = configuration;
            _jwtProvider = jwtProvider;
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
            var res = await _authService.FindUserByEmail(request.Email);
            

            if (res == null)
            {
                throw new UnauthorizedAccessException("Invalid User Email");
            }

            return await _jwtProvider.GetJwtToken(request.Email,request.Name,request.UserRole,res) ;
        }


    }
}
