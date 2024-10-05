namespace ChaWarehouseMicroservice.Domain.AggregateModels.ItemAggregate;

public interface IItemRepository : IRepository<Item>
{
    Item Add(Item item);
    Item Update(Item item);
    void Delete(Item item);
    Task<bool> CheckExistenceAsync(string itemId);
    Task<Item?> GetAsync(string itemId);
    Task<IEnumerable<Item>> GetAllAsync();
}
