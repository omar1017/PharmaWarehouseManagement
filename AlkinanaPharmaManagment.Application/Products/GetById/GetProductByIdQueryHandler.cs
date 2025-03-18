using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Exceptions;
using AlkinanaPharmaManagment.Application.Products.Get;
using AlkinanaPharmaManagment.Domain.Entities;

namespace AlkinanaPharmaManagment.Application.Products.GetById
{
    internal sealed class GetProductByIdQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductByIdQuery, ProductResponse>
    {
        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
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
