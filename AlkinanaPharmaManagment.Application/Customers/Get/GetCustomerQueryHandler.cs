using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Carts.Get;

namespace AlkinanaPharmaManagment.Application.Customers.Get
{
    internal sealed class GetCustomerQueryHandler(ICustomerRepository customerRepository) : IQueryHandler<GetCustomerQuery, List<CustomerResponse>>
    {
        public async Task<List<CustomerResponse>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = customerRepository.GetAllAsync().Result.Select(c => new CustomerResponse
            {
                Id = c.CustomerId,
                Name = c.customerName,
                PharmaName = c.pharma,
                Address = c.address
            }).ToList();

            return customers;
        }
    }
}
