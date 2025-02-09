using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Suppliers.ValueObject
{
    public record SupplierId(Guid value) 
    {
        public static implicit operator Guid(SupplierId supplierId) => supplierId.value;
        public static implicit operator SupplierId(Guid value)=>new(value);
    }
}
