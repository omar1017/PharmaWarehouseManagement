using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Products.Get;

namespace AlkinanaPharmaManagment.Application.Products.GetByName
{
    internal sealed class GetProductsByNameQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductsByNameQuery, List<ProductResponse>>
    {
        public async Task<List<ProductResponse>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetProductsByName(request.productName);

            List<ProductResponse> result = new();

            

            return result;
        }
    }
}
