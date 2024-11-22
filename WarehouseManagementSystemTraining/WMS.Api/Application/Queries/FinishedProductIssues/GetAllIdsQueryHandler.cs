using WMS.Api.Application.Queries.FinishedProductIssues;

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
        var productIssueIds = await _context.finishedProductIssues
            .AsNoTracking()
            .Select(p => p.FinishedProductIssueId.ToString())
            .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<string>>(productIssueIds);
    }
}
