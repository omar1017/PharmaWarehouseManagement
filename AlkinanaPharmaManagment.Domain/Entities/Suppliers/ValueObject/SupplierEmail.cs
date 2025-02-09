using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject
{
    public record SupplierEmail
    {
        public string Value { get; }
        private int maxLength = 64;

        private SupplierEmail(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }
            else if(value.Length > maxLength || !IsValidEmail(value))
            {
                throw new ArgumentException("invalid email address",nameof(value));
            }
            else
            {
                Value = value;
            }
        
        }

        public static SupplierEmail Create(string value)
        {
            return new SupplierEmail(value);
        }

        private static bool IsValidEmail(string value)
        {
            var regex = new Regex("");
            return regex.IsMatch(value);
        }

        public static implicit operator SupplierEmail(string value) => new(value);
        public static implicit operator string(SupplierEmail supplierEmail) => supplierEmail.Value;
    }
}
