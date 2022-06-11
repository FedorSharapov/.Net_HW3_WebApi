using System;
using FluentValidation;

namespace Customers.Application.Customers.Queries.GetCustomerInfo
{
    public class GetCustomerInfoQueryValidator : AbstractValidator<GetCustomerInfoQuery>
    {
        public GetCustomerInfoQueryValidator()
        {
            RuleFor(customer => customer.Id).NotEmpty();
        }
    }
}
