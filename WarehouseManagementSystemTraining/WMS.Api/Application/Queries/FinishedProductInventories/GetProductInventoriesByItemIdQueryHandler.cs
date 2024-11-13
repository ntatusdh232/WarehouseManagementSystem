
namespace WMS.Api.Application.Queries.FinishedProductInventories;

public class GetProductInventoriesByItemIdQueryHandler : IRequestHandler<GetProductInventoriesByItemIdQuery, IEnumerable<FinishedProductInventoryViewModel>>
{
    private readonly ApplicationDbContext _context; 
    private readonly IMapper _mapper;

    public GetProductInventoriesByItemIdQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FinishedProductInventoryViewModel>> Handle(GetProductInventoriesByItemIdQuery request, CancellationToken cancellationToken)
    {
        var _productInventories = _context.finishedProductInventories.AsNoTracking();

        await _productInventories.Where(p => p.Item.ItemId == request.ItemId).ToListAsync();
  
        return _mapper.Map<IEnumerable<FinishedProductInventory>, IEnumerable<FinishedProductInventoryViewModel>>(_productInventories);
        
    }
}
