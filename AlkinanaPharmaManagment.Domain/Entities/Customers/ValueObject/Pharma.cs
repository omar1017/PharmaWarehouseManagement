using System.ComponentModel.DataAnnotations;

namespace AlkinanaPharmaManagment.Domain.Entities.Customers
{
    public record Pharma
    {
        public string Value { get; }
        private int maxLength = 50;

        public Pharma(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyPharmaNameException();
            }
            if (value.Length > maxLength)
            {
                throw new LengthPharmaNameException(value);
            }
            Value = value;
        }
        public static implicit operator Pharma(string Value) => new(Value);
        public static implicit operator string(Pharma Pharma) => Pharma.Value;
    }
}