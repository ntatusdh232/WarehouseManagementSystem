namespace WMS.Api.Application.Commands.FinishedProductReceipts
{
    public class DeleteFinishedProductReceiptCommandHandler : IRequestHandler<DeleteFinishedProductReceiptCommand, bool>
    {
        private readonly IFinishedProductReceiptRepository _finishedProductReceiptRepository;
        private readonly IItemRepository _itemRepository;

        public DeleteFinishedProductReceiptCommandHandler(IFinishedProductReceiptRepository finishedProductReceiptRepository, IItemRepository itemRepository)
        {
            _finishedProductReceiptRepository = finishedProductReceiptRepository;
            _itemRepository = itemRepository;
        }

        public async Task<bool> Handle(DeleteFinishedProductReceiptCommand request, CancellationToken cancellationToken)
        {
            var finishedProductReceipt = await _finishedProductReceiptRepository.GetReceiptById(request.FinishedProductReceiptId);

            if (finishedProductReceipt == null)
            {
                throw new EntityNotFoundException(nameof(FinishedProductReceipt), request.FinishedProductReceiptId);
            }

            foreach (var entry in finishedProductReceipt.Entries)
            {
                var item = await _itemRepository.GetItemById(entry.ItemId);
                if (item == null)
                {
                    throw new EntityNotFoundException(nameof(Item), entry.ItemId);
                }

                finishedProductReceipt.RemoveFinishedProductInventory(item: item,
                                                                      purchaseOrderNumber: entry.PurchaseOrderNumber);

            }
            
            await _finishedProductReceiptRepository.Remove(finishedProductReceipt.FinishedProductReceiptId);

            return await _finishedProductReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
