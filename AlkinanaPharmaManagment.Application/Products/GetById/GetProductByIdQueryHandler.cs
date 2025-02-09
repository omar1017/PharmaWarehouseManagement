using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Exceptions;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Repositories;

namespace AlkinanaPharmaManagment.Application.Products.GetById
{
    internal sealed class GetProductByIdQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductByIdQuery, Product>
    {
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetAsync(request.productId);

            if (product is null)
            {
                throw new NotFoundException(nameof(product),request.productId);
            }

            return product;
        }
    }
}
