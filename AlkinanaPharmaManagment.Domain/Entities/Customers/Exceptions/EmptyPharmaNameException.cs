
using AlkinanaPharmaManagment.Shared.Abstraction.Exceptions;

namespace AlkinanaPharmaManagment.Domain.Entities.Customers
{
    [Serializable]
    internal class EmptyPharmaNameException : AlkinanaPharmaManagmentException
    {
       
        public EmptyPharmaNameException() : base($"Pharma Name cannot be empty.")
        {
        }
    }
}