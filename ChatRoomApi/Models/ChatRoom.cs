using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChatRoomApi.Models
{
    public class ChatRoom
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public List<Connection> Users { get; set; }
    }
}
