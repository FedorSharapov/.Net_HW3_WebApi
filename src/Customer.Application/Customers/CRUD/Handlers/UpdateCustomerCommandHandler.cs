using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Customers.Domain;
using Customers.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Customers.Application.Common.Exceptions;
using Customers.Application.Customers.CRUD.Operations;

namespace Customers.Application.Customers.CRUD.Handlers
{
    public class UpdateCustomerCommandHandler
        : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomersDbContext _dbContext;

        public UpdateCustomerCommandHandler(ICustomersDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Customers.FirstOrDefaultAsync(customer =>
                    customer.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            entity.Firstname = request.Firstname;
            entity.Lastname = request.Lastname;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
