using Customers.Application.Customers.CRUD.ViewModels;
using MediatR;

namespace Customers.Application.Customers.CRUD.Operations
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
