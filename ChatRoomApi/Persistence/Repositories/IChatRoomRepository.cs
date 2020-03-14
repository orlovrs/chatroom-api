using ChatRoomApi.Models;

namespace ChatRoomApi.Persistence.Repositories
{
    public interface IChatRoomRepository
    {
        // GET
        ChatRoom GetByName(string name);
        ChatRoom GetById(int id);

        // POST
        void Create(ChatRoom chatroom);

        // DELETE
        void Delete(ChatRoom chatRoom);

        // SAVE CHANGES
        void Save();
    }
}
