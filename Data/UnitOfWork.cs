
namespace PlatformService.Data 
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IPlatformRepository PlatformRepository { get; private set; }

        public UnitOfWork(AppDbContext context )
        {
            _context = context;
            PlatformRepository = new PlatformRepository(_context);   
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void DisposeAsync() 
        {
            _context.DisposeAsync();
        }
    }
}