using System;

namespace ChatRoomApi.Models.Dtos.Messages
{
    public class MessageResponseDto
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }
}
