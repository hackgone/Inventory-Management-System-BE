using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dto;
using ApiCore.Entity;


namespace AllServices.Order
{
    public interface IProductService
    {
        public List<Product> GetProducts(int StartPrice = int.MinValue, int EndPrice = int.MinValue);
        public List<ProductInventory> GetProductInventoryStatus();
        public void CreateOrder();
    }
}
