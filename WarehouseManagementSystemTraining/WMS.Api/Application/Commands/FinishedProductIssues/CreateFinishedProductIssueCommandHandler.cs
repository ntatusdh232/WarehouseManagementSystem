namespace WMS.Api.Application.Commands.FinishedProductIssues
{
    public class CreateFinishedProductIssueCommandHandler : IRequestHandler<CreateFinishedProductIssueCommand,bool>
    {
        private readonly IFinishedProductIssueRepository _finishedProductIssueRepository;

        public CreateFinishedProductIssueCommandHandler(IFinishedProductIssueRepository finishedProductIssueRepository)
        {
            _finishedProductIssueRepository = finishedProductIssueRepository;
        }

        public async Task<bool> Handle(CreateFinishedProductIssueCommand request, CancellationToken cancellationToken)
        {

            var finishedProductIssue = new FinishedProductIssue
            {
                FinishedProductIssueId = request.FinishedProductIssueId,
                Receiver = request.Receiver,
                Employee = new Employee ( request.EmployeeId ),
                Entries = request.Entries.Select(e => new FinishedProductIssueEntry 
                {
                    FinishedProductIssueEntryId = e.FinishedProductIssueEntryId,
                    PurchaseOrderNumber = e.PurchaseOrderNumber,
                    Quantity = e.Quantity,
                    Note = e.Note,
                    Item = e.Item,
                    ItemId = e.ItemId,
                    FinishedProductIssueId = request.FinishedProductIssueId
                }).ToList(),
                EmployeeId = request.EmployeeId
            };


            await _finishedProductIssueRepository.AddAsync(finishedProductIssue, cancellationToken);

            return true;
        }
    }
}
