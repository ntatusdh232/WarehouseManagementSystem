namespace WMS.Api.Application.Commands.FinishedProductIssues
{
    public class CreateFinishedProductIssueCommand : IRequest<bool>
    {        
        public string FinishedProductIssueId { get; set; }
        public string Receiver { get; set; }
        public string EmployeeId { get; set; }
        public List<CreateFinishedProductIssueEntryViewModel> Entries { get; set; }
        public CreateFinishedProductIssueCommand(string finishedProductIssueId, string receiver, string employeeId, List<CreateFinishedProductIssueEntryViewModel> entries)
        {
            FinishedProductIssueId = finishedProductIssueId;
            Receiver = receiver;
            EmployeeId = employeeId;
            Entries = entries;
        }   
    }
}
