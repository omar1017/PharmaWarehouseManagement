using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Exceptions;
using AlkinanaPharmaManagment.Domain.Entities.Carts.Events;
using MediatR;

namespace AlkinanaPharmaManagment.Application.Carts.Delete
{
    internal sealed class DeleteCartCommandHandler(ICartRepository cartRepository) : ICommandHandler<DeleteCartCommand,Unit>
    {
        public async Task<Unit> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await cartRepository.GetByIdAsync(request.cartId);

            if (cart is null) {
                throw new NotFoundException(nameof(cart),request.cartId);
            }

            await cartRepository.DeleteAsync(cart);

            //raise----
            cart.Raise(new CartDeletedEvent(cart));
            await cartRepository.SaveChangeAsync();

            return Unit.Value;

        }
    }
}
