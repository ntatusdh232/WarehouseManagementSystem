
namespace WMS.Api.Application.Commands.FinishedProductReceipts;

public class CreateFinishedProductReceiptCommandHandler : IRequestHandler<CreateFinishedProductReceiptCommand, bool>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IFinishedProductReceiptRepository _finishedProductReceiptRepository;
    private readonly IItemRepository _itemRepository;

    public CreateFinishedProductReceiptCommandHandler(IEmployeeRepository employeeRepository, IFinishedProductReceiptRepository finishedProductReceiptRepository, IItemRepository itemRepository)
    {
        _employeeRepository = employeeRepository;
        _finishedProductReceiptRepository = finishedProductReceiptRepository;
        _itemRepository = itemRepository;
    }

    public async Task<bool> Handle(CreateFinishedProductReceiptCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeById(request.EmployeeId);
        if(employee is null)
        {
            throw new EntityNotFoundException(nameof(FinishedProductReceipt), request.EmployeeId);
        }
        var newFinishedProductReceipt = new FinishedProductReceipt(finishedProductReceiptId: request.FinishedProductReceiptId,
                                                                   employeeId: request.EmployeeId);
        foreach (var entry in request.Entries)
        {
            var item = await _itemRepository.GetItemById(entry.ItemId);
            if (item == null)
            {
                throw new EntityNotFoundException(nameof(Item), entry.ItemId);
            }
            var newfinishedProductReceiptEntry = new FinishedProductReceiptEntry(purchaseOrderNumber: entry.PurchaseOrderNumber,
                                                                             quantity: entry.Quantity,
                                                                             note: entry.Note,
                                                                             item: item,
                                                                             itemId: item.ItemId);

            newFinishedProductReceipt.AddReceiptEntry(newfinishedProductReceiptEntry);
        }

        await _finishedProductReceiptRepository.Add(newFinishedProductReceipt);

        return await _finishedProductReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
