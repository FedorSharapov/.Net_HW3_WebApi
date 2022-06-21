using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.HttpClients 
{
    public interface ICustomerHttpClient
    {
        Task<Customer> ReadAsync(string id);
        Task<string> CreateAsync(Customer customer);
    }
}
