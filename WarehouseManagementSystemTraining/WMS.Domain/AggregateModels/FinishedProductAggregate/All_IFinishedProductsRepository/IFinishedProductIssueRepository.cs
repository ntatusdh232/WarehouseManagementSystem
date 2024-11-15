namespace WMS.Domain.AggregateModels.FinishedProductAggregate.All_IFinishedProductsRepository
{
    public interface IFinishedProductIssueRepository : IRepository<FinishedProductIssue>
    {
        Task AddAsync(FinishedProductIssue finishedProductIssue);
        Task<FinishedProductIssue> GetIssueById(string finishedProductIssueId);
        Task<FinishedProductIssue> Update(FinishedProductIssue finishedProductIssue);
        Task<IEnumerable<FinishedProductIssueEntry>> GetProductIssueEntry();
        Task UpdateEntries(FinishedProductIssue finishedProductIssue);
        Task<IEnumerable<string>> GetReceivers();





    }
}