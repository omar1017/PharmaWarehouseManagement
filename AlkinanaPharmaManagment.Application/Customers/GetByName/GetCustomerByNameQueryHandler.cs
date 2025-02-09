using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Customers.Get;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Customers.GetByName
{
    internal sealed class GetCustomerByNameQueryHandler(ICustomerRepository customerRepository) : IQueryHandler<GetCustomerByNameQuery, List<CustomerResponse>>
    {
        public async Task<List<CustomerResponse>> Handle(GetCustomerByNameQuery request, CancellationToken cancellationToken)
        {
            var customers = await customerRepository.GetCustomersByName(request.customerName);

            List<CustomerResponse> result = new();

            foreach (var customer in customers) {
                result.Add(new CustomerResponse
                {
                    CustomerId = customer.CustomerId,
                    Address = customer.address,
                    CustomerName = customer.customerName,
                    Pharma = customer.pharma
                });
            }

            return result;
        }
    }
}
