using MyProject.Domain.AggregateModels.ItemAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.AggregateModels.InventoryLogEntryAggregate;

public class InventoryLogEntry : Entity, IAggregateRoot
{
    public string ItemLotId { get; private set; }
    public double BeforeQuantity { get; private set; }
    public double ChangedQuantity { get; private set; }
    public double ReceivedQuantity { get; private set; }
    public double ShippedQuantity {  get; private set; }
    public DateTime Timestamp {  get; private set; }
    public DateTime TrackingTime { get; private set; }
    public Item Item { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public InventoryLogEntry()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }
}
