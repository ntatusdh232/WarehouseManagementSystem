using DocumentFormat.OpenXml.Vml.Office;
using WMS.Api.ErrorNotifications;

namespace WMS.Api.Application.Commands.FinishedProductIssues
{
    public class CreateFinishedProductIssueCommandHandler : IRequestHandler<CreateFinishedProductIssueCommand,bool>
    {
        private readonly IFinishedProductIssueRepository _finishedProductIssueRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IItemRepository _itemRepository;

        public CreateFinishedProductIssueCommandHandler(IFinishedProductIssueRepository finishedProductIssueRepository, IEmployeeRepository employeeRepository, IItemRepository itemRepository)
        {
            _finishedProductIssueRepository = finishedProductIssueRepository;
            _employeeRepository = employeeRepository;
            _itemRepository = itemRepository;
        }

        public async Task<bool> Handle(CreateFinishedProductIssueCommand request, CancellationToken cancellationToken)
        {
            var finishedProductIssue = await _finishedProductIssueRepository.GetIssueById(request.FinishedProductIssueId);
            if (finishedProductIssue != null)
            {
                new DuplicatedRecordErrorDetail(nameof(FinishedProductIssue), request.FinishedProductIssueId);
            }
                
            var employee = _employeeRepository.GetEmployeeById(request.EmployeeId);

            if (employee == null)
            {
                throw new EntityNotFoundException(nameof(Employee), request.EmployeeId);
            }

            finishedProductIssue = new FinishedProductIssue(finishedProductIssueId: request.FinishedProductIssueId,
                                                            receiver: request.Receiver,
                                                            employeeId: request.EmployeeId);

            foreach (var entry in request.Entries)
            {
                var item = await _itemRepository.GetItemById(entry.ItemId);
                if (item == null)
                {
                    throw new EntityNotFoundException(nameof(Item), entry.ItemId);
                }

                var FinishedProductIssueEntry = new FinishedProductIssueEntry(purchaseOrderNumber: entry.PurchaseOrderNumber,
                                                                              quantity:  entry.Quantity,
                                                                              note: entry.Note,
                                                                              item: item,
                                                                              itemId: entry.ItemId);
                finishedProductIssue.AddIssueEntry(FinishedProductIssueEntry);
            }
            await _finishedProductIssueRepository.AddAsync(finishedProductIssue);

            return await _finishedProductIssueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
