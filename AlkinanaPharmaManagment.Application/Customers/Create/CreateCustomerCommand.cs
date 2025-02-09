using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using AlkinanaPharmaManagment.Domain.Entities.Customers.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Customers.Create
{
    public record CreateCustomerCommand(CustomerRequest Customer) : ICommand<Guid>;

    public record CustomerRequest(CustomerName name,Pharma pharma, Address address, PhoneNumber PhoneNumber);
}
