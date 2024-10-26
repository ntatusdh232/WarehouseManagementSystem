using WMS.Domain.AggregateModels.GoodsIssueAggregate;

namespace WMS.Api.Application.Commands.GoodsIssues
{
    public class RemoveGoodsIssueEntryCommandHandler : IRequestHandler<RemoveGoodsIssueEntryCommand, bool>
    {
        private readonly IGoodsIssueEntryRepository _goodsIssueEntryRepository;

        public RemoveGoodsIssueEntryCommandHandler(IGoodsIssueEntryRepository goodsIssueEntryRepository)
        {
            _goodsIssueEntryRepository = goodsIssueEntryRepository;
        }

        public async Task<bool> Handle(RemoveGoodsIssueEntryCommand request, CancellationToken cancellationToken)
        {
            var goodsIssueEntry = await _goodsIssueEntryRepository.GetEntryByGoodsIssueIdAndItemId(request.GoodsIssueId, request.ItemId);

            if (goodsIssueEntry == null)
            {
                return false;
            }

            await _goodsIssueEntryRepository.RemoveEntry(goodsIssueEntry, cancellationToken);

            return true;
        }
    }
}
