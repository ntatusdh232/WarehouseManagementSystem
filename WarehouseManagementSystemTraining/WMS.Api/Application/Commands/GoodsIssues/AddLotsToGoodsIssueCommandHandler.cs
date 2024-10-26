using WMS.Domain.AggregateModels.GoodsIssueAggregate;

namespace WMS.Api.Application.Commands.GoodsIssues
{
    public class AddLotsToGoodsIssueCommandHandler : IRequestHandler<AddLotsToGoodsIssueCommand, bool>
    {
        private readonly IGoodsIssueRepository _goodsIssueRepository;

        public AddLotsToGoodsIssueCommandHandler(IGoodsIssueRepository goodsIssueRepository)
        {
            _goodsIssueRepository = goodsIssueRepository;
        }

        public async Task<bool> Handle(AddLotsToGoodsIssueCommand request, CancellationToken cancellationToken)
        {
            var goodsIssue = await _goodsIssueRepository.GetGoodsIssueById(request.GoodsIssueId);

            if (goodsIssue == null)
            {
                return false;
            }

            var goodsIssueLots = request.GoodsIssueLots.Select(lot => new GoodsIssueLot
            (
                lot.GoodsIssueLotId,
                lot.Quantity,
                lot.Note??"",
                lot.EmployeeId,
                lot.Sublots,
                new Employee
                (
                    lot.EmployeeId
                )
            )).ToList();

            foreach (var entry in goodsIssue.Entries)
            {
                entry.Lots.AddRange(goodsIssueLots);
            }


            await _goodsIssueRepository.Update(goodsIssue, cancellationToken);

            return true;
        }

    }
}
