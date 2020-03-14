using System.ComponentModel.DataAnnotations;

namespace ChatRoomApi.Models.Dtos.Messages
{
    public class MessageRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
