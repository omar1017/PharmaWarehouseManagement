
using AlkinanaPharmaManagment.Shared.Abstraction.Exceptions;

namespace AlkinanaPharmaManagment.Domain.Entities.Customers
{
    [Serializable]
    internal class EmptyAddressException : AlkinanaPharmaManagmentException
    {
        
        public EmptyAddressException() : base("Address cannot be empty.")
        {
        }
    }
}