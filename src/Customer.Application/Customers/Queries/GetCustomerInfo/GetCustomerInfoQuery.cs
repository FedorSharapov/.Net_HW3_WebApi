using MediatR;

namespace Customers.Application.Customers.Queries.GetCustomerInfo
{
    public class GetCustomerInfoQuery : IRequest<CustomerInfoVm>
    {
        public long Id { get; set; }
        
        public GetCustomerInfoQuery() { }

        public GetCustomerInfoQuery(long id)
        {
            Id = id;
        }
    }
}
