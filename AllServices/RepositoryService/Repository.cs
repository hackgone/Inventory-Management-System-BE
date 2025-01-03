﻿using System;
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
        
        public virtual async Task SaveData(T data)
        {
            await this.Entities.AddAsync(data);
            await this._dbContext.SaveChangesAsync();
        }

        public List<T> GetDataSpecific(Expression<Func<T, bool>> expression)
        {
            return this.Entities.Where(expression).ToList();   
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
