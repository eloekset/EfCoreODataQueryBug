using EfCoreODataQueryBug.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreODataQueryBug.Web.Data
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public SampleDbContext(DbContextOptions<SampleDbContext> options) 
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>();
        }
    }
}