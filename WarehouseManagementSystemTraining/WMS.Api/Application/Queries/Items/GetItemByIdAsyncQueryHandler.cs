
namespace WMS.Api.Application.Queries.Items;

public class GetItemByIdAsyncQueryHandler : IRequestHandler<GetItemByIdAsyncQuery, ItemViewModel>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public GetItemByIdAsyncQueryHandler(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    private IQueryable<Item> _items => _context.items.AsNoTracking();

    public async Task<ItemViewModel> Handle(GetItemByIdAsyncQuery request, CancellationToken cancellationToken)
    {
        var item = await _items.Where(x => x.ItemId == request.ItemId && x.Unit == request.Unit).FirstOrDefaultAsync();

        var viewModel = _mapper.Map<ItemViewModel>(item);

        return viewModel;
    }
}
