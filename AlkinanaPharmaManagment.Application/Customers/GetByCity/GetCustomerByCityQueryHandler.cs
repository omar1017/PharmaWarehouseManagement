using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Customers.Get;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Customers.GetByCity
{
    internal sealed class GetCustomerByCityQueryHandler(ICustomerRepository customerRepository) : IQueryHandler<GetCustomerByCityQuery, List<CustomerResponse>>
    {
        public async Task<List<CustomerResponse>> Handle(GetCustomerByCityQuery request, CancellationToken cancellationToken)
        {
            var customers = await customerRepository.GetCustomersByCity(request.city);

            List<CustomerResponse> result = new();

            foreach (var item in customers)
            {
                result.Add(new CustomerResponse
                {
                    CustomerId = item.CustomerId,
                    Address = item.address,
                    CustomerName = item.customerName,
                    Pharma = item.pharma
                });
            }

            return result;
        }
    }
}
