using AllServices.DbService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Entity;
using ApiCore.Dto;

namespace AllServices.Order
{
    public class OrderService:IOrderService
    {
        private readonly IDbService<Product> _dbService;
        public OrderService(IDbService<Product> dbService) { 
            this._dbService = dbService;
        }
        public List<Product> GetProducts(int StartPrice , int EndPrice)
        {
            return this._dbService.GetAllData().Where(x => x.Deleted == false && x.Price >= StartPrice && x.Price <= EndPrice).ToList();
        }
        public List<> GetInventoryStatus
    }
}
