using Microsoft.EntityFrameworkCore;
using Customers.Application.Interfaces;
using Customers.Domain;
using Customers.Persistence.EntityTypeConfigurations;

namespace Customers.Persistence
{
    public class CustomersDbContext : DbContext, ICustomersDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
