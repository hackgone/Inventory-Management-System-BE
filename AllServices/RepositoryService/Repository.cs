using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AllServices.DbContextService;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;
using ApiCore.Entity;


namespace AllServices.RepositoryService
{
    //Its for only CRUD
    public class Repository<T>:IRepository<T> where T : class
    {
        private CommonDbContext _dbContext;
        private DbSet<T> _entities;
        CancellationTokenSource _cts = null;
        public Repository(CommonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.Entities.ToList();
        }
        
        public virtual async Task SaveData(T data)
        {
            await this.Entities.AddAsync(data);
            await this._dbContext.SaveChangesAsync();
        }

        public List<T> GetDataSpecific(Expression<Func<T, bool>> expression)
        {
            return this.Entities.Where(expression).ToList();   
        } 
        public List<T> JoinData(Expression<Func<T, object>> expression)
        {
            return this.Entities.Include(expression).ToList(); //its a inner join after this we can user where clause
        }
        public async Task Update(T data)
        {
            _cts = new CancellationTokenSource();
            _cts.CancelAfter(40000);
            CancellationToken ct = _cts.Token;

            try
            {
                this.Entities.Update(data); // Mark entity as modified
                await this.SaveAsync(ct);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Concurrency conflict detected: " + ex.Message);

                // Handle the concurrency exception here
                var entry = ex.Entries.Single();
                var clientValues = (ProductInventory)entry.Entity;

                var databaseEntry = await entry.GetDatabaseValuesAsync();
                if (databaseEntry == null)
                {
                    Console.WriteLine("The entity was deleted by another user.");
                    return;
                }

                var databaseValues = (ProductInventory)databaseEntry.ToObject();
                Console.WriteLine($"Database values: AvailableQuantity = {databaseValues.AvailableQuantity}");

                // Optional: Reload the original values
                entry.OriginalValues.SetValues(databaseEntry);

                throw; // Rethrow to notify the caller
            }
        }

        public void Delete(T data)
        {
            
            this.Entities.Remove(data);
            this._dbContext.SaveChanges();
        }
        // for optimistic concurrency
        public async Task<int> SaveAsync(CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
            {
                ct.ThrowIfCancellationRequested();
            }

            try
            {
                return await _dbContext.SaveChangesAsync(ct);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Concurrency conflict: " + ex.Message);
                // Handle conflict resolution here
                throw; // Rethrow or handle as needed
            }
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
