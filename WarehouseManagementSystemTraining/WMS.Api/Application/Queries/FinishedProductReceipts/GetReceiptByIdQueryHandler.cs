
namespace WMS.Api.Application.Queries.FinishedProductReceipts;

public class GetReceiptByIdQueryHandler : IRequestHandler<GetReceiptByIdQuery,FinishedProductReceiptViewModel>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetReceiptByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FinishedProductReceiptViewModel> Handle(GetReceiptByIdQuery request, CancellationToken cancellationToken)
    {
        var goodsReceipt = await _context.finishedProductReceipts.FirstOrDefaultAsync(x => x.FinishedProductReceiptId == request.FinishedProductReceiptId);

        if(goodsReceipt is null)
        {
            throw new EntityNotFoundException(nameof(FinishedProductReceipt), request.FinishedProductReceiptId);
        }

        return _mapper.Map<FinishedProductReceiptViewModel>(goodsReceipt);

        
    }
}
