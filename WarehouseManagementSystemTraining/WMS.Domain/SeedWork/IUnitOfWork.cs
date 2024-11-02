namespace WMS.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        void BeginTransaction();
        Task CommitTransactionAsync();
        void RollbackTransaction();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken);

    }
}
