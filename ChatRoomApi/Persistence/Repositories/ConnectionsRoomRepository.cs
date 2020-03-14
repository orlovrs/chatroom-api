using ChatRoomApi.Models;
using System.Linq;

namespace ChatRoomApi.Persistence.Repositories
{
    public class ConnectionsRepository : BaseRepository, IConnectionsRepository
    {
        public ConnectionsRepository(AppContext context) : base(context)
        {
        }

        public void DeleteUserFromChat(string userName, ChatRoom chatRoom)
        {
            var connection =
                _context.Connections.FirstOrDefault(x => x.UserName.Equals(userName) && x.Chat == chatRoom);

            if (connection != null)
            {
                _context.Connections.Remove(connection);
                Save();
            }
        }
    }
}
