using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCore.ServiceProvider
{
    public interface IServiceHelper
    {
        T GetSpecificService<T>(Type childClass = null);
    }
}
