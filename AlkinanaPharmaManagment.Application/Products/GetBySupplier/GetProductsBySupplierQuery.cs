using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Application.Products.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.GetBySupplier
{
    public sealed record GetProductsBySupplierQuery(string supplierName) : IQuery<List<ProductResponse>>;

}
