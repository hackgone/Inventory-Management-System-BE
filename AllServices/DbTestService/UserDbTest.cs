using AllServices.DbContextService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Entity;

namespace AllServices.DbTestService
{
    public class UserDbTest : IUserDbTest
    {
        private CommonDbContext _dbContext;
        public UserDbTest(CommonDbContext dbContext) { 
            _dbContext = dbContext;
        }
        public List<User> GetUsers()
        {
            var result = _dbContext.User.ToList();
            return result ?? new List<User>();
        }
    }
}
