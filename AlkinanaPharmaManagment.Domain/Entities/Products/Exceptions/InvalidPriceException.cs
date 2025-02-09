using AlkinanaPharmaManagment.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Exceptions
{
    public class InvalidPriceException : AlkinanaPharmaManagmentException
    {
        public InvalidPriceException() : base("price can not be less than or equal zero.")
        {
        }
    }
}
