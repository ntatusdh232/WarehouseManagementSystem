using WMS.Domain.AggregateModels.IsolatedItemLotAggregate;

namespace WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository
{
    public interface IIsolatedItemLotRepository : IRepository<IsolatedItemLot>
    {
        Task<IsolatedItemLot> GetItemLotById(string lotId);
        Task <IsolatedItemLot> AddAsync(IsolatedItemLot itemLot);
        Task Update(IsolatedItemLot itemLot);
        Task Remove(string lotId);
        Task<IEnumerable<IsolatedItemLot>> GetAsync();
    }
}
