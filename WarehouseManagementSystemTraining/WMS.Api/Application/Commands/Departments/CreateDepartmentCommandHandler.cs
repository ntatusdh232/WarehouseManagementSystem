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
            var department = new Department(departmentId: request.Id,
                                            name: request.Name);

            _departmentRepository.Add(department);
            return await _departmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }
    }
}
