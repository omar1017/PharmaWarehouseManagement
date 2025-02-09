using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Domain.ValueObject;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.Get
{
    internal sealed class GetProductsQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductsQuery, List<ProductResponse>>
    {
        public async Task<List<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();

            List<ProductResponse> result = new();

            foreach (var product in products)
            {
               
                result.Add(new ProductResponse
                {
                    ProductId = product.ProductId,
                    ProductName = product.name,
                    ProductImage = product.image,
                    Price = product.price,
                    Supplier = product.supplier,
                    Description = product.description,
                    CompanyName = product.companyName
                });
            }

            return result;
        }
    }
}
