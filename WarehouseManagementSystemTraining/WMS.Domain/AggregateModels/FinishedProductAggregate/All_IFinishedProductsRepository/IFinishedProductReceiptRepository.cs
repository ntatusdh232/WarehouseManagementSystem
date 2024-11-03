namespace WMS.Domain.AggregateModels.FinishedProductAggregate.All_IFinishedProductsRepository
{
    public interface IFinishedProductReceiptRepository : IRepository<FinishedProductReceipt>
    {
        Task<FinishedProductReceipt> Add(FinishedProductReceipt finishedProductReceipt);
        Task<FinishedProductReceipt> Update(FinishedProductReceipt finishedProductReceipt);
        Task Remove(string finishedProductReceiptId);
        Task<FinishedProductReceipt> GetReceiptById(string finishedProductReceiptId);
        Task<IEnumerable<string>> GetReceiptIds();
        Task<IEnumerable<FinishedProductReceipt>> GetReceiptByTime(DateTime TimeTamp);
    }
}
