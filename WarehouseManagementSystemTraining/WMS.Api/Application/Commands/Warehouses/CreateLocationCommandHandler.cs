namespace WMS.Api.Application.Commands.Warehouses
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand,bool>
    {
        private readonly IStorageRepository _storageRepository;

        public CreateLocationCommandHandler(IStorageRepository departmentRepository)
        {
            _storageRepository = departmentRepository;
        }

        public async Task<bool> Handle (CreateLocationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
