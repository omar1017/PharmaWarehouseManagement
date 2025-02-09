using AlkinanaPharmaManagment.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject
{
    public record CompanyName
    {
        private int maxLength = 50;
        public string Value { get; }

        public CompanyName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyCompanyNameException();
            }
            Value = value;
        }

        public static implicit operator CompanyName(string companyName) => new(companyName);
        public static implicit operator string(CompanyName companyName) => companyName.Value;
    }
}
