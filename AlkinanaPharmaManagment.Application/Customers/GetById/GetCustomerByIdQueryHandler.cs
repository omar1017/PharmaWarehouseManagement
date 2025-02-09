using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Customers.Get;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                CustomerId = customer.CustomerId,
                CustomerName = customer.customerName,
                Pharma = customer.pharma,
                Address = customer.address
            };

            return customerResponse;
        }
    }
}
