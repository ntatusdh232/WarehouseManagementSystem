namespace ChaWarehouseMicroservice.Domain.AggregateModels.GoodsIssueAggregate;
public class GoodsIssueEntryContainer
{
    public int GoodsIssueEntryId { get; private set; }
    public string ContainerId { get; private set; }
    public double Quantity { get; private set; }
    public DateTime ProductionDate { get; private set; }
    public bool IsTaken { get; private set; } = false;

    private GoodsIssueEntryContainer() { }

    public GoodsIssueEntryContainer(string containerId, double quantity, DateTime productionDate)
    {
        ContainerId = containerId;
        Quantity = quantity;
        ProductionDate = productionDate;
    }

    public void Export()
    {
        IsTaken = true;
    }
}
