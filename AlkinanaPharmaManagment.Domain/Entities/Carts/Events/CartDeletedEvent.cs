using AlkinanaPharmaManagment.Shared.Abstraction.Domain;

namespace AlkinanaPharmaManagment.Domain.Entities.Carts.Events;

public record CartDeletedEvent(Cart cart):IDomainEvent;


