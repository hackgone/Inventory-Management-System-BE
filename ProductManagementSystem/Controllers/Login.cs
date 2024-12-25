using AllServices.DbTestService;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    [Route("/Login")]
    public class Login : Controller
    {   
        private IUserDbTest _dbservice;
        public Login(IUserDbTest dbservice) { 
            _dbservice = dbservice;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = this._dbservice.GetUsers();
            return Json(data);
        }
    }
}
