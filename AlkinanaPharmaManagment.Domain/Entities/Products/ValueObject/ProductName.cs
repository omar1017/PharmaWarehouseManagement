using AlkinanaPharmaManagment.Domain.Exceptions;


namespace AlkinanaPharmaManagment.Domain.ValueObject
{
    public record ProductName
    {
        public string Value { get; }

        public ProductName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyProductNameException();
            }
            Value = value;
        }

        public static implicit operator string(ProductName name) => name.Value;
        public static implicit operator ProductName(string name) => new(name);
    }
}
