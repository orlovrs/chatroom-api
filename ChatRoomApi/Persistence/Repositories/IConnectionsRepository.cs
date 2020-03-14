using ChatRoomApi.Models;

namespace ChatRoomApi.Persistence.Repositories
{
    public interface IConnectionsRepository
    {
        void DeleteUserFromChat(string userName, ChatRoom chatRoom);
    }
}
