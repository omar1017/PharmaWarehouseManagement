using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Customers.Get
{
    internal sealed class GetCustomerQueryHandler(ICustomerRepository customerRepository) : IQueryHandler<GetCustomerQuery, List<CustomerResponse>>
    {
        public async Task<List<CustomerResponse>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = customerRepository.GetAllAsync().Result.Select(c => new CustomerResponse
            {
                CustomerId = c.CustomerId,
                CustomerName = c.customerName,
                Pharma = c.pharma,
                Address = c.address
            }).ToList();

            return customers;
        }
    }
}
