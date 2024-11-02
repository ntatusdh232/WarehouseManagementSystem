using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Domain.AggregateModels.StorageAggregate.Warehouse>> GetAllAsync()
        {
            return await _context.warehouses.ToListAsync();
        }

        public async Task Add(Domain.AggregateModels.StorageAggregate.Warehouse request, CancellationToken cancellationToken)
        {
            if (request == null) 
            {
                throw new ArgumentNullException(nameof(request));
            }

            await _context.warehouses.AddAsync(request);

            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task<Domain.AggregateModels.StorageAggregate.Warehouse> GetWarehouseById(string warehouseId)
        {
            var warehouse = await _context.warehouses.FindAsync(warehouseId);
            if (warehouse == null)
            {
                throw new Exception($"Warehouse with {warehouseId} is not found");
            }
            else
            {
                return warehouse;
            }
        }

        public async Task<Domain.AggregateModels.StorageAggregate.Warehouse> AdDepartment(Domain.AggregateModels.StorageAggregate.Warehouse request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await _context.warehouses.AddAsync(request);

            await _context.SaveChangesAsync(cancellationToken);

            return request;
        }

        public async Task<IEnumerable<Domain.AggregateModels.StorageAggregate.Warehouse>> GetAllDepartmentsAsync(CancellationToken cancellationToken)
        {
            return await _context.warehouses.ToListAsync(cancellationToken);
        }


    }
}
