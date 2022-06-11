using WebClient.Models;

namespace WebClient.Infrastructure.Generator
{
    public interface IGenerator
    {
        Customer NewCustomer();
    }
}
