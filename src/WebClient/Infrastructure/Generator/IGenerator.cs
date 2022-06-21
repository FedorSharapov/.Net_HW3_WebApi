using WebClient.Models;

namespace WebClient.Infrastructure.Generator
{
    public interface IGenerator
    {
        CustomerVM NewCustomer();
    }
}
