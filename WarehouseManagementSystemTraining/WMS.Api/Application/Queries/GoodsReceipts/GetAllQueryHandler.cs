using WMS.Api.Application.Queries.GoodsIssues;
using WMS.Domain.AggregateModels.GoodsReceiptAggregate;

namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly GoodsReceiptQueries goodsReceiptQueries;
        private readonly ApplicationDbContext _context;

        public GetAllQueryHandler(IMapper mapper, GoodsReceiptQueries goodsReceiptQueries, ApplicationDbContext context)
        {
            _mapper = mapper;
            this.goodsReceiptQueries = goodsReceiptQueries;
            _context = context;
        }

        public IQueryable<GoodsIssueLot> _goodsIssueLots => _context.goodsIssues
            .AsNoTracking()
            .SelectMany(gi => gi.Entries)
            .SelectMany(e => e.Lots);

        public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var goodsReceipts = await goodsReceiptQueries._goodsReceipts.ToListAsync();

            var goodsReceiptViewModels = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(goodsReceipts);

            return await goodsReceiptQueries.Filter(goodsReceiptViewModels, _goodsIssueLots);

        }
    }
}
