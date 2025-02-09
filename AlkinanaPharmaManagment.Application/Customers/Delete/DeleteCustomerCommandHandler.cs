using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            await customerRepository.DeleteAsync(customer);

            await customerRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
