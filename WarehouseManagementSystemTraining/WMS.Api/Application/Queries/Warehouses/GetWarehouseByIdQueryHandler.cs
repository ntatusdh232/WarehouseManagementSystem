namespace WMS.Api.Application.Queries.Warehouses;
public class GetWarehouseByIdQueryHandler : IRequestHandler<GetWarehouseByIdQuery, QueryResult<WarehouseViewModel>>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    public GetWarehouseByIdQueryHandler(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<QueryResult<WarehouseViewModel>> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
    {
        var warehouse = await _context.warehouses.Include(w => w.Locations).FirstOrDefaultAsync();

        var viewModel = _mapper.Map<QueryResult<WarehouseViewModel>>(warehouse);

        return viewModel;
    }
}