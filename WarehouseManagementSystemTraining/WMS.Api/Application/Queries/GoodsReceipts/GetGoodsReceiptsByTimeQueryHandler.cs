public class GetGoodsReceiptsByTimeQueryHandler : IRequestHandler<GetGoodsReceiptsByTimeQuery, IEnumerable<GoodsReceiptViewModel>>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public GetGoodsReceiptsByTimeQueryHandler(IMapper mapper, ApplicationDbContext context, IMediator mediator)
    {
        _mapper = mapper;
        _context = context;
        _mediator = mediator;
    }

    public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetGoodsReceiptsByTimeQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<GoodsReceiptViewModel> goodsReceipts = new List<GoodsReceiptViewModel>();

        if (request.IsCompleted is true)
        {
            goodsReceipts = await _mediator.Send(new GetCompletedGoodsReceiptsQuery());
        }
        else
        {
            goodsReceipts = await _mediator.Send(new GetUnCompletedGoodsReceiptsQuery());
        }

        var resultedGoodsReceipts = goodsReceipts
            .Where(gr => gr.Timestamp >= request.Query.StartTime && gr.Timestamp <= request.Query.EndTime)
            .Skip((request.Query.Page - 1) * request.Query.ItemsPerPage)
            .Take(request.Query.ItemsPerPage)
            .ToList();

        return resultedGoodsReceipts;
    }
}
