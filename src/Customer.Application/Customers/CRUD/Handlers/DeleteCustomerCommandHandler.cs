using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Customers.Domain;
using Customers.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Customers.Application.Common.Exceptions;
using Customers.Application.Customers.Commands.DeleteCommand;

namespace Customers.Application.Customers.CRUD.Handlers
{
    public class DeleteCustomerCommandHandler
                : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomersDbContext _dbContext;

        public DeleteCustomerCommandHandler(ICustomersDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Customers.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            _dbContext.Customers.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
