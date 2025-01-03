using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dto;
using ApiCore.Entity;


namespace AllServices.Order
{
    public interface IOrderService
    {
        public List<Product> GetProducts(int StartPrice = int.MinValue, int EndPrice = int.MinValue);
    }
}
