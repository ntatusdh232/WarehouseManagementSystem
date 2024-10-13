namespace WMS.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        // commit transaction
        void BeginTransaction();
        Task CommitTransactionAsync();
        void RollbackTransaction();

    }
}
