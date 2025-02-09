using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject
{
    public record SupplierName
    {
        public string Value { get; }
        private int maxLength = 64;

        private SupplierName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            else if (value.Length > maxLength)
            {
                throw new ArgumentException("invalid name.", nameof(value));
            }
            else
            {
                Value = value;
            }
        }

        public static SupplierName Create(string value)
        {
            return new SupplierName(value);
        }

        public static implicit operator SupplierName(string value) => new(value);
        public static implicit operator string(SupplierName supplierName) => supplierName.Value;
    }
}
