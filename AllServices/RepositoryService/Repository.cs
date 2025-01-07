using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AllServices.DbContextService;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;


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
        public void Update(T data)
        {
            _cts = new CancellationTokenSource();

            // send a cancel after 4000 ms or call cts.Cancel();
            _cts.CancelAfter(40000);

            //Fetch the Token
            CancellationToken ct = _cts.Token;

            // Update the entity
            this.Entities.Update(data);

            // Save changes to the database
            this.SaveAsync(ct);
        }
        public void Delete(T data)
        {
            
            this.Entities.Remove(data);
            this._dbContext.SaveChanges();
        }
        // for optimistic concurrency
        public async Task<int> SaveAsync(CancellationToken ct)
        {
            int records = 0;
            IDbContextTransaction tx = null;
            //await Task.Delay(5000);
            if (ct.IsCancellationRequested)
            {
                ct.ThrowIfCancellationRequested();
            }

            try
            {
                using (tx = await _dbContext.Database.BeginTransactionAsync())
                {
                    records = await _dbContext.SaveChangesAsync();// savechangesasync has internal implemetation to check the entity rowversion and if not matches then throw expection.
                    tx.Commit();
                    return records;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
               
                throw new InvalidOperationException(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                System.Console.WriteLine(ex.Message);
                tx.Rollback();
            }
            return records;
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
