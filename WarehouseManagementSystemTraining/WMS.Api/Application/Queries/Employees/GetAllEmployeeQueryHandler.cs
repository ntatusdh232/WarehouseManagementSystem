namespace WMS.Api.Application.Queries.Employees
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<EmployeeViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetAllEmployeeQueryHandler(ApplicationDbContext context, IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _context = context;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeViewModel>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GettAllAsync();

            var employeesViewModel = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);

            return employeesViewModel;
        }
    }
}


