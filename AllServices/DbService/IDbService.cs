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
        public Task SaveData(TEntity entity);
        //public Task<int> GetDataByName(string name, String propertyName);
        
        public IEnumerable<TEntity> Get();
    }
}
