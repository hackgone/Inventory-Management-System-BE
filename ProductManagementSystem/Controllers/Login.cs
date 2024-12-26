using AllServices.DbTestService;
using ApiCore.Entity;
using Microsoft.AspNetCore.Mvc;
using AllServices.DbService;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    [Route("/Login")]
    public class Login : Controller
    {   
        private IDbService<User> _dbservice;
        public Login(IDbService<User> dbservice) { 
            _dbservice = dbservice;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = this._dbservice.GetAllData();
            return Json(data);
        }
    }
}
