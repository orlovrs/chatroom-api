using ChatRoomApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ChatRoomApi.Persistence.Repositories
{
    public class ChatRoomRepository : BaseRepository, IChatRoomRepository
    {
        public ChatRoomRepository(AppContext context) : base(context)
        {
        }

        public ChatRoom GetByName(string name)
        {
            return _context.ChatRooms
                .Include(u => u.Users)
                .FirstOrDefault(x => x.Name.Equals(name) && x.Status.Equals("live"));
        }

        public ChatRoom GetById(int id)
        {
            return _context.ChatRooms
                .Include(u => u.Users)
                .FirstOrDefault(x => x.Id == id && x.Status.Equals("live"));
        }

        public void Create(ChatRoom chatroom)
        {
            _context.ChatRooms.Add(chatroom);
            Save();
        }

        public void Delete(ChatRoom chatRoom)
        {
            chatRoom.Status = "deleted";
            Save();
        }
    }
}
