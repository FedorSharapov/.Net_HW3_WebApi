using Bogus;
using System;
using WebClient.Models;

namespace WebClient.Infrastructure.Generator
{
    public class Generator : IGenerator
    {
        private static Random _rand;
        Faker _faker;
        public Generator()
        {
            _rand = new Random();
            _faker = new Faker("ru");
        }
        public CustomerVM NewCustomer()
        {
            var gender = (Bogus.DataSets.Name.Gender)_rand.Next(2);
            return new CustomerVM { Firstname = _faker.Name.FirstName(gender), Lastname = _faker.Name.LastName(gender) };
        }
    }
}
