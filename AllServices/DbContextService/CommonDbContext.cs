using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Entity;
using ApiData.Mappings;
using System.Reflection;

namespace AllServices.DbContextService
{
    public class CommonDbContext:DbContext
    {
        //public DbSet<User> User { get; set; }

        public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            //modelBuilder.ApplyConfiguration(new UserMapping());
            var assemblyWithMappings = Assembly.Load("ApiData");
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithMappings);
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine); // Log EF Core operations to the console
            base.OnConfiguring(optionsBuilder);
        }



    }

}
