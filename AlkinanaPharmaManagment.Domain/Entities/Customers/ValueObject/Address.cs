namespace AlkinanaPharmaManagment.Domain.Entities.Customers
{
    public record Address(string Value)
    {
       
        public static implicit operator Address(string value) => new(value);
        public static implicit operator string(Address address) => address.Value;
    }
}