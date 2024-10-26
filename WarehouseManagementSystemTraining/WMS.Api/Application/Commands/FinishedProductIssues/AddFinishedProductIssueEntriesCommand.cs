namespace WMS.Api.Application.Commands.FinishedProductIssues
{
    public class AddFinishedProductIssueEntriesCommand : IRequest<bool>
    {
        public string FinishedProductIssueId { get; set; }
        public List<CreateFinishedProductIssueEntryViewModel> Entries { get; set; }

        public AddFinishedProductIssueEntriesCommand(string finishedProductIssueId, List<CreateFinishedProductIssueEntryViewModel> entries)
        {
            FinishedProductIssueId = finishedProductIssueId;
            Entries = entries;
        }

    }
}
