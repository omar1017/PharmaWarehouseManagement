using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject;
using AlkinanaPharmaManagment.Domain.ValueObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.Create
{
    public record CreateProductCommand(ProductRequest Product) : ICommand<ProductId>;

    public record ProductRequest(string name, IFormFile? image, string companyName, string description, int price, string supplier);
}
