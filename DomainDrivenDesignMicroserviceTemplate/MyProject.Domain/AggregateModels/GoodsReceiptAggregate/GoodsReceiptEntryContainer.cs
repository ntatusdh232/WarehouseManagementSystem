namespace ChaWarehouseMicroservice.Domain.AggregateModels.GoodsReceiptAggregate;

public class GoodsReceiptEntryContainer
{
    public int GoodsReceiptEntryId { get; set; }
    public string ContainerId { get; private set; }
    public double PlannedQuantity { get; private set; }
    public double ActualQuantity { get; private set; }
    public DateTime ProductionDate { get; private set; }

    public GoodsReceiptEntryContainer(string containerId, double plannedQuantity, double actualQuantity, DateTime productionDate)
    {
        ContainerId = containerId;
        PlannedQuantity = plannedQuantity;
        ActualQuantity = actualQuantity;
        ProductionDate = productionDate;
    }
}
