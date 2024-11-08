namespace WMS.Api.Application.Commands.GoodsIssues
{
    public class UpdateGoodsIssueEntryCommandHandler : IRequestHandler<UpdateGoodsIssueEntryCommand,bool>
    {
        private readonly IGoodsIssueRepository _goodsIssueRepository;
        private readonly IItemRepository _itemRepository;

        public UpdateGoodsIssueEntryCommandHandler(IGoodsIssueRepository goodsIssueRepository, IItemRepository itemRepository)
        {
            _goodsIssueRepository = goodsIssueRepository;
            _itemRepository = itemRepository;
        }

        public async Task<bool> Handle(UpdateGoodsIssueEntryCommand  request, CancellationToken cancellationToken)
        {
            var goodsIssue = await _goodsIssueRepository.GetGoodsIssueById(request.GoodsIssueId)
                                   ?? throw new EntityNotFoundException(nameof(GoodsIssue), request.GoodsIssueId);

            foreach (var entry in request.Entries)
            {
                goodsIssue.UpdateEntry(itemId: entry.ItemId,
                                       unit: entry.Unit,
                                       quantity: entry.RequestedQuantity);

            }

            await _goodsIssueRepository.Update(goodsIssue);

            return await _goodsIssueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }

    }
}
