using AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Carts
{
    public static class CartErrors
    {
        public static Error NotFound(Guid cartId) => Error.NotFound("Carts.NotFound",
            $"The cart With the Id = '{cartId}' was not found");
        
        public static Error NotFoundItem(Guid itemId) => Error.NotFound("Carts.NotFound",
            $"The item with the Id = '{itemId}' was not found");
    }
}
