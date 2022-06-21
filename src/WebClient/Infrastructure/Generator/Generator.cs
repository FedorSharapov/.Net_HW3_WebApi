using Bogus;
using WebClient.Models;

namespace WebClient.Infrastructure.Generator
{
    public class Generator : IGenerator
    {
        Faker _faker;

        public Generator()
        {
            _faker = new Faker("ru");
        }

        public CustomerVM NewCustomer()
        {
            return new CustomerVM { Firstname = _faker.Name.FirstName(), Lastname = _faker.Name.LastName() };
        }
    }
}
