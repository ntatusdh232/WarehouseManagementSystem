
namespace WMS.Api.Application.Queries.FinishedProductReceipts;

public class GetReceiptByIdQueryHandler : IRequestHandler<GetReceiptByIdQuery, QueryResult<FinishedProductReceiptViewModel>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetReceiptByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<QueryResult<FinishedProductReceiptViewModel>> Handle(GetReceiptByIdQuery request, CancellationToken cancellationToken)
    {
        var goodsReceipt = _context.finishedProductReceipts.AsNoTracking();

        if(request.FinishedProductReceiptId is not null)
        {
            goodsReceipt = goodsReceipt.Where(g => g.FinishedProductReceiptId == request.FinishedProductReceiptId);
        }

        int totalItems = await goodsReceipt.CountAsync();

        goodsReceipt = goodsReceipt
                .OrderBy(x => x.FinishedProductReceiptId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

        var requests = await goodsReceipt.ToListAsync();

        var queryResult = new QueryResult<FinishedProductReceipt>(requests, totalItems);

        return _mapper.Map<QueryResult<FinishedProductReceipt>, QueryResult<FinishedProductReceiptViewModel>>(queryResult);
    }
}
