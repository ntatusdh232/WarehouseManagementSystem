namespace WMS.Api.Application.Commands.FinishedProductReceipts
{
    public class RemoveFinishedProductReceiptEntriesCommandHandler : IRequestHandler<RemoveFinishedProductReceiptEntriesCommand, bool>
    {
        private readonly IFinishedProductReceiptRepository _finishedProductReceiptRepository;
        private readonly IItemRepository _itemRepository;

        public RemoveFinishedProductReceiptEntriesCommandHandler(IFinishedProductReceiptRepository finishedProductReceiptRepository, 
                                                                 IItemRepository itemRepository)
        {
            _finishedProductReceiptRepository = finishedProductReceiptRepository;
            _itemRepository = itemRepository;
        }

        public async Task<bool> Handle(RemoveFinishedProductReceiptEntriesCommand request, CancellationToken cancellationToken)
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

                finishedProductReceipt.RemoveFinishedProductInventory(item: item,
                                                                      purchaseOrderNumber: entry.PurchaseOrderNumber);

                finishedProductReceipt.RemoveReceiptEntry(item,entry.PurchaseOrderNumber);

            }
            
            await _finishedProductReceiptRepository.Update(finishedProductReceipt);

            return await _finishedProductReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }



    }
}
