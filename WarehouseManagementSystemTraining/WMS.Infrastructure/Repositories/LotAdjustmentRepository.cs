namespace WMS.Infrastructure.Repositories
{
    public class LotAdjustmentRepository : BaseRepository, ILotAdjustmentRepository
    {
        public LotAdjustmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<LotAdjustment> Add(LotAdjustment lotAdjustment)
        {
            var existingLot = await _context.lotAdjustments.FindAsync(lotAdjustment.LotId);

            await _context.lotAdjustments.AddAsync(lotAdjustment);
            await _context.SaveChangesAsync();
            return lotAdjustment;

        }

        public async Task Update(LotAdjustment lotAdjustment)
        {
            var existingLot = await _context.lotAdjustments.FindAsync(lotAdjustment.LotId);


            existingLot.Update(lotAdjustment);


        }

        public async Task Remove(string LotId)
        {
            var existingLot = await _context.lotAdjustments.FindAsync(LotId);


            _context.lotAdjustments.Remove(existingLot);

        }

        public async Task<LotAdjustment> GetAdjustmentByLotId(string LotId)
        {
            var lotAdjustments = await _context.lotAdjustments.FindAsync(LotId);

            return lotAdjustments;


        }

        public async Task<IEnumerable<LotAdjustment>> GetUnConfirmedAdjustments()
        {
            var lotAdjustments = await _context.lotAdjustments.Where(l => l.IsConfirmed == false).ToListAsync();

            return lotAdjustments;


        }

    }
}
