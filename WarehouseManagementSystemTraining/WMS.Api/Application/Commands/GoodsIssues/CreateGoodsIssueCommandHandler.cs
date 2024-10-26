using WMS.Domain.AggregateModels.GoodsIssueAggregate;

namespace WMS.Api.Application.Commands.GoodsIssues
{
    public class CreateGoodsIssueCommandHandler : IRequestHandler<CreateGoodsIssueCommand,bool>
    {
        private readonly IGoodsIssueRepository _goodsIssueRepository;

        public CreateGoodsIssueCommandHandler(IGoodsIssueRepository goodsIssueRepository)
        {
            _goodsIssueRepository = goodsIssueRepository;
        }

        public async Task<bool> Handle(CreateGoodsIssueCommand request, CancellationToken cancellationToken)
        {
            var goodsIssue = new GoodsIssue
            (
                request.GoodsIssueId,
                request.Receiver,
                DateTime.Now,
                new Employee ( request.EmployeeId),
                request.Entries.Select(e => new GoodsIssueEntry
                (
                    e.GoodsIssueEntryId,
                    e.RequestedQuantity,
                    e.Item,
                    e.Lots,
                    e.ItemId,
                    e.GoodsIssueId
                )).ToList(),
                request.EmployeeId
            );

            await _goodsIssueRepository.Add(goodsIssue, cancellationToken);

            return true;
        }
    }
}
