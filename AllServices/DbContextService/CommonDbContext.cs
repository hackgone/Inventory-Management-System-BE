using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Entity;
using ApiData.Mappings;

namespace AllServices.DbContextService
{
    public class CommonDbContext:DbContext
    {
        public DbSet<User> User { get; set; }

        public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
        


    }

}
