using AlkinanaPharmaManagment.Domain.Entities.Customers.Exceptions;

namespace AlkinanaPharmaManagment.Domain.Entities.Customers
{
    public record CustomerName(string Value)
    {
       

         

        public static implicit operator CustomerName(string name) => new(name);
        public static implicit operator string(CustomerName name) => name.Value;
    }
}