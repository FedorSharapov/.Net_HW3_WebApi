using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Customers.Application.Common.Exceptions;
using Customers.Application.Interfaces;
using Customers.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Customers.Application.Customers.Queries.GetCustomerInfo
{
    public class GetCustomerInfoQueryHandler
        :IRequestHandler<GetCustomerInfoQuery, CustomerInfoVm>
    {
        private readonly ICustomersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomerInfoQueryHandler(ICustomersDbContext dbContext, 
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CustomerInfoVm> Handle(GetCustomerInfoQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Customers.FirstOrDefaultAsync(customer =>
            customer.Id == request.Id, cancellationToken);

            if(entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            return _mapper.Map<CustomerInfoVm>(entity);
        }
    }
}
