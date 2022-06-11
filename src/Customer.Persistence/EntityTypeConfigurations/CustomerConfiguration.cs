using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Customers.Domain;

namespace Customers.Persistence.EntityTypeConfigurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(customer => customer.Id);
            builder.HasIndex(customer => customer.Id).IsUnique();
            builder.Property(customer => customer.Firstname).HasMaxLength(128);
            builder.Property(customer => customer.Lastname).HasMaxLength(128);
        }
    }
}
