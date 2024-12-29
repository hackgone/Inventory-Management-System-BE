using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AllServices.DbContextService;
using System.Linq.Expressions;

namespace AllServices.RepositoryService
{
    //Its for only CRUD
    public class Repository<T>:IRepository<T> where T : class
    {
        private CommonDbContext _dbContext;
        private DbSet<T> _entities;
        public Repository(CommonDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual IEnumerable<T> GetAll()
        {
            return this.Entities.ToList();
        }
        public async Task<int> GetSpecificId(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Property name cannot be null or empty.", nameof(propertyName));

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be null or empty.", nameof(value));

            try
            {
                var result = await this.Entities
                    .Where(e => EF.Property<string>(e, propertyName) == value)
                    .Select(e => EF.Property<int>(e, "Id"))
                    .FirstOrDefaultAsync();

                return result; // Return the found Id or 0 if no match is found
            }
            catch (Exception ex)
            {
                // Log or handle the exception as necessary
                throw new InvalidOperationException($"Error querying for property '{propertyName}' with value '{value}'.", ex);
            }
        }

        public virtual async Task SaveData(T data)
        {
            await this.Entities.AddAsync(data);
            await this._dbContext.SaveChangesAsync();
        }
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _dbContext.Set<T>();
                return _entities;
            }
        }
    }
}
