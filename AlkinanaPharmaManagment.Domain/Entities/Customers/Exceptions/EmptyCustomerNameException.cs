using AlkinanaPharmaManagment.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Customers.Exceptions
{
    public class EmptyCustomerNameException : AlkinanaPharmaManagmentException
    {
        public EmptyCustomerNameException() : base($"First Name or Last Name cannot be empty.")
        {
        }
    }
}
