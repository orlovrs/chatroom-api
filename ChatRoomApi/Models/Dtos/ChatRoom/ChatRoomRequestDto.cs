using System.ComponentModel.DataAnnotations;

namespace ChatRoomApi.Models.Dtos.ChatRoom
{
    public class ChatRoomRequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}
