using EfCoreODataQueryBug.Web.Models;
using System.Data.Entity;

namespace EfCoreODataQueryBug.Web.Data
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public SampleDbContext(string nameOrConnectionString) 
            : base(nameOrConnectionString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>();
        }
    }
}