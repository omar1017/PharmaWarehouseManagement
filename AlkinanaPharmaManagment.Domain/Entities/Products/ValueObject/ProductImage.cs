using AlkinanaPharmaManagment.Domain.Exceptions;


namespace AlkinanaPharmaManagment.Domain.ValueObject
{
    public record ProductImage
    {
        public string Value { get; }
        public ProductImage(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyProductImageUrl();
            }   
            Value = value;
        }
        public static implicit operator ProductImage(string imageUrl) => new(imageUrl);
        public static implicit operator string(ProductImage productImage) => productImage.Value;
    }
}
