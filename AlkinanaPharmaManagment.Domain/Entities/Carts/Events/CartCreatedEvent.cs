using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;

namespace AlkinanaPharmaManagment.Domain.Entities.Carts.Events;

public record CartCreatedEvent(CartId cartId): IDomainEvent;

