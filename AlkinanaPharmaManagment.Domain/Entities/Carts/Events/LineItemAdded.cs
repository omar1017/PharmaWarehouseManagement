using AlkinanaPharmaManagment.Shared.Abstraction.Domain;

namespace AlkinanaPharmaManagment.Domain.Entities;

public record LineItemAdded(Cart Cart, LineItem LineItem) : IDomainEvent;
