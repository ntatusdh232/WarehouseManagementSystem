using WMS.Domain.AggregateModels.GoodsIssueAggregate;

namespace WMS.Api.Application.Commands.GoodsIssues;

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
        if (goodsIssue is null)
        {
            throw new EntityNotFoundException(nameof(GoodsIssue), request.GoodsIssueId);
        }
        if (goodsIssue.Entries.Count == 0)
        {
            await _goodsIssueRepository.Remove(request.GoodsIssueId, cancellationToken);
        }
        return await _goodsIssueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
