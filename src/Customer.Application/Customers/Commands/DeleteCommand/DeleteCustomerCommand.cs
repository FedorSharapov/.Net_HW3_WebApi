using MediatR;

namespace Customers.Application.Customers.Commands.DeleteCommand
{
    public class DeleteCustomerCommand : IRequest
    {
        public long Id { get; set; }

        public DeleteCustomerCommand(){}

        public DeleteCustomerCommand(long id)
        {
            Id = id;
        }
    }
}
