using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Products.Get;

namespace AlkinanaPharmaManagment.Application.Products.GetByCompany
{
    internal sealed class GetProductsByCompanyQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductsByCompanyQuery, List<ProductResponse>>
    {
        public async Task<List<ProductResponse>> Handle(GetProductsByCompanyQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetProductsByCompany(request.companyName);

            List<ProductResponse> result = new();

           

            return result;
        }
    }
}
