using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject
{
    public record Description(string Value)
    {
        public static implicit operator Description(string Value) => new(Value);
        public static implicit operator string(Description Describtion) => Describtion.Value;
    }
}
