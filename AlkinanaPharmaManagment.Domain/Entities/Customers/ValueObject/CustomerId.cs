namespace AlkinanaPharmaManagment.Domain.Entities.Customers
{
    public record CustomerId(Guid Value)
    {
        public static implicit operator Guid(CustomerId customerId) => customerId.Value;
        public static implicit operator CustomerId(Guid id) => new(id);
    }
}