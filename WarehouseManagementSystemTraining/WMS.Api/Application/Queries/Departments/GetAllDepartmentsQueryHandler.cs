using WMS.Domain.AggregateModels.DepartmentAggregate;

namespace WMS.Api.Application.Queries.Departments
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmentViewModel>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentViewModel>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAllAsync();
            var departmentViewModels = _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            return departmentViewModels;
        }
    }
    
}
