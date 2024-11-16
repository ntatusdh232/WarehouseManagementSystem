
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

        var productInventories = await _context.finishedProductInventories
            .AsNoTracking()
            .Include(p => p.Item)
            .Where(p => p.Item.ItemId == request.ItemId) 
            .ToListAsync(cancellationToken);

        var item = await _context.items.FindAsync(request.ItemId);

        if (productInventories == null)
        {
            throw new EntityNotFoundException(nameof(FinishedProductInventory), request.ItemId);
        }

        var productInventoriesViewModel = _mapper.Map<IEnumerable<FinishedProductInventoryViewModel>>(productInventories);
        var itemsViewModel = _mapper.Map<ItemViewModel>(item);

        foreach (var productInventory in productInventoriesViewModel)
        {
            productInventory.UpdateItems(itemsViewModel);
        }

        return productInventoriesViewModel;


    }

}
