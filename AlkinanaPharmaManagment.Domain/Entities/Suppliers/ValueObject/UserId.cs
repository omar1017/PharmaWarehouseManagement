using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject
{
    public record UserId
    {
        public Guid Value { get; }

        private UserId(Guid value)
        {
            Value = value;
        }

        public static UserId Create(Guid value)
        {
            return new UserId(value);
        }

        public static implicit operator UserId(Guid value) => new(value);
        public static implicit operator Guid(UserId userId) => userId.Value;
    }
}
