using System;
using Customers.Application.Customers.CRUD.Operations;
using FluentValidation;

namespace Customers.Application.Customers.CRUD.Validators
{
    public class GetCustomerInfoQueryValidator : AbstractValidator<GetCustomerInfoQuery>
    {
        public GetCustomerInfoQueryValidator()
        {
            RuleFor(customer => customer.Id).NotEmpty();
        }
    }
}
