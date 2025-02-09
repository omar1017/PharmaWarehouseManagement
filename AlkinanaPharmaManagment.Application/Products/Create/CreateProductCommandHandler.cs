using AlkinanaPharmaManagment.Application.Abstractions.DriveServices;
using AlkinanaPharmaManagment.Application.Abstractions.Identity;
using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Exceptions;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Products.Events;
using AlkinanaPharmaManagment.Domain.Repositories;
using AlkinanaPharmaManagment.Domain.ValueObject;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace AlkinanaPharmaManagment.Application.Products.Create
{
    internal sealed class CreateProductCommandHandler(IProductRepository productRepository,IDriveServices driveServices,IUserService userService) : ICommandHandler<CreateProductCommand, ProductId>
    {
        public async Task<ProductId> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Guid UserId = Guid.Parse(userService.UserId);
            var product = Product.CreateProduct(
                request.Product.name,
                @"http://drive.google.com/thumbnail?id=" ,
                request.Product.companyName,
                request.Product.description,
                request.Product.price,
                request.Product.supplier,
                null,
                false
                );
            product.CreatedAt = DateTime.UtcNow;
            product.CreatedBy = UserId;
            product.IsDeleted = false;
        
             product.Raise(new ProductCreatedEvent(product));
            

            await productRepository.AddAsync(product);

            await productRepository.SaveChangeAsync();

            return product.ProductId;
        }

        

    }
}
