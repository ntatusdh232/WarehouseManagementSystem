namespace WMS.Api.Application.Queries.Warehouses
{
    public class GetAllWarehousesQueryHandler : IRequestHandler<GetAllWarehousesQuery, IEnumerable<WarehouseViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public GetAllWarehousesQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WarehouseViewModel>> Handle(GetAllWarehousesQuery request, CancellationToken cancellationToken)
        {
            var warehouses = await _context.warehouses.Include(s => s.Locations).ToListAsync();

            var warehouseViewModels = _mapper.Map<IEnumerable<WarehouseViewModel>>(warehouses);

            return warehouseViewModels;

        }
    }
}
