using WMS.Domain.AggregateModels.DepartmentAggregate;

namespace WMS.Api.Application.Commands.Departments
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, bool>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Department(request.Name);
            _departmentRepository.Add(department);
            return await _departmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
    }
}
