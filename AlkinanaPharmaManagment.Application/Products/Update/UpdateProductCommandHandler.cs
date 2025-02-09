using AlkinanaPharmaManagment.Application.Abstractions.Identity;
using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Domain.ValueObject;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.Update
{
    internal sealed class UpdateProductCommandHandler(IProductRepository productRepository, IUserService userService) : ICommandHandler<UpdateProductCommand, ProductId>
    {
        public async Task<ProductId> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Guid UpdatedBy = Guid.Parse(userService.UserId);

            var product = await productRepository.GetAsync(request.Product.Id);

            var productUpdated = Product.CreateProductForUpdate(
                    request.Product.Id,
                    request.Product.name,
                    request.Product.image,
                    request.Product.companyName,
                    request.Product.description,
                    request.Product.price,
                    request.Product.supplier,
                    product.SupplierId,
                    request.Product.isActive
                );
            productUpdated.ModifiedAt = DateTime.UtcNow;
            productUpdated.UpdatedBy = UpdatedBy;
            productUpdated.CreatedBy = product.CreatedBy;
            productUpdated.CreatedAt = product.CreatedAt;
            productUpdated.IsDeleted = product.IsDeleted;
           
            await productRepository.UpdateAsync(product);

            await productRepository.SaveChangeAsync();

            return request.Product.Id;
        }
    }
}
