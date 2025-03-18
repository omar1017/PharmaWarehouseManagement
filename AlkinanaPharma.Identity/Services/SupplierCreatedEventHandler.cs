using AlkinanaPharmaManagment.Application.Abstractions.HubServices;
using AlkinanaPharmaManagment.Domain.Entities.Suppliers;
using AlkinanaPharmaManagment.Domain.Entities.Suppliers.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharma.Identity.Services
{
    internal class SupplierCreatedEventHandler(IRaiseMethod<Supplier> raiseMethod) : INotificationHandler<SupplierCreatedEvent>
    {
        public async Task Handle(SupplierCreatedEvent notification, CancellationToken cancellationToken)
        {
            await raiseMethod.RaiseClients("Administrator", "SupplierAdded", notification.supplier);
        }
    }
}
