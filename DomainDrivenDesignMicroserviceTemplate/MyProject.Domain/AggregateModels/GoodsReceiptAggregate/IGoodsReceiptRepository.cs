namespace ChaWarehouseMicroservice.Domain.AggregateModels.GoodsReceiptAggregate;

public interface IGoodsReceiptRepository: IRepository<GoodsReceipt>
{
    GoodsReceipt Add(GoodsReceipt goodsReceipt);
    GoodsReceipt Update(GoodsReceipt goodsReceipt);
    Task<GoodsReceipt?> GetAsync(string goodsReceiptId);
    Task<IEnumerable<GoodsReceipt>> GetListAsync(DateTime startTime, DateTime endTime);
}
