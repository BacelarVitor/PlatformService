namespace PlatformService.Data 
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        Task<TEntity> GetAsync(Guid Id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Func<TEntity, bool> predicate);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}