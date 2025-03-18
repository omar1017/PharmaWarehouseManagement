using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Entities;

namespace AlkinanaPharmaManagment.Application.Carts.GetById
{
    internal sealed class GetCartByIdQueryHandler(ICartRepository cartRepository) : IQueryHandler<GetCartByIdQuery, Cart>
    {
        public async Task<Cart> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await cartRepository.GetByIdAsync(request.CartId);

            if (cart is null)
            {
                
            }

           

            return cart;
        }
    }
}
