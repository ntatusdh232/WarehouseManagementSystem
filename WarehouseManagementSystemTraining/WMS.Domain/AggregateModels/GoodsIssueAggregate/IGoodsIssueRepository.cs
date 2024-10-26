namespace WMS.Domain.AggregateModels.GoodsIssueAggregate
{
    public interface IGoodsIssueRepository : IRepository<GoodsIssue>, IRepository<GoodsIssueLot>
    {
        Task Add(GoodsIssue goodsIssue, CancellationToken cancellationToken);
        Task<GoodsIssue?> GetGoodsIssueById(string goodsIssueId);
        Task<GoodsIssueLot?> GetGoodsIssueLotById(string goodsIssueLotId);
        Task<IEnumerable<GoodsIssue>> GetListAsync();
        Task Remove(string goodsIssueId, CancellationToken cancellationToken);
        Task Update(GoodsIssue goodsIssue, CancellationToken cancellationToken);



    }

    public interface IGoodsIssueEntryRepository : IRepository<GoodsIssueEntry>
    {
        Task<GoodsIssueEntry> GetEntryByGoodsIssueIdAndItemId(string goodsIssueId, string itemId);
        Task RemoveEntry(GoodsIssueEntry entry, CancellationToken cancellationToken);
        Task UpdateEntries(List<GoodsIssueEntry> goodsIssueEntries, CancellationToken cancellationToken);


    }


}
