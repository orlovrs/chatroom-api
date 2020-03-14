using System.ComponentModel.DataAnnotations;

namespace ChatRoomApi.Models
{
    public class Connection
    {
        public Connection() : this("")
        {
        }

        public Connection(string userName)
        {
            UserName = userName;
        }

        [Key] public int Id { get; set; }
        public string UserName { get; set; }

        public ChatRoom Chat { get; set; }
    }
}
