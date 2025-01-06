using AllServices.DbService;
using ApiCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dto;

namespace AllServices.ExternalProviders
{
    public class Amazon:BaseProvider
    {
        private IDbService<ProductInventory> _dbInventory;
        public Amazon(IDbService<ProductInventory> dbInventory) { 
            this._dbInventory = dbInventory;
        }
        public override Boolean BookProduct(ProductOrder orderDetails)
        {
            if (this.dummyCreateOrder())
            {
                List<ProductInventory> response =  this._dbInventory.GetUserByExp(x =>x.ProductId == orderDetails.ProductID).ToList();
                response.ForEach(x => x.AvailableQuantity -= 1);
                response.ForEach(item => this._dbInventory.UpdateEntity(item));
                return true;
            }
            return false;
        }
        public Boolean dummyCreateOrder()
        {
            //It will create external call and make the request to vendor side api
            return true;
        }
        public override Boolean GetProductsFromProvider()
        {
            return true;
        }
    }
}
