namespace WMS.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
