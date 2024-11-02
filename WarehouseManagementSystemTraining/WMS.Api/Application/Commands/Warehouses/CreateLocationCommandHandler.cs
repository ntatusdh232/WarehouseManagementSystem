namespace WMS.Api.Application.Commands.Warehouses
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand,bool>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public CreateLocationCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> Handle (CreateLocationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
