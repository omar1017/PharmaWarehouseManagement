using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.ValueObject;
using Microsoft.AspNetCore.Http;


namespace AlkinanaPharmaManagment.Application.Products.Update
{
    public sealed record UpdateProductCommand(ProductUpdate Product) : ICommand<ProductId>;
    public record ProductUpdate(Guid Id, string name, string image, string companyName, string description, int price, string supplier,bool isActive);
}
