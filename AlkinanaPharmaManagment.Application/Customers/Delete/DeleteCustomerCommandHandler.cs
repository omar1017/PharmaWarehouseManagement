using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using MediatR;

namespace AlkinanaPharmaManagment.Application.Customers.Delete
{
    internal sealed class DeleteCustomerCommandHandler(ICustomerRepository customerRepository) : ICommandHandler<DeleteCustomerCommand,Unit>
    {
        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetAsync(request.customerId);

            if (customer is null)
            {
            }


            await customerRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
