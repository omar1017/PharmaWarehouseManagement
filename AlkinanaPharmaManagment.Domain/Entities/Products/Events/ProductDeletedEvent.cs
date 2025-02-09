

using AlkinanaPharmaManagment.Shared.Abstraction.Domain;

namespace AlkinanaPharmaManagment.Domain.Entities.Products.Events;

public record ProductDeletedEvent(Product Product) : IDomainEvent;

