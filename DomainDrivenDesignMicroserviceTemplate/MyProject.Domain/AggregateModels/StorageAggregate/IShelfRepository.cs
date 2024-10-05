namespace ChaWarehouseMicroservice.Domain.AggregateModels.StorageAggregate;

public interface IShelfRepository: IRepository<Shelf>
{
    Shelf Add(Shelf shelf);
    Shelf Update(Shelf shelf);
    void UpdateRange(IEnumerable<Shelf> shelves);
    void Delete(Shelf shelf);
    Task<Shelf?> GetAsync(string shelfId);
    Task<Shelf?> GetAsync(int id);
    Task<IEnumerable<Shelf>> GetAllAsync();
}
