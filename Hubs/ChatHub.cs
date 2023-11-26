using Microsoft.AspNetCore.SignalR;
using Chat_AspnetCore.Models;
using Newtonsoft.Json;

namespace Chat_AspnetCore.Hubs;

public sealed class ChatHub : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
