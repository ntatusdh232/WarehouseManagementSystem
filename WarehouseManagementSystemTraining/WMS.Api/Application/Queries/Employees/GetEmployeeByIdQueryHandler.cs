
namespace WMS.Api.Application.Queries.Employees
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, QueryResult<EmployeeViewModel>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<QueryResult<EmployeeViewModel>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeById(request.EmployeeId);
            if (employee == null)
            {
                throw new EntityNotFoundException(nameof(Employee), request.EmployeeId);
            }

            var employeeViewModel = _mapper.Map<QueryResult<EmployeeViewModel>>(employee);

            return employeeViewModel;


        }
    }
}


