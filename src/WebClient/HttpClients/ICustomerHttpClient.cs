using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.HttpClients 
{
    public interface ICustomerHttpClient
    {
        Task<Customer> GetCustomerAsync(long id);
        Task<int> CreateCustomerAsync(Customer customer);
    }
}
