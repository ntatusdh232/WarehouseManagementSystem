namespace WMS.Api.Application.Commands.FinishedProductIssues
{
    public class CreateFinishedProductIssueCommandHandler : IRequestHandler<CreateFinishedProductIssueCommand,bool>
    {
        private readonly IFinishedProductIssueRepository _finishedProductIssueRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public CreateFinishedProductIssueCommandHandler(IFinishedProductIssueRepository finishedProductIssueRepository)
        {
            _finishedProductIssueRepository = finishedProductIssueRepository;
        }

        public async Task<bool> Handle(CreateFinishedProductIssueCommand request, CancellationToken cancellationToken)
        {
            var finishedProductIssue = await _finishedProductIssueRepository.GetIssueById(request.FinishedProductIssueId);
            if (finishedProductIssue != null) return false;
            
            var employee = _employeeRepository.GetEmployeeById(request.EmployeeId);

            var entries = request.Entries.Select(entry =>
                new CreateFinishedProductIssueEntryViewModel(
                    entry.PurchaseOrderNumber,
                    entry.Quantity,
                    entry.ItemId,
                    entry.Note,
                    entry.Unit
                )
            ).ToList();


            return true;
        }
    }
}
