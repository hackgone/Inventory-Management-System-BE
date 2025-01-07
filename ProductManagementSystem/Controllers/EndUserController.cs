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
        private IProductService _productService;
        public EndUserController(IProductService orderService) {
            _productService = orderService;
        }

        [HttpGet]
        public IActionResult ViewProducts(int StartPrice = int.MinValue,int EndPrice = int.MaxValue)
        {
            var result = _productService.GetProducts(StartPrice,EndPrice);
            System.Console.WriteLine(result);
            return Ok(result);
        }

        public IActionResult InventoryStatus() {
            //return the x left or out of stock
            var res = _productService.GetProductInventoryStatus();
            System.Console.WriteLine(res);

            return Ok(res);
        }
        //[FromBody] OrderDetails request
        public IActionResult CreateOrder() {
            //if in stock then should be able to create the order
            //here we need the locks on db
            this._productService.CreateOrder();
            return Ok();
        }

    }
}
