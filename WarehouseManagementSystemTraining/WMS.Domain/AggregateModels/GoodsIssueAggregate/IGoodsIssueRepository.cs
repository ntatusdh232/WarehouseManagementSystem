namespace WMS.Domain.AggregateModels.GoodsIssueAggregate
{
    public interface IGoodsIssueRepository : IRepository<GoodsIssue>, IRepository<GoodsIssueLot>
    {
        Task<GoodsIssue> Add(GoodsIssue goodsIssue);
        Task Update(string goodsIssueId, GoodsIssue goodsIssue);
        Task Remove(string goodsIssueId);
        Task<GoodsIssue?> GetGoodsIssueById(string goodsIssueId);
        Task<GoodsIssueLot?> GetGoodsIssueLotById(string goodsIssueLotId);
        Task<IEnumerable<GoodsIssue>> GetListAsync();


    }
}
