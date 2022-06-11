using System;
using MediatR;

namespace Customers.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand: IRequest<long>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
