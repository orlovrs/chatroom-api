using System.ComponentModel.DataAnnotations;

namespace ChatRoomApi.Models.Dtos.User
{
    public class UserRequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}
