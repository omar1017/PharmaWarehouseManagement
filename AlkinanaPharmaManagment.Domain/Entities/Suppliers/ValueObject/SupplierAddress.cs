using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject
{
    public record SupplierAddress
    {
        public string Value { get; }
        private int maxLength = 256;

        private SupplierAddress(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            else if (value.Length > maxLength)
            {
                throw new ArgumentException("invalid address the length greater than 256 char.", nameof(value));
            }

            else
            {
                Value = value;
            }
        }

        public static SupplierAddress Create(string value)
        {
            return new SupplierAddress(value);
        }

        public static implicit operator SupplierAddress(string value) => new(value);
        public static implicit operator string(SupplierAddress supplierAddress) => supplierAddress.Value;
    }
}
