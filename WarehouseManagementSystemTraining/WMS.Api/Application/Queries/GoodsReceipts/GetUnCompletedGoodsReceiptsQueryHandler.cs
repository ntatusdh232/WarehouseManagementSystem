
using WMS.Api.Application.Queries.GoodsIssues;

namespace WMS.Api.Application.Queries.GoodsReceipts;

public class GetUnCompletedGoodsReceiptsQueryHandler : IRequestHandler<GetUnCompletedGoodsReceiptsQuery, IEnumerable<GoodsReceiptViewModel>>
{
    private readonly GoodsReceiptQueries goodsReceiptQueries;
    private readonly GoodsIssueQueries goodsIssueQueries;
    private readonly IMapper _mapper;

    public GetUnCompletedGoodsReceiptsQueryHandler(GoodsReceiptQueries goodsReceiptQueries, GoodsIssueQueries goodsIssueQueries, IMapper mapper)
    {
        this.goodsReceiptQueries = goodsReceiptQueries;
        this.goodsIssueQueries = goodsIssueQueries;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetUnCompletedGoodsReceiptsQuery request, CancellationToken cancellationToken)
    {
        var completedGoodsReceipts = await goodsReceiptQueries._goodsReceipts
                                    .Where(g => g.Lots
                                    .All(lot => lot.ProductionDate == null && lot.ExpirationDate == null && lot.Sublots.Count == 0) && g.Supplier == null)
                                    .ToListAsync();

        var goodsReceiptViewModels = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(completedGoodsReceipts);

        return await goodsReceiptQueries.Filter(goodsReceiptViewModels, goodsIssueQueries._goodsIssueLots);
    }
}

