using Microsoft.AspNetCore.Mvc;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class SuperUserController : Controller
    {
        public IActionResult DeleteProduct()
        {
            //make the delete check on with this
            return View();
        }
        public IActionResult EditProduct()
        {
            //change the name/price/decription 
            return View();
        }
    }
}
