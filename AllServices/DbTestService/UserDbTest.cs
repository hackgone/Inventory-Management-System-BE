﻿using AllServices.DbContextService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Entity;
using AllServices.RepositoryService;

namespace AllServices.DbTestService
{
    //User defined methods here
    public class UserDbTest<TEntity> : IUserDbTest<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repo;
        public UserDbTest(IRepository<TEntity> repo) {
            _repo = repo;
        }
        public List<TEntity> GetUsers()
        {
            var result = _repo.GetAll().ToList();
            return result ?? new List<TEntity>();
        }
    }
}
