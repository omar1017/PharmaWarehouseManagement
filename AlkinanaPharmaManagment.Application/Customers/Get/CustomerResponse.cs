using AlkinanaPharmaManagment.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Customers.Get
{
    public class CustomerResponse
    {
        public CustomerId CustomerId { get; set; }
        public CustomerName CustomerName { get; set; }
        public Pharma Pharma { get; set; }
        public Address Address { get; set; }
    }
}
