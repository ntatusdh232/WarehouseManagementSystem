namespace WMS.Domain.AggregateModels.LotAdjustmentAggregate
{
    public interface ILotAdjustmentRepository : IRepository<LotAdjustment>
    {
        Task<LotAdjustment> Add(LotAdjustment lotAdjustment);
        Task<LotAdjustment> Update(LotAdjustment lotAdjustment);
        Task Remove(string LotId);
        Task<IEnumerable<LotAdjustment>> GetAdjustmentByLotId(string LotId);
        Task<IEnumerable<LotAdjustment>> GetUnConfirmedAdjustments();
        

    }
}
