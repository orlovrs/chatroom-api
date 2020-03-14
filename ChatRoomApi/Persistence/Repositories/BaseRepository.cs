using System;

namespace ChatRoomApi.Persistence.Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        protected readonly AppContext _context;
        protected bool Disposed = false;

        protected BaseRepository(AppContext context)
        {
            _context = context;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
