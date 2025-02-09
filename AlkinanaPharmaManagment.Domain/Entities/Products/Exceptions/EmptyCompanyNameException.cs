using AlkinanaPharmaManagment.Shared.Abstraction.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Exceptions
{
    public class EmptyCompanyNameException : AlkinanaPharmaManagmentException
    {
        public EmptyCompanyNameException() : base("company name con not be empty.")
        {
        }
    }
}
