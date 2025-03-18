using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Products.Get;

namespace AlkinanaPharmaManagment.Application.Products.GetBySupplier
{
    internal sealed class GetProductsBySupplierQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductsBySupplierQuery, List<ProductResponse>>
    {
        public async Task<List<ProductResponse>> Handle(GetProductsBySupplierQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetProductsBySupplier(request.supplierName);

            List<ProductResponse> result = new();

            

            return result;
        }
    }
}
