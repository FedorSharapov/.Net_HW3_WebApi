using System;
using MediatR;

namespace Customers.Application.Customers.CRUD.Operations
{
    public class CreateCustomerCommand : IRequest<long>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
