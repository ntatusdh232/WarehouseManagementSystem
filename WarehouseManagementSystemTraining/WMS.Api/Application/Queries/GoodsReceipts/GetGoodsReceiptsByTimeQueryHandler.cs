namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetGoodsReceiptsByTimeQueryHandler : IRequestHandler<GetGoodsReceiptsByTimeQuery, IEnumerable<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly GetCompletedGoodsReceiptsQueryHandler _completedGoodsReceipt;
        private readonly GetUnCompletedGoodsReceiptsQueryHandler _uncompletedGoodsReceipt;

        public GetGoodsReceiptsByTimeQueryHandler(IMapper mapper, ApplicationDbContext context, GetCompletedGoodsReceiptsQueryHandler completedGoodsReceipt, GetUnCompletedGoodsReceiptsQueryHandler uncompletedGoodsReceipt)
        {
            _mapper = mapper;
            _context = context;
            _completedGoodsReceipt = completedGoodsReceipt;
            _uncompletedGoodsReceipt = uncompletedGoodsReceipt;
        }

        public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetGoodsReceiptsByTimeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<GoodsReceiptViewModel> goodsReceipts = new List<GoodsReceiptViewModel>();

            if (request.IsCompleted is true)
            {
                goodsReceipts = await _completedGoodsReceipt.GetCompleteGoodsReceipt();
            }
            else
            {
                goodsReceipts = await _uncompletedGoodsReceipt.GetUnCompleteGoodsReceipt();
            }
            var resultedGoodsReceipts = goodsReceipts.Where(gr => gr.Timestamp >= request.Query.StartTime && gr.Timestamp <= request.Query.EndTime)
                                                     .Skip((request.Query.Page - 1) * request.Query.ItemsPerPage)
                                                     .Take(request.Query.ItemsPerPage).ToList();
            return resultedGoodsReceipts;

        }
    }
}
