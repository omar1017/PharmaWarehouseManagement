using AlkinanaPharmaManagment.Shared.Abstraction.Domain;

namespace AlkinanaPharmaManagment.Domain.Entities;

public record LineItemDeleted(Cart Cart, LineItem Item) : IDomainEvent;