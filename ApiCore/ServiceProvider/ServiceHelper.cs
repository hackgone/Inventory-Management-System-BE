using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCore.ServiceProvider
{
    public class ServiceHelper:IServiceHelper
    {
        private readonly IServiceProvider _serviceProvider;
        public ServiceHelper(IServiceProvider serviceProvider)
        {
            _serviceProvider=serviceProvider;
        }
        public T GetSpecificService<T>(Type childClass = null)
        {
            if (childClass != null)
            {
                return (T)_serviceProvider.GetService(childClass);//it is used when there is a case of multiple inhertance 
            }
            return _serviceProvider.GetService<T>();// for normal Interface and normal DI
        }
    }
}
