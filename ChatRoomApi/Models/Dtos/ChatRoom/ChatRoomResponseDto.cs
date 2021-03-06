﻿namespace ChatRoomApi.Models.Dtos.ChatRoom
{
    public class ChatRoomResponseDto
    {
        public ChatRoomResponseDto(Models.ChatRoom room)
        {
            Id = room.Id;
            Name = room.Name;
            Status = room.Status;
            Uuid = room.Uuid;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Uuid { get; set; }
    }
}
