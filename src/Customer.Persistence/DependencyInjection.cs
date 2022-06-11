using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Customers.Application.Interfaces;

namespace Customers.Persistence
{
    public static class DependencyInjection
    {
        // метод расширения для добавления контекста БД веб приложения и его регистрации
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<CustomersDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            
            services.AddScoped<ICustomersDbContext>(provider =>
                provider.GetService<CustomersDbContext>());

            return services;
        }
    }
}
