using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.Get
{
    public sealed record GetProductsQuery : IQuery<List<ProductResponse>>;

}
