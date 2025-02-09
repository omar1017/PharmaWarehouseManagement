using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject
{
    public record SupplierFirstName
    {
        public string Value { get; }
        private int maxLength = 32;

        private SupplierFirstName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            else if (value.Length > maxLength)
            {
                throw new ArgumentException("invalid first name.", nameof(value));
            }
            else
            {
                Value = value;
            }
        }

        public static SupplierFirstName Create(string value)
        {
            return new SupplierFirstName(value);
        }

        public static implicit operator SupplierFirstName(string value) => new(value);
        public static implicit operator string(SupplierFirstName supplierFirstName) => supplierFirstName.Value;
    }
}
