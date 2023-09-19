namespace PlatformService.Data 
{
    public interface IUnitOfWork : IDisposable 
    {
        IPlatformRepository PlatformRepository { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}