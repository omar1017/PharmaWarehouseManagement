using AlkinanaPharmaManagment.Application.Abstractions.Identity;
using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Suppliers;
using AlkinanaPharmaManagment.Domain.Entities.Products.Events;
using AlkinanaPharmaManagment.Domain.Entities.Warnings;
using AlkinanaPharmaManagment.Domain.ValueObject;
using System.Security.Claims;

namespace AlkinanaPharmaManagment.Application.Products.Update
{
    internal sealed class UpdateProductCommandHandler(IProductRepository productRepository, IUserService userService, ISupplierRepository supplierRepository) : ICommandHandler<UpdateProductCommand, ProductId>
    {
        public async Task<ProductId> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            bool isAdmin = request.user.FindFirst(ClaimTypes.Role)?.Value == "Administrator";
            string supplierName = "";
            var userId = userService.UserId;
            var supplier = await supplierRepository.GetSupplierByUserId(userId);

            Guid UpdatedBy = Guid.Parse(userId);

            Warning warning = null;
             
            var product = await productRepository.GetFullProductById(request.Id);

            if (!string.IsNullOrEmpty(request.Product.supplier) && isAdmin)
            {
                supplierName = request.Product.supplier;
            }
            else
            {
                supplierName = supplier.SupplierName;
            }


            product.name = request.Product.name;
            product.ImageId = request.Product.imageId;
            product.companyName = request.Product.companyName;
            product.description = request.Product.description;
            product.price = request.Product.price;
            product.supplier = supplierName;
            product.Supplier = supplier;
            product.Notes = request.Product.notes;      
            product.ModifiedAt = DateTime.UtcNow;
            product.UpdatedBy = UpdatedBy;
            
            if (isAdmin)
            {
                product.PublicPrice = request.Product.publicPrice;
                product.Quantity = request.Product.quantity;
                product.SName = request.Product.sName;
                if (product.Warning is not null)
                {
                    product.Warning.Message = request.Product.message;
                    product.Warning.ImageId = request.Product.imageId;
                }
            
                else
                {
                    if (!string.IsNullOrEmpty(request.Product.message))
                    {
                        warning = new Warning
                        {
                            Id = Guid.NewGuid(),
                            ImageId = request.Product.imgId,
                            Message = request.Product.message
                        };

                        await productRepository.AddWarning(warning);
                        await productRepository.SaveChangeAsync();
                    
                    }
                }
                if (warning is not null)
                    product.Warning = await productRepository.GetWarningById(warning.Id);
            }
           
            product.Raise(new ProductUpdatedEvent(product));

            await productRepository.SaveChangeAsync();

            return request.Id;
        }
    }
}
