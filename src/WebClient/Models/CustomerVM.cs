namespace WebClient.Models
{
    public class CustomerVM: Customers.Domain.Customer
    {
        public override string ToString()
        {
            return $"FullName: {Firstname} {Lastname}";
        }
    }
}