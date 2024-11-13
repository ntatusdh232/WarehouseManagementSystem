
using DocumentFormat.OpenXml.Drawing;

namespace WMS.Api.Application.Queries.FinishedProductReceipts;

public class GetByTimeQueryHandler : IRequestHandler<GetByTimeQuery, IEnumerable<FinishedProductReceiptViewModel>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetByTimeQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<FinishedProductReceiptViewModel>> Handle(GetByTimeQuery request, CancellationToken cancellationToken)
    {
        var productReceipts = _context.finishedProductReceipts.AsNoTracking();

        await productReceipts.Where(p => p.Timestamp >= request.Query.StartTime && p.Timestamp <= request.Query.EndTime).ToArrayAsync();

        return _mapper.Map<IEnumerable<FinishedProductReceipt>, IEnumerable<FinishedProductReceiptViewModel>>(productReceipts);
    }
}
