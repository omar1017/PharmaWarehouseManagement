using AlkinanaPharmaManagment.Application.Products;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using MediatR;

namespace AlkinanaPharmaManagment.Application.Carts.Active
{
    public record ActiveCartCommand(CartId CartId, LineItemId lineItemId): IRequest<Unit>;

    internal sealed class ActiveCartCommandHandler(ICartRepository cartRepository, IProductRepository productRepository) : IRequestHandler<ActiveCartCommand, Unit>
    {
        public async Task<Unit> Handle(ActiveCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await cartRepository.GetByIdAsync(request.CartId);
            var lineItem = cart.lineItems.FirstOrDefault(li => li.lineItemId == request.lineItemId);
            var product = await productRepository.GetFullProductById(lineItem.productId);

            if (cart is null)
            {
                throw new ArgumentException("invalid cart id");
            }

            if (lineItem is not null)
            {
                lineItem.isFulfilled = !lineItem.isFulfilled;

                if(lineItem.isFulfilled)
                {
                    var q = product.Quantity - lineItem.quantity;
                    if (q >= 0)
                    {
                        product.Quantity = product.Quantity - lineItem.quantity;
                    }
                    else
                    {
                        product.Quantity = 0;
                    }
                }
                else
                {
                    product.Quantity += lineItem.quantity;
                }
                
                await productRepository.SaveChangeAsync();
            }

            var isFuls = cart.lineItems.Select(li => li.isFulfilled).Where(isf => isf == false).ToList();

            
            
            cart.isFulfilled = !isFuls.Any();
                
            await cartRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
