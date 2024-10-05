namespace ChaWarehouseMicroservice.Domain.AggregateModels.GoodsIssueAggregate;

public interface IGoodsIssueRepository: IRepository<GoodsIssue>
{
    GoodsIssue Add(GoodsIssue goodsIssue);
    GoodsIssue Update(GoodsIssue goodsIssue);
    Task<IEnumerable<GoodsIssue>> GetListAsync(DateTime startTime, DateTime endTime);
    Task<GoodsIssue?> GetAsync(string id);
}
