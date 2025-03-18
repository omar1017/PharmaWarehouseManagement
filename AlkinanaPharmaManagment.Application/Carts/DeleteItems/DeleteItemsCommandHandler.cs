using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using MediatR;

namespace AlkinanaPharmaManagment.Application.Carts.DeleteItems
{
    internal sealed class DeleteItemsCommandHandler(ICartRepository cartRepository) : ICommandHandler<DeleteItemsCommand,Unit>
    {
        public async Task<Unit> Handle(DeleteItemsCommand request, CancellationToken cancellationToken)
        {
            var cart = await cartRepository.GetByIdAsync(request.cartId);

            if (cart is null) { }

            cart.RemoveItem(request.lineItemId);

            await cartRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
