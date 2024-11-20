namespace WMS.Api.Application.Queries.Warehouses;
public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, IEnumerable<LocationViewModel>>
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    public GetAllLocationsQueryHandler(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<IEnumerable<LocationViewModel>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
    {
        var locations = await _context.locations.ToListAsync();
        var viewModels = _mapper.Map<IEnumerable<LocationViewModel>>(locations);
        return viewModels;
    }
}