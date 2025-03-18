using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.GetAllProduct
{
    public record GetAllProductQuery(ProductSearchRequest request) : IRequest<ProductListResponse>;

    internal class GetAllProductQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductQuery, ProductListResponse>
    {
        public async Task<ProductListResponse> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var response = await productRepository.GetProducts(request.request);

            if (response is null)
            {
                throw new ArgumentNullException("no products "+nameof(response));
            }

            return response;
        }
    }
}
