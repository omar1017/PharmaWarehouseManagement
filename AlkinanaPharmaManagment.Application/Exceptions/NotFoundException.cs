using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, Object key):base($"{name}, ({key}) was not found.")
        {
            
        }
    }
}
