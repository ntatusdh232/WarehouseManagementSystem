namespace WMS.Api.Application.Commands.FinishedProductIssues
{
    public class RemoveFinishedProductIssueEntryCommandHandler : IRequestHandler<RemoveFinishedProductIssueEntryCommand, bool>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IFinishedProductIssueRepository _finishedProductIssueRepository;

        public RemoveFinishedProductIssueEntryCommandHandler(IItemRepository itemRepository, IFinishedProductIssueRepository finishedProductIssueRepository)
        {
            _itemRepository = itemRepository;
            _finishedProductIssueRepository = finishedProductIssueRepository;
        }

        public async Task<bool> Handle(RemoveFinishedProductIssueEntryCommand request, CancellationToken cancellationToken)
        {
            var finishedProductIssue = await _finishedProductIssueRepository.GetIssueById(request.FinishedProductIssueId);
            if (finishedProductIssue is null)
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
