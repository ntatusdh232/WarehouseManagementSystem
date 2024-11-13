using WMS.Api.Application.Queries.GoodsIssues;
using WMS.Domain.AggregateModels.GoodsReceiptAggregate;

namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly GoodsReceiptQueries goodsReceiptQueries;
        private readonly GoodsIssueQueries goodsIssueQueries;

        public GetAllQueryHandler(IMapper mapper, GoodsReceiptQueries goodsReceiptQueries, GoodsIssueQueries goodsIssueQueries)
        {
            _mapper = mapper;
            this.goodsReceiptQueries = goodsReceiptQueries;
            this.goodsIssueQueries = goodsIssueQueries;
        }

        public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var goodsReceipts = await goodsReceiptQueries._goodsReceipts.ToListAsync();

            var goodsReceiptViewModels = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(goodsReceipts);

            return await goodsReceiptQueries.Filter(goodsReceiptViewModels, goodsIssueQueries._goodsIssueLots);

        }
    }
}
