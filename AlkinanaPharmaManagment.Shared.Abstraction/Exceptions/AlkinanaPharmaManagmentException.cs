using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Shared.Abstraction.Exceptions
{
    public abstract class AlkinanaPharmaManagmentException : Exception
    {
        protected AlkinanaPharmaManagmentException(string message) : base(message)
        {
            
        }
    }
}
