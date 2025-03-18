using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using MediatR;

namespace AlkinanaPharmaManagment.Application.Products.Active;

public record ActiveProductCommand(Guid productId) : ICommand<Unit>;
