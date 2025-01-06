using AllServices.DbService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Entity;
using ApiCore.Dto;
using AllServices.ExternalProviders;
using ApiCore.ServiceProvider;

namespace AllServices.Order
{
    public class ProductService:IProductService
    {
        private readonly IDbService<Product> _ProductdbService;
        private readonly IDbService<ProductInventory> _ProductinventorydbService;
        private readonly IServiceHelper _serviceHelper;
        public ProductService(IDbService<Product> dbService , IDbService<ProductInventory> ProductInventory, IServiceHelper serviceHelper) { 
            this._ProductdbService = dbService;
            this._ProductinventorydbService = ProductInventory;
            this._serviceHelper = serviceHelper;    
        }
        public List<Product> GetProducts(int StartPrice , int EndPrice)
        {
            return this._ProductdbService.GetAllData().Where(x => x.Deleted == false && x.Price >= StartPrice && x.Price <= EndPrice).ToList();
        }
        public List<ProductInventory> GetProductInventoryStatus()
        {
            
            var res =  this._ProductinventorydbService.JoinData(x => x.product).ToList();
            return res;

        }
        public void CreateOrder()
        {
            ProductOrder order = new ProductOrder(
                "P@p.com",
                "123@123",
                1
            );
            var res = _serviceHelper.GetSpecificService<BaseProvider>(typeof(Amazon)).BookProduct(order);
        }
    }
}
