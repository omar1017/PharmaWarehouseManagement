using AlkinanaPharmaManagment.Application.Abstractions.HubServices;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Products.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.Delete
{
    internal sealed class ProductDeletedEventHandler(IRaiseMethod<Product> raiseMethod) : INotificationHandler<ProductDeletedEvent>
    {
        public async Task Handle(ProductDeletedEvent notification, CancellationToken cancellationToken)
        {
            await raiseMethod.RaiseClients("Administrator", "ProductDeleted", notification.Product);
        }
    }
}
