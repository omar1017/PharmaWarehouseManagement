using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Images;
using AlkinanaPharmaManagment.Domain.ValueObject;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace AlkinanaPharmaManagment.Application.Products.Update
{
    public sealed record UpdateProductCommand(Guid Id, ProductUpdate Product,ClaimsPrincipal user) : ICommand<ProductId>;
    public record ProductUpdate(string name,string? sName, string imageUrl, Guid imageId, string imgUrl, Guid imgId, string companyName, string description, double price, double? publicPrice,int? quantity,string? supplier,bool? isActive,string? message,string? notes);


}
