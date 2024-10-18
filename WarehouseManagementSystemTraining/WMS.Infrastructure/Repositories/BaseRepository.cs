namespace WMS.Infrastructure.Repositories
{
    public class BaseRepository
    {
        protected readonly ApplicationDbContext _context;
        public IUnitOfWork UnitOfWork => _context;


        public BaseRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


    }
}
