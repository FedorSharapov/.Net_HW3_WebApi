using System;
using FluentValidation;

namespace Customers.Application.Customers.Commands.DeleteCommand
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
