using System;
using FluentValidation;

namespace Customers.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(updateCustomerCommand =>
                updateCustomerCommand.Id).NotEmpty();
            RuleFor(updateCustomerCommand =>
                updateCustomerCommand.Firstname).NotEmpty().MaximumLength(128);
            RuleFor(updateCustomerCommand =>
                updateCustomerCommand.Lastname).NotEmpty().MaximumLength(128);
        }
    }
}
