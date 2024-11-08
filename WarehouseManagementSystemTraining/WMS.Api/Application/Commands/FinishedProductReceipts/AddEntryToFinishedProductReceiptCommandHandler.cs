
namespace WMS.Api.Application.Commands.FinishedProductReceipts;

public class AddEntryToFinishedProductReceiptCommandHandler : IRequestHandler<AddEntryToFinishedProductReceiptCommand, bool>
{
    private readonly IFinishedProductReceiptRepository _finishedProductReceiptRepository;
    private readonly IFinishedProductInventoryRepository _finishedProductInventoryRepository;
    private readonly IItemRepository _itemRepository;

    public AddEntryToFinishedProductReceiptCommandHandler(IFinishedProductReceiptRepository finishedProductReceiptRepository, IFinishedProductInventoryRepository finishedProductInventoryRepository, IItemRepository itemRepository)
    {
        _finishedProductReceiptRepository = finishedProductReceiptRepository;
        _finishedProductInventoryRepository = finishedProductInventoryRepository;
        _itemRepository = itemRepository;
    }

    public async Task<bool> Handle(AddEntryToFinishedProductReceiptCommand request, CancellationToken cancellationToken)
    {
        var finishedProductReceipt = await _finishedProductReceiptRepository.GetReceiptById(request.FinishedProductReceiptId);
        if (finishedProductReceipt is null)
        {
            throw new EntityNotFoundException(nameof(FinishedProductReceipt), request.FinishedProductReceiptId);
        }
        foreach (var entry in request.Entries)
        {
            var item = await _itemRepository.GetItemById(entry.ItemId);
            if (item is null)
            {
                throw new EntityNotFoundException(nameof(Item), entry.ItemId);
            }
            var newFinishedProductReceiptEntry = new FinishedProductReceiptEntry(purchaseOrderNumber: entry.PurchaseOrderNumber,
                                                                                 quantity: entry.Quantity,
                                                                                 note: entry.Note,
                                                                                 item: item,
                                                                                 itemId: entry.ItemId);
            finishedProductReceipt.AddReceiptEntry(newFinishedProductReceiptEntry);
            finishedProductReceipt.UpdateFinishedProductInventory(entry.PurchaseOrderNumber, entry.Quantity, DateTime.Now, item);

        }
        await _finishedProductReceiptRepository.Update(finishedProductReceipt);
        return await _finishedProductReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
