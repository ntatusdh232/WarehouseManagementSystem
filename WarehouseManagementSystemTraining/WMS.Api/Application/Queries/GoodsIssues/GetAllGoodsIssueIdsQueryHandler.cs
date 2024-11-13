namespace WMS.Api.Application.Queries.GoodsIssues
{
    public class GetAllGoodsIssueIdsQueryHandler : IRequestHandler<GetAllGoodsIssueIdsQuery, IEnumerable<string>>
    {
        private readonly IMapper _mapper;
        private readonly GoodsIssueQueries goodsIssuesQuery;

        public GetAllGoodsIssueIdsQueryHandler(IMapper mapper, GoodsIssueQueries goodsIssuesQuery)
        {
            _mapper = mapper;
            this.goodsIssuesQuery = goodsIssuesQuery;
        }

        public async Task<IEnumerable<string>> Handle(GetAllGoodsIssueIdsQuery request, CancellationToken cancellationToken)
        {
            var goodsIssueIds = new List<string> { };

            if (request.IsExported == true)
            {
                goodsIssueIds = await goodsIssuesQuery._goodsIssues
                    .Where(gi => gi.Entries.Count > 0 && gi.Entries
                    .All(gie => gie.Lots.Count != 0) && gi.Entries
                    .All(gie => gie.RequestedQuantity <= gie.Lots
                    .Sum(lot => lot.Quantity)))
                    .Select(gi => gi.GoodsIssueId)
                    .ToListAsync();
            }

            if (request.IsExported == false)
            {
                goodsIssueIds = await goodsIssuesQuery._goodsIssues
                    .Where(gi => gi.Entries.Count == 0 || gi.Entries
                    .Any(gie => gie.Lots.Count == 0) || gi.Entries
                    .Any(gie => gie.RequestedQuantity > gie.Lots
                    .Sum(lot => lot.Quantity)))
                    .Select(gi => gi.GoodsIssueId)
                    .ToListAsync();
            }

            return goodsIssueIds;
        }
    }

}

