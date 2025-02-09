using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Customers.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Customers.GetByCity
{
    public sealed record GetCustomerByCityQuery(string city) : IQuery<List<CustomerResponse>>;

}
