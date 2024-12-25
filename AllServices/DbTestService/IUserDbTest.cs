using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Entity;

namespace AllServices.DbTestService
{
    public interface IUserDbTest
    {
        public List<User> GetUsers();
    }
}
