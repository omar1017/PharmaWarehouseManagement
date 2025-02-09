

using AlkinanaPharmaManagment.Shared.Abstraction.Exceptions;

namespace AlkinanaPharmaManagment.Domain.Exceptions
{
    public class EmptyProductNameException : AlkinanaPharmaManagmentException
    {
        public EmptyProductNameException() : base("Product Name cannt be empty.")
        {
        }
    }
}
