using System;

namespace ChatRoomApi.Models.Dtos.Messages
{
    public class MessageHub
    {
        public int ChatId { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
