
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.EMMA;

namespace WMS.Api.Application.Queries.GoodsIssues;

public class GetGoodsIssuesByTimeQueryHandler : IRequestHandler<GetGoodsIssuesByTimeQuery, IEnumerable<GoodsIssueViewModel>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly GoodsIssueQueries goodsIssueQuery;

    public GetGoodsIssuesByTimeQueryHandler(ApplicationDbContext context, IMapper mapper, GoodsIssueQueries goodsReceiptQuery)
    {
        _context = context;
        _mapper = mapper;
        goodsIssueQuery = goodsReceiptQuery;
    }

    public async Task<IEnumerable<GoodsIssueViewModel>> Handle(GetGoodsIssuesByTimeQuery request, CancellationToken cancellationToken)
    {
        List<GoodsIssue> goodsIssues = new List<GoodsIssue>();

        if(request.isExported)
        {
            goodsIssues = goodsIssues = await goodsIssueQuery._goodsIssues
                .Where(gi => gi.Entries.Count > 0 &&
                             gi.Entries.All(gie => gie.Lots.Count != 0) &&
                             gi.Entries.All(gie => gie.RequestedQuantity <= gie.Lots.Sum(lot => lot.Quantity)))
                .Where(gi => gi.Timestamp >= request.Query.StartTime && gi.Timestamp <= request.Query.EndTime)
                .ToListAsync();
        }
        else
        {
            goodsIssues = await goodsIssueQuery._goodsIssues
               .Where(gi => gi.Entries.Count == 0 ||
                            gi.Entries.Any(gie => gie.Lots.Count == 0) ||
                            gi.Entries.Any(gie => gie.RequestedQuantity > gie.Lots.Sum(lot => lot.Quantity)))
               .Where(gi => gi.Timestamp >= request.Query.StartTime && gi.Timestamp <= request.Query.EndTime)
               .ToListAsync();
        }

        return _mapper.Map<IEnumerable<GoodsIssue>, IEnumerable<GoodsIssueViewModel>>(goodsIssues);

    }
}
