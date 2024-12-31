using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Entity;
using AllServices.RepositoryService;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AllServices.DbService
{
    public class DbService<TEntity> : IDbService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repo;
        public DbService(IRepository<TEntity> repo)
        {
            _repo = repo;
        }
        public List<TEntity> GetAllData()
        {
            var result = _repo.GetAll().ToList();
            return result ?? new List<TEntity>();
        }
        public async Task SaveData(TEntity entity)
        {
            await _repo.SaveData(entity);
        }
        
        public List<TEntity> GetUserByExp(Expression<Func<TEntity, bool>> expression)
        {
            return _repo.GetDataSpecific
                (expression);
        }
        public IEnumerable<TEntity> Get() 
        {
            return  _repo.GetAll().ToList();
        }
        
    }
}
