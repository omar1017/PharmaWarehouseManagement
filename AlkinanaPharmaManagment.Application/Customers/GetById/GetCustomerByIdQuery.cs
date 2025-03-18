using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Carts.Get;
using AlkinanaPharmaManagment.Application.Customers.Get;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Customers.GetById
{
    public record GetCustomerByIdQuery(Guid customerId) : IQuery<CustomerResponse>;

}
