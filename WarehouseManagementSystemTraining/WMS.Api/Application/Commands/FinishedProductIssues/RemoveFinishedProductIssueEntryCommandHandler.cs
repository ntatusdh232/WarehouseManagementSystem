namespace WMS.Api.Application.Commands.FinishedProductIssues
{
    public class RemoveFinishedProductIssueEntryCommandHandler : IRequestHandler<RemoveFinishedProductIssueEntryCommand, bool>
    {
        private readonly IFinsihedProductIssueEntryRepository _finishedProductIssueEntryRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IFinishedProductIssueRepository _finishedProductIssueRepository;

        public RemoveFinishedProductIssueEntryCommandHandler(IFinsihedProductIssueEntryRepository finishedProductIssueEntryRepository, IItemRepository itemRepository, IFinishedProductIssueRepository finishedProductIssueRepository)
        {
            _finishedProductIssueEntryRepository = finishedProductIssueEntryRepository;
            _itemRepository = itemRepository;
            _finishedProductIssueRepository = finishedProductIssueRepository;
        }

        public async Task<bool> Handle(RemoveFinishedProductIssueEntryCommand request, CancellationToken cancellationToken)
        {
            var finishedProductIssue = await _finishedProductIssueRepository.GetIssueById(request.FinishedProductIssueId);
            if (finishedProductIssue == null)
            {
                throw new EntityNotFoundException(nameof(FinishedProductIssue), request.FinishedProductIssueId);
            }

            var item = await _itemRepository.GetItemById(request.ItemId);
            if (item == null)
            {
                throw new EntityNotFoundException(nameof(Item), request.ItemId);
            }

            finishedProductIssue.RemoveIssueEntry(inputItemId: request.ItemId,
                                                  inputPurchaseOrderNumber: request.PurchaseOrderNumber);

            return await _finishedProductIssueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            
        }

    }
}
