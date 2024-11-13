namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetCompletedGoodsReceiptsQueryHandler : IRequestHandler<GetCompletedGoodsReceiptsQuery, IEnumerable<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;
        private readonly GoodsReceiptQueries goodsReceiptQuery;
        private readonly GoodsIssueQueries goodsIssueQueries;

        public GetCompletedGoodsReceiptsQueryHandler(IMapper mapper, IGoodsReceiptRepository goodsReceiptRepository, GoodsReceiptQueries goodsReceiptQuery, GoodsIssueQueries goodsIssueQueries)
        {
            _mapper = mapper;
            _goodsReceiptRepository = goodsReceiptRepository;
            this.goodsReceiptQuery = goodsReceiptQuery;
            this.goodsIssueQueries = goodsIssueQueries;
        }

        public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetCompletedGoodsReceiptsQuery request, CancellationToken cancellationToken)
        {
            var completedGoodsReceipts = await goodsReceiptQuery._goodsReceipts
                .Where(g => g.Lots.All(lot => lot.ProductionDate != null
                                           && lot.ExpirationDate != null
                                           && lot.Sublots.Count > 0)
                         && g.Supplier != null)
                .ToListAsync();

            var goodsReceiptViewModel = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(completedGoodsReceipts);

            var newGoodsReceiptViewModel = await goodsReceiptQuery.Filter(goodsReceipts: goodsReceiptViewModel,
                                                                          goodsIssueLots: goodsIssueQueries._goodsIssueLots);

            return newGoodsReceiptViewModel;

        }



    }
}
