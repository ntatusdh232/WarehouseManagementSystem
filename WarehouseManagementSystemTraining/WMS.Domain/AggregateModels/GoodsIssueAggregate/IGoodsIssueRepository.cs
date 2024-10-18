namespace WMS.Domain.AggregateModels.GoodsIssueAggregate
{
    public interface IGoodsIssueRepository : IRepository<GoodsIssue>, IRepository<GoodsIssueLot>
    {
        Task<GoodsIssue> Add(GoodsIssue goodsIssue);
        Task<GoodsIssue> Update(string goodsIssueId, GoodsIssue goodsIssue);
        Task Remove(string goodsIssueId);
        Task<IEnumerable<GoodsIssue>> GetGoodsIssueById(string goodsIssueId);
        Task<IEnumerable<GoodsIssueLot>> GetGoodsIssueLotById(string goodsIssueLotId);
        Task<IEnumerable<GoodsIssue>> GetListAsync();


    }
}
