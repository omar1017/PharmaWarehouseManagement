using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Exceptions;
using MediatR;

namespace AlkinanaPharmaManagment.Application.Products.Active
{
    internal sealed class ActiveProductCommandHandler(IProductRepository productRepository) : ICommandHandler<ActiveProductCommand, Unit>
    {
        public async Task<Unit> Handle(ActiveProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetFullProductById(request.productId);

            if (product is null)
            {
                throw new NotFoundException(nameof(product), request.productId);
            }

            
            product.IsActive = !product.IsActive;

            await productRepository.UpdateAsync(product);

            await productRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
