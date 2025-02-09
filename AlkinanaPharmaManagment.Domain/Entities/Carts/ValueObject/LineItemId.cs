namespace AlkinanaPharmaManagment.Domain.Entities
{
    public record LineItemId(Guid Value)
    {
        public static implicit operator Guid(LineItemId lineItemId) => lineItemId.Value;
        public static implicit operator LineItemId(Guid Value) => new(Value);
    }
}