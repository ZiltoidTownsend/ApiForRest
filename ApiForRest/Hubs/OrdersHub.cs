using LibraryMenu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForRest.Hubs
{
    public class OrdersHub : Hub
    {
        private Dictionary<string, string> UserIdConnectedIdPairs = new Dictionary<string, string>();
        public async Task SendOrderToKitchen(OrderData message)
        {
            await Clients.All.SendAsync("SendOrderTo", message);
        }

        public async Task SendOrderToWaiter(OrderData message)
        {
            await Clients.All.SendAsync("SendOrderTo", message);
        }

        public async Task RegistrationUser(string loginId)
        {
            if (UserIdConnectedIdPairs.Any(u => u.Key == loginId))
                UserIdConnectedIdPairs.Remove(loginId);
            UserIdConnectedIdPairs.Add(loginId, Context.ConnectionId);           
        }

        public override Task OnConnectedAsync()
        {
            
            return base.OnConnectedAsync();
        }

    }
}
