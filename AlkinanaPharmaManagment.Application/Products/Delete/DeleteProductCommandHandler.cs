using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Exceptions;
using AlkinanaPharmaManagment.Domain.Entities.Products.Events;
using MediatR;

namespace AlkinanaPharmaManagment.Application.Products.Delete
{
    internal class DeleteProductCommandHandler(IProductRepository productRepository) : ICommandHandler<DeleteProductCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetFullProductById(request.productId);

            if (product is null)
            {
                throw new NotFoundException(nameof(product),request.productId);
            }

            product.Raise(new ProductDeletedEvent(product));

            await productRepository.DeleteAsync(request.productId);

            await productRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}
