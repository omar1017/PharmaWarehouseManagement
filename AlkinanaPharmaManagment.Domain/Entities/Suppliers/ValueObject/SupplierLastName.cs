using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject
{
    public record SupplierLastName
    {
        public string Value { get; }
        private int maxLength = 32;

        private SupplierLastName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            else if (value.Length > maxLength)
            {
                throw new ArgumentException("invalid last name.", nameof(value));
            }
            else
            {
                Value = value;
            }
        }

        public static SupplierLastName Create(string value)
        {
            return new SupplierLastName(value);
        }

        public static implicit operator SupplierLastName(string value) => new(value);
        public static implicit operator string(SupplierLastName supplierLastName) => supplierLastName.Value;
    }
}
