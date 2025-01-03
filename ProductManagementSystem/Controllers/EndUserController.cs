using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiCore.Dto;

using AllServices.Order;

namespace ProductManagementSystem.Controllers
{
    [ApiController]
    [Authorize(Roles = "EndUser")]
    [Route("[Controller]/[action]")]
    
    public class EndUserController : Controller
    {
        private IOrderService _orderService;
        public EndUserController(IOrderService orderService) {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult ViewProducts(int StartPrice = int.MinValue,int EndPrice = int.MaxValue)
        {
            var result = _orderService.GetProducts(StartPrice,EndPrice);
            System.Console.WriteLine(result);
            return Ok(result);
        }

        public IActionResult InventoryStatus() {
            //return the x left or out of stock

            return View();
        }
        public IActionResult CreateOrder() {
            //if in stock then should be able to create the order
            //here we need the locks on db
            return View();
        }

    }
}
