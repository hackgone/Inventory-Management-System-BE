using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace AllServices.RepositoryService
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task SaveData(T data);
        List<T> GetDataSpecific(Expression<Func<T, bool>> expression);
        List<T> JoinData(Expression<Func<T, object>> expression);
        void Delete(T data);
        void Update(T data);
        Task<int> SaveAsync(CancellationToken ct);
    }
}
