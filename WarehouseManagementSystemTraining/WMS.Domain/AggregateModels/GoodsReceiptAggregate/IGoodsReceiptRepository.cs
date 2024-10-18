using WMS.Domain.AggregateModels.GoodsIssueAggregate;

namespace WMS.Domain.AggregateModels.GoodsReceiptAggregate
{
    public interface IGoodsReceiptRepository : IRepository<GoodsReceipt>, IRepository<GoodsReceiptLot>
    {
        Task<GoodsReceipt> Add(GoodsReceipt goodsReceipt);
        Task<GoodsReceipt> Update(string goodsReceiptId, GoodsReceipt goodsReceipt);
        Task Remove(string goodsReceiptId);
        Task<IEnumerable<GoodsReceipt>> GetGoodsReceiptById(string goodsReceiptId);
        Task<IEnumerable<GoodsReceiptLot>> GetGoodsReceiptLotById(string goodsReceiptLotId);
        //Task<IEnumerable<GoodsIssue>> GetGoodsReceiptByGoodsReceiptId();
    }
}
