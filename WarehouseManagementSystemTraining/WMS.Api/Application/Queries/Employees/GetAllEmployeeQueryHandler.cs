namespace WMS.Api.Application.Queries.Employees;

public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<EmployeeViewModel>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllEmployeeQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeViewModel>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.employees.AsNoTracking().ToListAsync();

        return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(result);
    }
}
