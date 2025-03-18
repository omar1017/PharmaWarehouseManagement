using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Carts.Get;

namespace AlkinanaPharmaManagment.Application.Customers.GetById
{
    internal sealed class GetCustomerByIdQueryHandler(ICustomerRepository customerRepository) : IQueryHandler<GetCustomerByIdQuery, CustomerResponse>
    {
        public async Task<CustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetAsync(request.customerId);

            if(customer is null)
            {

            }

            var customerResponse = new CustomerResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                PharmaName = customer.PharmaName,
                Address = customer.Address,
            };

            return customerResponse;
        }
    }
}
