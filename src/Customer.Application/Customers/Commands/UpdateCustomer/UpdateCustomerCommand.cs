using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Customers.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
