using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using AlkinanaPharmaManagment.Domain.Entities.Customers.Events;
using MediatR;

namespace AlkinanaPharmaManagment.Application.Customers.Create
{
    internal sealed class CreateCustomerCommandHandler(ICustomerRepository customerRepository) : ICommandHandler<CreateCustomerCommand,Guid>
    {
        
        async Task<Guid> IRequestHandler<CreateCustomerCommand, Guid>.Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.CreateCustomer(request.Customer.name, request.Customer.address, request.Customer.pharma,request.Customer.PhoneNumber);

            customer.Raise(new CustomerCreatedEvent(customer.CustomerId));

            await customerRepository.AddAsync(customer);

            await customerRepository.SaveChangeAsync();

            return customer.CustomerId.Value;
        }
    }
}
