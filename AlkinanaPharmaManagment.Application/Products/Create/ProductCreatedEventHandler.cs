using AlkinanaPharmaManagment.Application.Abstractions.HubServices;
using AlkinanaPharmaManagment.Application.Models.Identity;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Entities.Products.Events;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.Create
{
    internal sealed class ProductCreatedEventHandler(IRaiseMethod<Product> raiseMethod) : INotificationHandler<ProductCreatedEvent>
    { 
        public async Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            await raiseMethod.RaiseClients("Administrator", "ProductAdded", notification.Product);
        }
    }
}
