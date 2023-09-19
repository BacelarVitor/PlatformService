
namespace PlatformService.Data 
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IPlatformRepository PlatformRepository { get; private set; }

        public UnitOfWork(AppDbContext context, PlatformRepository platformRepository)
        {
            _context = context;
            PlatformRepository = platformRepository;   
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
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