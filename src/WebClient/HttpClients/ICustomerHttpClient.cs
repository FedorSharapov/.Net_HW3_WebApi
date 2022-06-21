using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.HttpClients 
{
    public interface ICustomerHttpClient
    {
        Task<CustomerVM> ReadAsync(string id);
        Task<string> CreateAsync(CustomerVM customer);
    }
}
