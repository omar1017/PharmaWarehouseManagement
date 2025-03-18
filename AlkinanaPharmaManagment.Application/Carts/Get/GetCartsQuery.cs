using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Products;

namespace AlkinanaPharmaManagment.Application.Carts.Get
{
    public sealed record GetCartsQuery (CartSearchRequest request) : IQuery<CartListResponse>;

}
