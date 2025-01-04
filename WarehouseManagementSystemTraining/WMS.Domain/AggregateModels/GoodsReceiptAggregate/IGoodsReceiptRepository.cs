namespace WMS.Domain.AggregateModels.GoodsReceiptAggregate
{
    public interface IGoodsReceiptRepository : IRepository<GoodsReceipt>
    {
        Task<IEnumerable<GoodsReceipt>> GetCompletedGoodsReceipts();
        Task<IEnumerable<GoodsReceipt>> GetUnCompletedGoodsReceipts();
        Task<IEnumerable<GoodsReceipt>> GetAllGoodsReceipts();
        Task<IList<string>> GetSuppliers();
        Task<IEnumerable<GoodsReceipt>> GetGoodsReceiptsByTime(DateTime timeTamp, bool isCompleted);
        Task<IEnumerable<GoodsReceipt>> Filter(IEnumerable<GoodsReceipt> goodsReceipts, IQueryable<GoodsReceiptLot> goodsReceiptLots);



        Task Add(GoodsReceipt goodsReceipt);
        Task Update(GoodsReceipt goodsReceipt);
        Task Remove(string goodsReceiptId);
        Task<GoodsReceipt> GetGoodsReceiptById(string goodsReceiptId);
        Task<GoodsReceiptLot> GetGoodsReceiptLotById(string goodsReceiptId, string goodsReceiptLotId);
        Task<GoodsReceipt> GetGoodsReceiptByGoodsReceiptId(string goodsReceiptId);
    }
}
