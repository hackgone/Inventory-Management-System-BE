using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllServices.DbService
{
    public interface IDbService<TEntity> where TEntity : class
    {
        public List<TEntity> GetAllData();
    }
}
