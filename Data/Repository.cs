
using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;   
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(Guid Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.RemoveRange(entities);
        }
    }
}