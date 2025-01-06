using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dto;

namespace AllServices.ExternalProviders
{
    public abstract class BaseProvider
    {
        public abstract Boolean BookProduct(ProductOrder orderDetails);
        public abstract Boolean GetProductsFromProvider();//specifc for each
    }
}
