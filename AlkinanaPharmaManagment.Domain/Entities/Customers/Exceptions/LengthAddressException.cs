
using AlkinanaPharmaManagment.Shared.Abstraction.Exceptions;

namespace AlkinanaPharmaManagment.Domain.Entities.Customers
{
    [Serializable]
    internal class LengthAddressException : AlkinanaPharmaManagmentException
    {
        

        public LengthAddressException(string value) : base($"{value} cannot greater than 200 characters.")
        {
        }
    }
}