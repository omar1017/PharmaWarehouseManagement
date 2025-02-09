

namespace AlkinanaPharmaManagment.Domain.ValueObject
{
    public record class ProductId(Guid Value)
    {
        public static implicit operator Guid(ProductId id) => id.Value;
        public static implicit operator ProductId(Guid id) => new(id);
    }
}
