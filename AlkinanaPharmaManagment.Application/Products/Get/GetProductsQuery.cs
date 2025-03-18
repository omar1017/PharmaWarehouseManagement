using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.Get
{
    public sealed record GetProductsQuery(ProductSearchRequest request,ClaimsPrincipal user) : IQuery<ProductListResponse>;

}
