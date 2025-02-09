using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Carts.ValueObject
{
    public record CartId(Guid Value)
    {
        public static implicit operator Guid(CartId id) => id.Value;
        public static implicit operator CartId(Guid id) => new(id);
    }
}
