
namespace WMS.Api.Application.Queries.Employees
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeViewModel>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeViewModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeById(request.EmployeeId);
            if (employee == null)
            {
                throw new EntityNotFoundException(nameof(Employee), request.EmployeeId);
            }

            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);

            return employeeViewModel;


        }
    }
}


