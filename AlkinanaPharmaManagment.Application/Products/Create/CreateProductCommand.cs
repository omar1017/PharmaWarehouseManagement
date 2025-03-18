using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.ValueObject;
using System.Security.Claims;

namespace AlkinanaPharmaManagment.Application.Products.Create
{
    public record CreateProductCommand(ProductRequest Product, ClaimsPrincipal user) : ICommand<ProductId>;

    public record ProductRequest(string name,string? sName, Guid imageId, string imageUrl, Guid imgId, string? imgUrl, string companyName, string description, double price,double? publicPrice,int? quantity, string? supplier,string? message, string? notes);
}
