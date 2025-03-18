using AlkinanaPharmaManagment.Application.Abstractions.HubServices;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Products.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.Update
{
    internal sealed class ProductUpdatedEventHandler(IRaiseMethod<Product> raiseMethod) : INotificationHandler<ProductUpdatedEvent>
    {
        public async Task Handle(ProductUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await raiseMethod.RaiseClients("Administrator","ProductUpdated",notification.Product);
        }
    }
}
