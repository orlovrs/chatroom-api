using ChatRoomApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatRoomApi.Persistence
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Connection> Connections { get; set; }
    }
}
