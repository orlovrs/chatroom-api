using ChatRoomApi.Models.Dtos.Messages;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ChatRoomApi.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(MessageHub message)
        {
            message.Date = DateTime.Now;
            await Clients.All.SendAsync("send", message);
        }
    }
}