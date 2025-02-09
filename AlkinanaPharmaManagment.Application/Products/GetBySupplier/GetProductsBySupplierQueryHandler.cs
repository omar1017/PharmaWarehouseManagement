using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Products.Get;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.GetBySupplier
{
    internal sealed class GetProductsBySupplierQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductsBySupplierQuery, List<ProductResponse>>
    {
        public async Task<List<ProductResponse>> Handle(GetProductsBySupplierQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetProductsBySupplier(request.supplierName);

            List<ProductResponse> result = new();

            foreach (var product in products)
            {
                result.Add(new ProductResponse
                {
                    ProductId = product.ProductId,
                    CompanyName = product.companyName,
                    Description = product.description,
                    Price = product.price,
                    Supplier = product.supplier,
                    ProductImage = product.image,
                    ProductName = product.name
                });
            }

            return result;
        }
    }
}
