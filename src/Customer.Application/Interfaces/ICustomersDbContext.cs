using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Customers.Domain;

namespace Customers.Application.Interfaces
{
    public interface ICustomersDbContext
    {
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
