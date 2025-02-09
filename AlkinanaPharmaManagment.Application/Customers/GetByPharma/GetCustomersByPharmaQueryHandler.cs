using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Customers.Get;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Customers.GetByPharma
{
    internal sealed class GetCustomersByPharmaQueryHandler(ICustomerRepository customerRepository) : IQueryHandler<GetCustomersByPharmaQuery, List<CustomerResponse>>
    {
        public async Task<List<CustomerResponse>> Handle(GetCustomersByPharmaQuery request, CancellationToken cancellationToken)
        {
            var customers = await customerRepository.GetCustomersByPharma(request.PharmaName);

            List<CustomerResponse> result = new();

            foreach (var customer in customers)
            {
                result.Add(new CustomerResponse
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.customerName,
                    Address = customer.address,
                    Pharma = customer.pharma
                });
            }

            return result;
        }
    }
}
