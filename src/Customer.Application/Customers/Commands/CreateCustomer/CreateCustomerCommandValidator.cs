using System;
using FluentValidation;

namespace Customers.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(createCustomerCommand =>
                createCustomerCommand.Firstname).NotEmpty().MaximumLength(128);
            RuleFor(createCustomerCommand =>
                createCustomerCommand.Lastname).NotEmpty().MaximumLength(128);
        }
    }
}
