namespace Customers.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(CustomersDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
