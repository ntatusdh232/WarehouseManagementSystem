namespace WMS.Api.Application.Commands.FinishedProductIssues
{
    public class AddFinishedProductIssueEntriesCommandHandler : IRequestHandler<AddFinishedProductIssueEntriesCommand, bool>
    {
        private readonly IFinishedProductIssueRepository _finishedProductIssueRepository;
        private readonly IItemRepository _itemRepository;

        public AddFinishedProductIssueEntriesCommandHandler(IFinishedProductIssueRepository finishedProductIssueRepository, IItemRepository itemRepository)
        {
            _finishedProductIssueRepository = finishedProductIssueRepository;
            _itemRepository = itemRepository;
        }

        public async Task<bool> Handle(AddFinishedProductIssueEntriesCommand request, CancellationToken cancellationToken)
        {
            var finishedProductIssue = await _finishedProductIssueRepository.GetIssueById(request.FinishedProductIssueId);
            if (finishedProductIssue == null)
            {
                throw new EntityNotFoundException(nameof(FinishedProductIssue), request.FinishedProductIssueId);
            }

            foreach (var entry in request.Entries)
            {
                var item = await _itemRepository.GetItemById(entry.ItemId);
                if (item == null)
                {
                    throw new EntityNotFoundException(nameof(Item), entry.ItemId);
                }

                var finishedProductIssueEntry = new FinishedProductIssueEntry(purchaseOrderNumber: entry.PurchaseOrderNumber,
                                                                              quantity: entry.Quantity,
                                                                              note: entry.Note,
                                                                              item: item,
                                                                              itemId: entry.ItemId);
                finishedProductIssue.AddIssueEntry(finishedProductIssueEntry);
                finishedProductIssue.UpdateFinishedProductInventory(item: item,
                                                                    purchaseOrderNumber: entry.PurchaseOrderNumber,
                                                                    quantity: entry.Quantity);
            }

            await _finishedProductIssueRepository.UpdateEntries(finishedProductIssue);

            return await _finishedProductIssueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }




    }
}
