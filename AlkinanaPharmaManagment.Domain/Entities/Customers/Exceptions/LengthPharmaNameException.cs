
using AlkinanaPharmaManagment.Shared.Abstraction.Exceptions;

namespace AlkinanaPharmaManagment.Domain.Entities.Customers
{
    [Serializable]
    internal class LengthPharmaNameException : AlkinanaPharmaManagmentException
    {
        public LengthPharmaNameException(string value) : base($"'{value}' cannot be greater than 50.")
        {
        }
    }
}