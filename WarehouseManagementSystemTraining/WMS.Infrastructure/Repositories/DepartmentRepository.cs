using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace WMS.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await _context.warehouses.ToListAsync();
        }

        public async Task Add(Warehouse request, CancellationToken cancellationToken)
        {
            if (request == null) 
            {
                throw new ArgumentNullException(nameof(request));
            }

            await _context.warehouses.AddAsync(request);

            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task<Warehouse> GetWarehouseById(string warehouseId)
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

        public async Task<Warehouse> AdDepartment(Warehouse request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await _context.warehouses.AddAsync(request);

            await _context.SaveChangesAsync(cancellationToken);

            return request;
        }

        public async Task<IEnumerable<Warehouse>> GetAllDepartmentsAsync(CancellationToken cancellationToken)
        {
            return await _context.warehouses.ToListAsync(cancellationToken);
        }


    }
}
