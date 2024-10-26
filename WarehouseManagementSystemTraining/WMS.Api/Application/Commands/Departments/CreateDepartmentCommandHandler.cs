﻿namespace WMS.Api.Application.Commands.Departments
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
            var department = new Warehouse
            {
                WarehouseId = request.Id,
                WarehouseName = request.Name,
            };

            await _departmentRepository.Add(department, cancellationToken);

            return true;
        }

    }
}
