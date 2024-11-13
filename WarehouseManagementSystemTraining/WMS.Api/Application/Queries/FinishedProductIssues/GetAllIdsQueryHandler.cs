using WMS.Api.Application.Queries.FinishedProductIssuesl;

namespace WMS.Api.Application.Queries.FinishedProductIssues;

public class GetAllIdsQueryHandler : IRequestHandler<GetAllIdsQuery, IEnumerable<string>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllIdsQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<string>> Handle(GetAllIdsQuery request, CancellationToken cancellationToken)
    {
        var productIssueIds = _context.finishedProductIssues.AsNoTracking();

        await productIssueIds.Select(p => p.FinishedProductIssueId).ToArrayAsync();

        return _mapper.Map<IEnumerable<string>>(productIssueIds);
    }
}
