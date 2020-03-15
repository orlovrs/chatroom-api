using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatRoomApi.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(int chatId, string user, string message)
        {
            await Clients.Group($"{chatId}").SendAsync("ReceiveMessage", user, message);
        }
    }
}