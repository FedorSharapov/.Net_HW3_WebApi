using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.HttpClients 
{
    public interface ICustomerHttpClient
    {
        Task<Customer> ReadAsync(long id);
        Task<long> CreateAsync(Customer customer);
    }
}
