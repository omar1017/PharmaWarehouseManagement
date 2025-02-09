using AlkinanaPharmaManagment.Domain.Exceptions;


namespace AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject
{
    public record Price
    {
        public double Value { get; }

        public Price(double value)
        {
            if(value < 0)
            {
                throw new InvalidPriceException();
            }
            Value = value;
        }

        public static implicit operator double(Price price) => price.Value;
        public static implicit operator Price(double price) => new(price);
    }
}
