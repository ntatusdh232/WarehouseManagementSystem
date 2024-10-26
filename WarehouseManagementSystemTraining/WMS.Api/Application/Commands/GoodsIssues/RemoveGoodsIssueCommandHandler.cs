using WMS.Domain.AggregateModels.GoodsIssueAggregate;

namespace WMS.Api.Application.Commands.GoodsIssues
{
    public class RemoveGoodsIssueCommandHandler : IRequestHandler<RemoveGoodsIssueCommand, bool>
    {
        private readonly IGoodsIssueRepository _goodsIssueRepository;

        public RemoveGoodsIssueCommandHandler(IGoodsIssueRepository goodsIssueRepository)
        {
            _goodsIssueRepository = goodsIssueRepository;
        }

        public async Task<bool> Handle(RemoveGoodsIssueCommand request, CancellationToken cancellationToken)
        {
            var goodsIssue = await _goodsIssueRepository.GetGoodsIssueById(request.GoodsIssueId);

            if (goodsIssue == null)
            {
                return false;
            }

            await _goodsIssueRepository.Remove(goodsIssue.GoodsIssueId, cancellationToken);

            return true;
        }
    }
}
