using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Customers.Domain;
using Customers.Application.Interfaces;

namespace Customers.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler 
        : IRequestHandler<CreateCustomerCommand,long>
    {
        private readonly ICustomersDbContext _dbContext;

        public CreateCustomerCommandHandler(ICustomersDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<long> Handle(CreateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname
            };

            await _dbContext.Customers.AddAsync(customer, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return customer.Id;
        }
    }
}
