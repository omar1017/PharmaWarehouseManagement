using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject
{
    public record Supplier(string Value)
    {
        public static implicit operator Supplier(string Value) => new(Value);
        public static implicit operator string(Supplier supplier) => supplier.Value;
    }
}
