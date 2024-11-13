
namespace WMS.Api.Application.Queries.GoodsIssues;

public class GetReceiversQueryHandler : IRequestHandler<GetReceiversQuery, List<string>>
{
    private readonly ApplicationDbContext _context;

    public GetReceiversQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<string>> Handle(GetReceiversQuery request, CancellationToken cancellationToken)
    {
        var goodsIssueReceivers = await _context.goodsIssues
            .AsNoTracking()
            .Select(g => g.Receiver)
            .ToListAsync();

        var departmentReceivers = await _context.departments
           .AsNoTracking()
           .Select(d => d.Name)
           .ToListAsync();

        List<string> allReceivers = new List<string>();

        if (goodsIssueReceivers != null)
        {
            allReceivers.AddRange(goodsIssueReceivers);
        }

        if (departmentReceivers != null)
        {
            allReceivers.AddRange(departmentReceivers);
        }

        var distinctReceivers = allReceivers.Distinct().ToList();

        return distinctReceivers;
    }
}
