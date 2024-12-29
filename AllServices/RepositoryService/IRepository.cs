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
        Task<int> GetSpecificId(String value, String propertyName);
    }
}
