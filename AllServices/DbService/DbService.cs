using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Entity;
using AllServices.RepositoryService;

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
    }
}
