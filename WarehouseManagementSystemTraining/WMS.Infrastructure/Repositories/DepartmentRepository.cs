using WMS.Domain.AggregateModels.DepartmentAggregate;

namespace WMS.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context) { }

        public Department Add(Department department)
        {
            
           return _context.departments.Add(department).Entity;
     
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _context.departments.ToListAsync();
        }


    }
}
