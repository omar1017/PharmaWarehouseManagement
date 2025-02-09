using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Infrastructure.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly IHttpContextAccessor contextAccessor;

        public NotificationHub(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public override async Task OnConnectedAsync()
        {
            var context = this.contextAccessor.HttpContext;


            if (Context.User?.Identity?.IsAuthenticated == true)
            {
                if (Context.User.IsInRole("Administrator"))
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, "Administrator");
                }
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (Context.User?.Identity?.IsAuthenticated == true)
            {
                if (Context.User.IsInRole("Administrator"))
                {
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Administrator");
                }
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}

