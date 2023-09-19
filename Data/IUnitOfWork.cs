namespace PlatformService.Data 
{
    public interface IUnitOfWork : IDisposable 
    {
        IPlatformRepository PlatformRepository { get; }
        int Commit();
        Task<int> CommitAsync();
    }
}