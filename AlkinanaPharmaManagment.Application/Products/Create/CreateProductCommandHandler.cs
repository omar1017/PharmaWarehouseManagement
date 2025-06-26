using AlkinanaPharmaManagment.Application.Abstractions.Identity;
using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Suppliers;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Products.Events;
using AlkinanaPharmaManagment.Domain.Entities.Suppliers;
using AlkinanaPharmaManagment.Domain.Entities.Warnings;
using AlkinanaPharmaManagment.Domain.ValueObject;
using System.Security.Claims;

namespace AlkinanaPharmaManagment.Application.Products.Create
{
    internal sealed class CreateProductCommandHandler(IProductRepository productRepository,IUserService userService,ISupplierRepository supplierRepository) : ICommandHandler<CreateProductCommand, ProductId>
    {
        public async Task<ProductId> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var userId = request.user.FindFirst("uid")?.Value;
           
            var isAdmin = request.user.FindFirst(ClaimTypes.Role)?.Value == "Administrator";
            Warning warning = null;
            bool isActive = false;

            if (isAdmin)
            {
                isActive = true;
            }

            string supplierName = "";


            var supplier = await supplierRepository.GetSupplierByUserId(userId);

            if (supplier is null)
            {
                if (isAdmin)
                {
                    supplier = Supplier.CreateSupplier(Guid.Parse(userId), "Admin", "Admin", "Admin", "admin@localhost.com", "Local");
                        await supplierRepository.AddSupplier(supplier);
                }

                else
                {
                    supplier = Supplier.CreateSupplier(Guid.Parse(userId), "User", "User", "User", "user@localhost.com", "Local");
                    await supplierRepository.AddSupplier(supplier);
                }

                await supplierRepository.SaveChangeAsync();   
            }

            if (!string.IsNullOrEmpty(request.Product.supplier))
            {
                supplierName = request.Product.supplier;
            }
            else
            {
                supplierName = supplier.SupplierName;
            }
            if (!string.IsNullOrEmpty(request.Product.message))
            {
                warning = new Domain.Entities.Warnings.Warning
                {
                    Id = Guid.NewGuid(),
                    ImageId = request.Product.imgId,
                    Message = request.Product.message
                };

                await productRepository.AddWarning(warning);
                await productRepository.SaveChangeAsync();
            }


            var product = Product.CreateProduct(
                request.Product.name,
                request.Product.imageId,
                request.Product.companyName,
                request.Product.description,
                request.Product.price,
                supplierName,
                supplier,
                isActive,
                request.Product.notes
                );
            if (warning is not null)
                product.Warning = await productRepository.GetWarningById(warning.Id);
            product.CreatedAt = DateTime.Now;
            product.CreatedBy = Guid.Parse(userId);
            product.IsDeleted = false;

            product.SName = request.Product.sName;
            product.Quantity = request.Product.quantity;
            product.PublicPrice = request.Product.publicPrice;


        
            product.Raise(new ProductCreatedEvent(product));
            

            await productRepository.AddAsync(product);

            await productRepository.SaveChangeAsync();

            return product.ProductId;
        }
    }
}
