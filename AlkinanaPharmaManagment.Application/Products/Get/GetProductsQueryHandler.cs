using AlkinanaPharmaManagment.Application.Abstractions.Messaging;

namespace AlkinanaPharmaManagment.Application.Products.Get
{
    internal sealed class GetProductsQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductsQuery, ProductListResponse>
    {
        public async Task<ProductListResponse> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var response = await productRepository.GetAllAsync(request.request,request.user);

           if(response is null)
            {
                throw new Exception("no item");
            }

            return response;
        }
    }
}
