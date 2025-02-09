using AlkinanaPharmaManagment.Application.Abstractions.HubServices;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Infrastructure.Hubs
{
    public class RaiseMethod<T> : IRaiseMethod<T>
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public RaiseMethod(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        }

        public async Task RaiseClients(string group, string method, T entity)
        {
            if (string.IsNullOrEmpty(group))
                throw new ArgumentNullException(nameof(group));

            if (string.IsNullOrEmpty(method))
                throw new ArgumentNullException(nameof(method));

            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            
            await _hubContext.Clients.Group(group).SendAsync(method, entity);
            
        }
    }
}
