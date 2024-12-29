using AllServices.AuthService;
using ApiCore.Dto;
using ApiCore.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    public class Auth : Controller
    {
        private IAuthService _authService;
        public Auth(IAuthService authService) { 
            _authService = authService;
        }

        [Route("signup")]
        [HttpGet]
        public async Task<IActionResult> Signup([FromBody] Login request)
        {
            await _authService.SaveUserCred(request);
            return Ok();
        }
    }
}
