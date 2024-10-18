namespace WMS.Domain.AggregateModels.FinishedProductAggregate.All_IFinishedProductsRepository
{
    public interface IFinishedProductReceiptRepository : IRepository<FinishedProductReceipt>
    {
        Task<FinishedProductReceipt> Add(FinishedProductReceipt finishedProductReceipt);
        Task<FinishedProductReceipt> Update(string FinishedProductReceiptId, FinishedProductReceipt finishedProductReceipt);
        Task Remove(string finishedProductReceiptId);
        Task<IEnumerable<FinishedProductReceipt>> GetReceiptById(string finishedProductReceiptId);
    }
}
