using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Suppliers.Events
{
    public record SupplierCreatedEvent(Supplier supplier) : IDomainEvent;
}
