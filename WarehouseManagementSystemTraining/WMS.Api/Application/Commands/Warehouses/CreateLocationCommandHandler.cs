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
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            
            var warehousecheck = await _departmentRepository.GetWarehouseById(request.WarehouseId);
            
            if (warehousecheck != null)
            {
                throw new ArgumentException($"Warehouse with ID {warehousecheck.WarehouseId} already exists.");
            }

            var warehouse = new Warehouse
            (
                request.WarehouseId,
                request.LocationId
            );

            await _departmentRepository.Add(warehouse, cancellationToken);

            return true;
        }
    }
}
