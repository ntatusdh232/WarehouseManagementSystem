
namespace WMS.Api.Application.Queries.FinishedProductIssues
{
    public class GetByTimeQueryHandler : IRequestHandler<GetByTimeQuery, IEnumerable<FinishedProductIssueViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetByTimeQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FinishedProductIssueViewModel>> Handle(GetByTimeQuery request, CancellationToken cancellationToken)
        {
            var productIssues = await _context.finishedProductIssues
                .AsNoTracking()
                .Where(p => p.Timestamp >= request.Query.StartTime && p.Timestamp <= request.Query.EndTime)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<FinishedProductIssueViewModel>>(productIssues);
        }

    }

}

