using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Products
{
    public static class ProductErrors
    {
        public static Error NotFound(Guid productId) => Error.NotFound("Product.NotFound",
            $"The product With the Id = '{productId}' was not found");

        public static readonly Error NotFoundByName = Error.NotFound(
            "Products.NotFoundByName",
            $"The Product with the specified name was not found");

        public static readonly Error NotFoundByCompany = Error.NotFound(
            "Products.NotFoundByCompany",
            $"The Product with the specified Company was not found");

        public static readonly Error NotFoundBySupplier = Error.NotFound("Products.NotFoundBySupplier",
            $"The Product with the specified Supplier was not found");
    }
}
