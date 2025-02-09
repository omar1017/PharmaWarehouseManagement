

using AlkinanaPharmaManagment.Shared.Abstraction.Domain;

namespace AlkinanaPharmaManagment.Domain.Entities.Products.Events;

public record ProductCreatedEvent(Product Product) : IDomainEvent;

