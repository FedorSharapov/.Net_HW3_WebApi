using System;
using Customers.Application.Customers.CRUD.Operations;
using FluentValidation;

namespace Customers.Application.Customers.CRUD.Validators
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(deleteCustomerCommand =>
                deleteCustomerCommand.Id).NotEmpty();
        }
    }
}
