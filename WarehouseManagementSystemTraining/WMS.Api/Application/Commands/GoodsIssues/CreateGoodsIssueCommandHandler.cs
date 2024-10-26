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
            {
                GoodsIssueId = request.GoodsIssueId,
                Receiver = request.Receiver,
                Employee = new Employee { EmployeeId = request.EmployeeId},
                Entries = request.Entries.Select(e => new GoodsIssueEntry
                {
                    GoodsIssueEntryId = e.GoodsIssueEntryId,
                    RequestedQuantity = e.RequestedQuantity,
                    Item = e.Item,
                    Lots = e.Lots,
                    ItemId = e.ItemId,
                    GoodsIssueId = e.GoodsIssueId
                }).ToList(),
                EmployeeId = request.EmployeeId
            };

            await _goodsIssueRepository.Add(goodsIssue, cancellationToken);

            return true;
        }
    }
}
