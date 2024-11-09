namespace WMS.Api.Application.Commands.FinishedProductReceipts
{
    public class UpdateFinishedProductReceiptEntryCommandHandler : IRequestHandler<UpdateFinishedProductReceiptEntryCommand, bool>
    {
        private readonly IFinishedProductReceiptRepository _finishedProductReceiptRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IFinishedProductInventoryRepository _finishedProductInventoryRepository;

        public UpdateFinishedProductReceiptEntryCommandHandler(IFinishedProductReceiptRepository finishedProductReceiptRepository, IItemRepository itemRepository, IFinishedProductInventoryRepository finishedProductInventoryRepository)
        {
            _finishedProductReceiptRepository = finishedProductReceiptRepository;
            _itemRepository = itemRepository;
            _finishedProductInventoryRepository = finishedProductInventoryRepository;
        }

        public FinishedProductReceiptEntry? oldEntry { get; set; }



        public async Task<bool> Handle(UpdateFinishedProductReceiptEntryCommand request, CancellationToken cancellationToken)
        {
            var finishedProductReceipt = await _finishedProductReceiptRepository.GetReceiptById(request.FinishedProductReceiptId);

            if (finishedProductReceipt == null)
            {
                throw new EntityNotFoundException(nameof(FinishedProductReceipt), request.FinishedProductReceiptId);
            }

            foreach (var entry in request.Entries)
            {
                var item = await _itemRepository.GetItemById(entry.ItemId);
                if (item == null)
                {
                    throw new EntityNotFoundException(nameof(Item), entry.ItemId);
                }

                oldEntry = finishedProductReceipt.Entries.Find(x => x.Item == entry.Item && x.PurchaseOrderNumber == entry.OldPurchaseOrderNumber);

                if (oldEntry == null)
                {
                    throw new EntityNotFoundException(nameof(FinishedProductReceiptEntry), entry.ItemId);
                }

                finishedProductReceipt.UpdateFinishedProductInventory(item: item,
                                                                      oldPurchaseOrderNumber: entry.OldPurchaseOrderNumber,
                                                                      newPurchaseOrderNumber: entry.NewPurchaseOrderNumber,
                                                                      newQuantity: entry.Quantity,
                                                                      timestamp: DateTime.Now);

                oldEntry.UpdateEntry(purchaseOrderNumber: entry.NewPurchaseOrderNumber,
                                     quantity: entry.Quantity,
                                     item: item);
 
            }

            finishedProductReceipt.GroupAndSumEntries();

            foreach (var entry in finishedProductReceipt.Entries)
            {
                   await _finishedProductInventoryRepository.Update(entry);
            }

            return await _finishedProductReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }

    }
}
