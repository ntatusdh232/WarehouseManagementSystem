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
            var employee = _employeeRepository.GetEmployeeById(request.EmployeeId);

            var finishedProductIssue = new FinishedProductIssue
            (
                request.FinishedProductIssueId,
                request.Receiver,
                DateTime.Now,
                new Employee ( request.EmployeeId ),
                request.Entries.Select(e => new FinishedProductIssueEntry 
                (
                    e.FinishedProductIssueEntryId,
                    e.PurchaseOrderNumber,
                    e.Quantity,
                    e.Note,
                    e.Item,
                    e.ItemId,
                    request.FinishedProductIssueId
                )).ToList(),
                request.EmployeeId
            );


            await _finishedProductIssueRepository.AddAsync(finishedProductIssue, cancellationToken);

            return true;
        }
    }
}
