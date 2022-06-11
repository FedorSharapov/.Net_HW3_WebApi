namespace WebClient.Models
{
    internal class CustomerCreateRequest
    {
        public CustomerCreateRequest() { }
        public CustomerCreateRequest(string firstName, string lastName)
        {
            Firstname = firstName;
            Lastname = lastName;
        }

        public string Firstname { get; init; }
        public string Lastname { get; init; }
    }
}