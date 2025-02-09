using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Customers
{
    public static class CustomerErrors
    {
        public static Error NotFound(Guid customerId) => Error.NotFound("Customers.NotFound",
            $"The customer With the Id = '{customerId}' was not found");

        public static readonly Error NotFoundByName = Error.NotFound(
            "Customers.NotFoundByName",
            $"The Customer with the specified name was not found");

        public static readonly Error NotFoundByPharma = Error.NotFound(
            "Customers.NotFoundByPharma",
            $"The Customer with the specified Pharma was not found");

        public static readonly Error NotFoundByCity = Error.NotFound("Customers.NotFoundByPharma",
            $"The Customer with the specified Phamra was not found");
    }
}
