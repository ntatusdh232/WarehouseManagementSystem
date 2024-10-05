namespace ChaWarehouseMicroservice.Domain.AggregateModels.StockCardAggregate;

public interface IStockCardEntryRepository: IRepository<StockCardEntry>
{
    StockCardEntry Add(StockCardEntry entry);
    StockCardEntry Update(StockCardEntry entry);
    Task<StockCardEntry?> GetAsync(int itemId, DateTime date);
    Task<StockCardEntry?> GetLastestAsync(int itemId, DateTime date);
    Task<IEnumerable<StockCardEntry>> GetListAsync(int itemId, DateTime startDate, DateTime endDate);
}
