namespace WMS.Api.Application.Queries.Warehouses;
public class GetWarehouseByIdQueryHandler : IRequestHandler<GetWarehouseByIdQuery, WarehouseViewModel>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    public GetWarehouseByIdQueryHandler(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<WarehouseViewModel> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
    {
        var warehouse = await _context.warehouses.Include(w => w.Locations).FirstOrDefaultAsync(x => x.WarehouseId == request.WarehouseId);

        var viewModel = _mapper.Map<WarehouseViewModel>(warehouse);

        return viewModel;
    }
}