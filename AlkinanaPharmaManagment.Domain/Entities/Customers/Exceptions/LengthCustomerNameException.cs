
using AlkinanaPharmaManagment.Shared.Abstraction.Exceptions;

namespace AlkinanaPharmaManagment.Domain.Entities.Customers
{
    [Serializable]
    internal class LengthCustomerNameException : AlkinanaPharmaManagmentException
    {
        public LengthCustomerNameException(string firstName, string lastName) : base($"{firstName} or {lastName} cannot be greater than 50 characters.")
        {
        }
    }
}